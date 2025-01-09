using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Linq;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{   
    [HarmonyPatch]
    internal class FreeItems : TogglesLoad
    {
        private static Dictionary<string, int> DicNode = new();
        private static int[] ItemInt, VhecInt;

        public override void Update()
        {
            if (BFreeItems)
            {
                foreach (var n in FindAnyObjectByType<Terminal>().terminalNodes.allKeywords.FirstOrDefault(x => x.word == "buy").compatibleNouns)
                {
                    if (!DicNode.ContainsKey(n.noun.name))
                        DicNode[n.noun.name] = n.result.itemCost;
                    n.result.itemCost = 0;
                }

                ItemInt ??= FindAnyObjectByType<Terminal>().buyableItemsList.Select(i => i.creditsWorth).ToArray();
                VhecInt ??= FindAnyObjectByType<Terminal>().buyableVehicles.Select(v => v.creditsWorth).ToArray();

                foreach (var v in FindAnyObjectByType<Terminal>().buyableVehicles) v.creditsWorth = 0;
                foreach (var i in FindAnyObjectByType<Terminal>().buyableItemsList) i.creditsWorth = 0;
            }
            else if (DicNode.Any())
            {
                foreach (var n in FindAnyObjectByType<Terminal>().terminalNodes.allKeywords.FirstOrDefault(x => x.word == "buy").compatibleNouns.Where(n => DicNode.ContainsKey(n.noun.name)))
                    n.result.itemCost = DicNode[n.noun.name];

                for (int i = 0; i < FindAnyObjectByType<Terminal>().buyableItemsList.Length; i++)
                    FindAnyObjectByType<Terminal>().buyableItemsList[i].creditsWorth = ItemInt[i];

                for (int i = 0; i < FindAnyObjectByType<Terminal>().buyableVehicles.Length; i++)
                    FindAnyObjectByType<Terminal>().buyableVehicles[i].creditsWorth = VhecInt[i];

                DicNode.Clear();
                ItemInt = VhecInt = null;
            }
        } 
    
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Terminal), "LoadNewNodeIfAffordable")]
        public static void LoadNewNodeIfAffordablePatch(TerminalNode node) => node.itemCost = BFreeItems ? 0 : node.itemCost;
    }
}
