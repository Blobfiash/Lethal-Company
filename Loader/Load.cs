using SpectralWave.Modules.Visual;
using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using SpectralWave.Utill;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SpectralWave.Loader
{
    public class Loader : MonoBehaviour
    {
        public static GameObject gameObject;

        public static void Load()
        {
            gameObject = new GameObject();
            var comps = new System.Type[]
            {
              typeof(SpectralUI), typeof(HarmonyPatches), typeof(Notis),
               typeof(WaterMark), typeof(TogglesLoad), typeof(Esp)
            };

            foreach (var component in comps) gameObject.AddComponent(component);
            DontDestroyOnLoad(gameObject);

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace?.Contains("SpectralWave.Modules") == true && t.IsSubclassOf(typeof(MonoBehaviour)));

            foreach (var type in types) gameObject.AddComponent(type);
        }
    }
}
