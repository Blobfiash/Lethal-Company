using System;
using System.Reflection;
using UnityEngine;

namespace SpectralWave.Utill
{
    internal class OvrMethod
    {
        public static void OvrMeth<T>(string methodName, Delegate newMethodCode)
        {
            var methodInfo = typeof(T).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (methodInfo == null) { Debug.LogError($"Method {methodName} not found."); return; }

            if (newMethodCode.Method.ReturnType == typeof(void))
                newMethodCode.DynamicInvoke();
            else
                Debug.Log($"Replaced result: {newMethodCode.DynamicInvoke()}");
        }
    }
}
