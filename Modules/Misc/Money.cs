using SpectralWave.TogglesLoadManager;

namespace SpectralWave.Modules.Misc
{
    internal class Money : TogglesLoad
    {
        public static Terminal Terminal;

        public override void Update() => Terminal ??= FindObjectOfType<Terminal>();

        public static void AddMoney() => ChangeMoney(500);
        public static void RemoveMoney() => ChangeMoney(-500);

        private static void ChangeMoney(int amount)
        {
            if (Terminal != null)
            {
                Terminal.groupCredits += amount;
                Terminal.SyncGroupCreditsServerRpc(Terminal.groupCredits, Terminal.numberOfItemsInDropship);
            }
        }
    }
}
