using GameNetcodeStuff;
using SpectralWave.Modules.Misc;
using SpectralWave.Modules.Player;
using SpectralWave.Modules.Utill;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using System;
using System.Collections.Generic;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;
using static SpectralWave.UI.Managment.GUIButtons;

namespace SpectralWave.UI
{
    public class SpectralUI : MonoBehaviour
    {
        private int SelectiveTab = 0;

        public Rect windowRect = new Rect(50f, 50f, 700f, 450f);
        public Rect tabRect = new Rect(10, 45, 130, 350f);
        private Rect TabSliding;

        public string[] Tabs = new string[] { "Logs", "Visual", "Misc", "Player", "Items", "Settings" };

        // Textures
        private Texture2D BcTexture;
        private Texture2D backgroundTexture;
        public static Texture2D guibackground;
        public static Texture2D normalbuttonTexture;
        public static Texture2D activebuttonTexture;
        public static Texture2D hoverbuttonTexture;
        private Texture2D SelectedTexture;
        private Texture2D UnSelectedTexture;
        public static Texture2D SliderBcTexture;
        public static Texture2D SliderTexture;
        public static Texture2D normalToggleTexture;
        public static Texture2D hoverToggleTexture;
        public static Texture2D activeToggleTexture;
        public static Texture2D ToggleButtons;
        public static Texture2D TogglesAndButtons;
        private static Texture2D CatagTexture;
        private static Texture2D HeaderTexture;
        public static Texture2D SectionTexture;
        public static Texture2D SectionL;
        public static Texture2D DropDownTexture;
        public static Texture2D SlidingTexture;
        public static Texture2D BoxTexture;

        // Styles
        public static GUIStyle sliderStyle;
        public static GUIStyle thumbStyle;
        public static GUIStyle tabStylebase;
        public static GUIStyle tabSelected;
        private GUIStyle guistyle;
        public static GUIStyle Boxstyle;

        public static List<TogglesLoad> TogglesLoad;

        public static PlayerControllerB PlayerB;
        private void Start()
        {
            TogglesAndButtons = DrawTexture.CreateTex(390, 39, new Color32(94, 93, 92, 100)); 
            ToggleButtons = DrawTexture.CreateTex(240, 30, new Color(0.9f, 0.9f, 0.9f)); 
            SectionL = DrawTexture.CreateTex(220, 4, new Color32(254, 254, 254, byte.MaxValue)); 
            BcTexture = backgroundTexture = DrawTexture.CreateTex(256, 64, new Color(0.9f, 0.9f, 0.9f)); 
            SelectedTexture = DrawTexture.CreateTex(35, 125, new Color32(70, 70, 70, 100)); 
            UnSelectedTexture = DrawTexture.CreateTex(35, 125, new Color32(33, 33, 33, 0)); 
            CatagTexture = HeaderTexture = DrawTexture.CreateTex(120, 24, new Color32(50, 50, 50, byte.MaxValue)); 
            DropDownTexture = DrawTexture.CreateTex(390, 39, new Color32(50, 50, 50, 100)); 
            normalbuttonTexture = hoverbuttonTexture = activebuttonTexture = DrawTexture.CreateTex(26, 26, new Color32(50, 50, 50, byte.MaxValue)); 
            normalToggleTexture = hoverToggleTexture = activeToggleTexture = DrawTexture.CreateTex(26, 26, new Color32(67, 135, 245, byte.MaxValue));

            guibackground = DrawTexture.CreateTex(600, 450, new Color32(33, 33, 33, 240));
            BoxTexture = DrawTexture.CreateTex(300, 300, new Color32(94, 93, 92, 100));

            SliderTexture = DrawTexture.CreateTex((int)SlideWidth, 18, new Color32(210, 210, 210, 200)); 
            SliderBcTexture = DrawTexture.CreateTex((int)SlideWidth, 18, new Color32(81, 82, 82, 200)); 
            SlidingTexture = DrawTexture.CreateTex(3, 35, new Color32(48, 127, 255, 120)); 
            SectionTexture = DrawTexture.CreateTex(240, 280, new Color32(63, 33, 44, 200)); 
            TabSliding = new Rect(tabRect.x, tabRect.y + 5, 3, 35); 

        }
        private void OnGUI()
        {
            tabStylebase = new GUIStyle(GUI.skin.button) { normal = { background = UnSelectedTexture }, hover = { background = UnSelectedTexture }, active = { background = UnSelectedTexture } };
            tabSelected = new GUIStyle(GUI.skin.button) { normal = { background = SelectedTexture }, hover = { background = SelectedTexture }, active = { background = SelectedTexture } };

            sliderStyle = new GUIStyle(GUI.skin.horizontalSlider) { normal = { background = backgroundTexture }, active = { background = backgroundTexture }, hover = { background = backgroundTexture } };
            thumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb) { normal = { background = BcTexture }, active = { background = BcTexture }, hover = { background = BcTexture } };

            Boxstyle = new GUIStyle(GUI.skin.box)
            {
                normal = { background = BoxTexture },
                active = { background = BoxTexture },
                hover = { background = BoxTexture },
                focused = { background = BoxTexture },
                onNormal = { background = BoxTexture },
                onActive = { background = BoxTexture },
                onHover = { background = BoxTexture },
                onFocused = { background = BoxTexture }
            };

            guistyle = new GUIStyle(GUI.skin.window)
            {
                /* doing null so drawtexture can takeover */
                normal = { background = null },
                active = { background = null },
                hover = { background = null },
                focused = { background = null },
                onNormal = { background = null },
                onActive = { background = null },
                onHover = { background = null },
                onFocused = { background = null }
            };

            if (ToggleGui.Open)
            {
                DrawTexture.DrawTextureRounded(windowRect, guibackground, ScaleMode.StretchToFill, true, 1.0f, Color.white, Vector4.zero, new Vector4(26, 26, 26, 26));
                windowRect = GUI.Window(0, windowRect, Wind, "", guistyle);
            }
        }
        private void Wind(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, windowRect.width, 20));
            GUI.Label(new Rect(20, 10, 400, 400), "<size=16><b>SpectralWave</b></size>");

            GUILayout.BeginArea(tabRect);
            for (int i = 0; i < Tabs.Length; i++)
                if (GUILayout.Button(Tabs[i], SelectiveTab == i ? tabSelected : tabStylebase, GUILayout.Height(35), GUILayout.Width(125))) SelectiveTab = i;
            GUILayout.EndArea();

            TabSliding.y = Mathf.Lerp(TabSliding.y, tabRect.y + SelectiveTab * 35, Time.deltaTime * 5);
            GUI.DrawTexture(new Rect(TabSliding.x, TabSliding.y - 0.2f, TabSliding.width, TabSliding.height - 3), SlidingTexture);

            switch (SelectiveTab) { case 0: LogsTab(); break; case 1: VisualModTab(); break; case 2: MiscTab(); break; case 3: PlayerTab(); break; case 4: ItemListTab(); break; case 5: SettingsTab(); break; }
        }
        private void LogsTab()
        {
            CreateBox("testing", () =>
            {
                CreateToggle(false, "gkjidfgjf");
                CreateButton("dgfjh", HostOptions.EjectAll);
            });
            CreateRightBox("testing", () =>
            {
                CreateSlider(ref FFovValue, 66f, 146f, "Fov Value");
            });
        }
        private void SettingsTab()
        {
            CreateBox("Settings", () =>
            {
                CreateButton("Save Configs", ToggleManager.SaveConfig.Save);
                CreateButton("Load Configs", ToggleManager.SaveConfig.Load);
            });
        }
        private Vector2 V_VisualScroll = Vector2.zero;

        public void VisualModTab()
        {
            CreateBox("Visual", () =>
            {
                V_VisualScroll = GUILayout.BeginScrollView(V_VisualScroll, false, false, GUIStyle.none, GUIStyle.none);
                BNightVision = CreateToggle(BNightVision, "Night Vision");
                BFov = CreateToggle(BFov, "Fov");
                BNoFog = CreateToggle(BNoFog, "Clear Fog");
                BClearVisor = CreateToggle(BClearVisor, "Clear Visor");
                BShowClock = CreateToggle(BShowClock, "Keep Showing Clock");
                BNoFlashBang = CreateToggle(BNoFlashBang, "No Flashbang");
                BEnemyEsp = CreateToggle(BEnemyEsp, "Enemy Esp");
                BPlayersEsp = CreateToggle(BPlayersEsp, "Players Esp");
                BScrapEsp = CreateToggle(BScrapEsp, "Scrap Esp");
                GUILayout.EndScrollView();  
            });
            CreateRightBox("Settings", delegate
            {
                CreateSlider(ref FFovValue, 66f, 146f, "Fov Value");
            });
        }

        private Vector2 V_MiscScroll = Vector2.zero;

        public void MiscTab()
        {
            if (!StartOfRound.Instance)
            {
                GUILayout.Space(30);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                CreateLabel("JOIN OR HOST TO SEE");
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            else
            {
                CreateBox("Misc", () =>
                {
                    V_MiscScroll = GUILayout.BeginScrollView(V_MiscScroll, false, false, GUIStyle.none, GUIStyle.none);
                    BCanBuild = CreateToggle(BCanBuild, "Can Build");
                    BNotifyDeath = CreateToggle(BNotifyDeath, "Notify Death");
                    BInfItems = CreateToggle(BInfItems, "Inf Items");
                    BUnlockDoor = CreateToggle(BUnlockDoor, "Free Key(Click E)");
                    BInfScanRange = CreateToggle(BInfScanRange, "Inf Scan Range");
                    BFreeItems = CreateToggle(BFreeItems, "Free Items");
                    BNeverLoseScrap = CreateToggle(BNeverLoseScrap, "Never Lose Scrap");
                    BInvisibleToEnemys = CreateToggle(BInvisibleToEnemys, "Invisible To Enemies");
                    CreateButton("Unlock All", Doors.UnlockAll);
                    CreateButton("Tp To Entrance", Doors.TpEntrance);
                    CreateButton("Berserk Turrets", Turrets.BerserkTurrets);
                    CreateButton("Put All Items On Desk", Items.PutAllOnDesk);
                    CreateButton("Start Game", StartOfRound.Instance.StartGameServerRpc);
                    CreateButton("End Game", () => StartOfRound.Instance.EndGameServerRpc(0));
                    CreateButton("AddMoney", Money.AddMoney);
                    CreateButton("Remove Money", Money.RemoveMoney);
                    CreateButton("Kill All Enemies", EnemysMain.KillAllEnemys);
                    CreateButton("Kill All", PlayersOptions.KillAll);
                    CreateButton("Damage All", PlayersOptions.DamageAll);
                    CreateButton("Heal All", PlayersOptions.HealAll);
                    GUILayout.Space(3.8f);
                    foreach (var x in StartOfRound.Instance.levels) CreateButton($"{x.PlanetName}: {x.currentWeather}", () => Moons.Moon(x.levelID));
                    CreateButton("Spawn Turret", HostOptions.SpawnTurret);
                    CreateButton("Spawn More Scrap", HostOptions.SpawnMoreScrap);
                    CreateButton("Eject All", HostOptions.EjectAll);
                    GUILayout.EndScrollView();
                });
            }
        }

        private Vector2 V_PlayerScroll = Vector2.zero;
        public void PlayerTab()
        {
            CreateBox("Player", () =>
            {
                V_PlayerScroll = GUILayout.BeginScrollView(V_PlayerScroll, false, false, GUIStyle.none, GUIStyle.none);
                BGodMode = CreateToggle(BGodMode, "GodMode");
                BInfStamina = CreateToggle(BInfStamina, "Inf Stamina");
                BSpeedBoost = CreateToggle(BSpeedBoost, "Speed Boost");
                BFasterClimb = CreateToggle(BFasterClimb, "Faster Climb");
                BNoClip = CreateToggle(BNoClip, "NoClip");
                BHighJump = CreateToggle(BHighJump, "High Jump");
                BInfJump = CreateToggle(BInfJump, "Inf Jump");
                BReach = CreateToggle(BReach, "Reach");
                BNoWeight = CreateToggle(BNoWeight, "No Weight");
                BOneHandItems = CreateToggle(BOneHandItems, "One Hand Items");
                BInfAmmo = CreateToggle(BInfAmmo, "Inf Ammo");
                BInfBattery = CreateToggle(BInfBattery, "Inf Battery");
                BSuperDamage = CreateToggle(BSuperDamage, "Super Damage");
                BInstantInteract = CreateToggle(BInstantInteract, "Instant Interact");
                BNoCoolDown = CreateToggle(BNoCoolDown, "No CoolDowns");
                BNeverInsane = CreateToggle(BNeverInsane, "Never Go Insane");
                BInvisPlayer = CreateToggle(BInvisPlayer, "Invis Player");

                GUILayout.EndScrollView();
            });
            CreateRightBox("Settings", () =>
            {
                CreateSlider(ref Speed.FSpeedV, 5.7f, 45f, "Speed Value");
                CreateSlider(ref FHighJump, 13f, 57f, "Jump Value");
            });
        }
        private Vector2 V_ItemScroll = Vector2.zero;
        public void ItemListTab()
        {
            CreateLeftBox("Items", () =>
            {
                V_ItemScroll = GUILayout.BeginScrollView(V_ItemScroll, false, false, GUIStyle.none, GUIStyle.none);

                CreateButton("Tp All Items", Items.TpItems);

                foreach (Items.Unlockable unlockable in Enum.GetValues(typeof(Items.Unlockable)))
                {
                    CreateButton($"Unlock {unlockable}", () =>
                    {
                        Items.HandleItem(unlockable, unlock: true);
                    });
                }

                GUILayout.EndScrollView();
            });
        }
        public static void Update()
        {
            PlayerB = GameNetworkManager.Instance?.localPlayerController;
            if (StartOfRound.Instance == true)
            {
                TogglesLoad.ForEach(t => t.Update());
            }
        }
        public static void FixedUpdate() => TogglesLoad.ForEach(t => t.FixedUpdate());

    }

}