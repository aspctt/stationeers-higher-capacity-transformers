using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherCapacityTransformers
{
    [HarmonyPatch(typeof(Prefab), "LoadCorePrefabs")]
    public class AddStructureIntoKit
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            Transformer MediumTransformerReversed = Prefab.Find<Transformer>("StructureTransformerMedium(Reversed)");
            Transformer MediumTransformer = Prefab.Find<Transformer>("StructureTransformerMedium");
            Transformer LargeTransformer = Prefab.Find<Transformer>("StructureTransformer");

            if (MediumTransformer != null)
            {
                MediumTransformer.OutputMaximum = 100000f;
            }

            if (MediumTransformerReversed != null)
            {
                MediumTransformerReversed.OutputMaximum = 100000f;
            }

            if (LargeTransformer != null)
            {
                LargeTransformer.OutputMaximum = 500000f;
                LargeTransformer.StepNormal = 5000f;
                LargeTransformer.StepSmall = 500f;
            }
        }
    }
}
