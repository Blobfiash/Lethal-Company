using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class SuperDamage : TogglesLoad
    {
        public static Shovel Shovel;
        public static KnifeItem Knife;

        public override void Update()
        {
            if (Shovel == null) Shovel = FindObjectOfType<Shovel>();
            if (Knife == null) Knife = FindObjectOfType<KnifeItem>();

            if (BSuperDamage && Shovel != null || BSuperDamage && Knife != null)
            {
                Shovel.shovelHitForce = int.MaxValue;
                Knife.knifeHitForce = int.MaxValue;
            }
        }
    }
}
