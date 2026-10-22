// SPDX-License-Identifier: GPL-3.0-or-later
// Copyright (C) 2026 aspctt

//// Dependencies

using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace HigherCapacityTransformers;

/// <summary>
/// Mod entry point. StationeersLaunchPad loads the assembly and BepInEx creates this
/// plugin once, which applies every Harmony patch declared in the assembly. The
/// transformer changes themselves live in the patches.
/// </summary>
[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public sealed class HigherCapacityTransformersPlugin : BaseUnityPlugin
{
	//// Constants

	// Also the Harmony instance id. BepInEx tells plugins apart by it, so it stays the
	// same across releases or a new version would load as a different plugin.
	public const string PLUGIN_GUID = "aspctt.highercapacitytransformers";

	// Shown in front of every line this plugin writes to the BepInEx log.
	public const string PLUGIN_NAME = "Higher Capacity Transformers";

	public const string PLUGIN_VERSION = "1.0.0";

	//// References and State

	/// <summary>The plugin's log source, or null before BepInEx has created the plugin.</summary>
	internal static ManualLogSource? Log { get; private set; }

	//// Event Wiring

	// Unity calls this once, when BepInEx adds the plugin to the game
	private void Awake()
	{
		// Share the log source with the patches, which are static and cannot reach it
		Log = Logger;

		// Apply the patches
		// A failed patch leaves the transformers on the game's own values. That is a
		// better outcome than an exception escaping into the loader and taking the mods
		// loaded after this one down with it.
		try
		{
			Harmony harmony = new(PLUGIN_GUID);
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			Logger.LogInfo("Loaded and patched.");
		}
		catch (Exception exception)
		{
			Logger.LogError($"Patching failed, so the transformers keep the game's limits. {exception}");
		}
	}
}
