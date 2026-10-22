// SPDX-License-Identifier: GPL-3.0-or-later
// Copyright (C) 2026 aspctt

//// Dependencies

using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using HarmonyLib;

namespace HigherCapacityTransformers.Patches;

/// <summary>
/// Raises the output limits of the Medium and Large Transformers once the game has
/// registered its prefabs. Every transformer, whether built or loaded from a save, is
/// copied from these prefabs, so changing them once covers all of them.
///
/// LoadCorePrefabs runs last in the game's prefab loading, after every prefab is
/// registered, which makes it the earliest point where Prefab.Find can see them all.
/// </summary>
[HarmonyPatch(typeof(Prefab), nameof(Prefab.LoadCorePrefabs))]
public static class Patch_Prefab_LoadCorePrefabs
{
	//// Types

	/// <summary>The output limit one transformer prefab gets, with the steps its dial moves in.</summary>
	private readonly struct TransformerLimits
	{
		public readonly string PrefabName;
		public readonly float OutputMaximum;
		public readonly float StepNormal;
		public readonly float StepSmall;

		public TransformerLimits(string prefabName, float outputMaximum, float stepNormal, float stepSmall)
		{
			PrefabName = prefabName;
			OutputMaximum = outputMaximum;
			StepNormal = stepNormal;
			StepSmall = stepSmall;
		}
	}

	//// Constants

	// Each transformer's limit matches the cable it feeds: 100,000 W for heavy cable and
	// 500,000 W for super-heavy cable, up from the game's 25,000 W and 50,000 W. The
	// steps are what one click on the dial adds, and the small step is the same click
	// with the small-increment key held. The game's steps were sized for the old limits:
	// the Medium's 100 W step took 1,000 clicks to reach 100,000 W, so it moves in 500 W
	// now, which gets there in 200.
	//
	// The reversed Medium Transformer is a prefab of its own and needs its own entry.
	// The game's text also lists a StructureTransformerMediumReversed, without the
	// brackets, but the prefab itself goes by the bracketed name.
	private static readonly TransformerLimits[] TRANSFORMER_LIMITS =
	{
		new TransformerLimits("StructureTransformerMedium", 100000f, 500f, 50f),
		new TransformerLimits("StructureTransformerMedium(Reversed)", 100000f, 500f, 50f),
		new TransformerLimits("StructureTransformer", 500000f, 5000f, 500f),
	};

	//// Event Wiring

	[HarmonyPostfix]
	public static void OnCorePrefabsLoaded()
	{
		// Apply the limits
		int raisedCount = 0;
		foreach (TransformerLimits limits in TRANSFORMER_LIMITS)
		{
			// Prefab.Find returns null rather than throwing when a prefab is missing, which
			// happens when a game update renames one. Skipping it with a warning keeps the
			// others working and tells the player why that one did not change.
			Transformer? transformer = Prefab.Find<Transformer>(limits.PrefabName);
			if (transformer == null)
			{
				HigherCapacityTransformersPlugin.Log?.LogWarning($"Could not find the {limits.PrefabName} prefab, so it keeps the game's limits.");
				continue;
			}

			transformer.OutputMaximum = limits.OutputMaximum;
			transformer.StepNormal = limits.StepNormal;
			transformer.StepSmall = limits.StepSmall;
			raisedCount++;
		}

		HigherCapacityTransformersPlugin.Log?.LogInfo($"Raised the output limits of {raisedCount} of {TRANSFORMER_LIMITS.Length} transformers.");
	}
}
