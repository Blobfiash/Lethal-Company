using System;
using System.Reflection;
using UnityEngine;
using SpectralWave.TogglesLoadManager;
using GameNetcodeStuff;
using System.Reflection.Emit;

namespace SpectralWave.Modules.Misc
{
    internal class Test : TogglesLoad
    {
        private void OvrMethod()
        {
            var meth = typeof(EnemyAI).GetMethod("PlayerIsTargetable", BindingFlags.Public | BindingFlags.Instance);
            if (meth != null)
            {
                var dynMethod = new DynamicMethod("PlayerIsTargetable_Replacement", typeof(bool), new[] { typeof(PlayerControllerB), typeof(bool), typeof(bool) });
                var ilGen = dynMethod.GetILGenerator();
                ilGen.Emit(OpCodes.Ldc_I4_0);
                ilGen.Emit(OpCodes.Ret);
                meth.CreateDelegate(typeof(Func<PlayerControllerB, bool, bool, bool>), dynMethod);
            }
        }
    }
}
