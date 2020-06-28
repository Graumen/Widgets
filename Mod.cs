using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using static Terraria.Main;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;
namespace Widgets
{
    class Mod0 : Mod
    {
        public static bool f0, f1, f2;
        public static int f3, f4, f5, f6, f7, f8;
        public static ModHotKey f9;
        static AD f10 = new AD();
        static BLB f11 = new BLB();
        static FTB f12 = new FTB();
        static HB f13 = new HB();
        static HD f14 = new HD();
        static ITB f15 = new ITB();
        static MAD f16 = new MAD();
        static MD f17 = new MD();
        static PW f18 = new PW();
        static RTC f19 = new RTC();
        static SD f20 = new SD();
        UserInterface f21 = new UserInterface(), f22 = new UserInterface(), f23 = new UserInterface(), f24 = new UserInterface(), f25 = new UserInterface(), f26 = new UserInterface(), f27 = new UserInterface(), f28 = new UserInterface(), f29 = new UserInterface(), f30 = new UserInterface(), f31 = new UserInterface(), f32 = new UserInterface();
        public override void Load()
        {
            var f33 = ModContent.GetInstance<Positions>();

            f10.f9 = f33.f0;
            f21.SetState(f10);
            f11.f9 = f33.f1;
            f22.SetState(f11);
            f12.f9 = f33.f2;
            f23.SetState(f12);
            f13.f9 = f33.f3;
            f24.SetState(f13);
            f14.f9 = f33.f4;
            f25.SetState(f14);
            f15.f9 = f33.f5;
            f26.SetState(f15);
            f16.f9 = f33.f6;
            f27.SetState(f16);
            f17.f9 = f33.f7;
            f28.SetState(f17);
            f9 = RegisterHotKey("Positioning Mode", "");
            f18.f9 = f33.f8;
            f29.SetState(f18);
            f19.f9 = f33.f9;
            f30.SetState(f19);
            f31.SetState(new RV());
            f20.f9 = f33.f10;
            f32.SetState(f20);
        }
        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> a0)
        {
            int f34 = a0.FindIndex(_ => _.Name == "Vanilla: Mouse Text");
            var f35 = ModContent.GetInstance<Config>();
            var f36 = new GameTime();
            var f37 = LocalPlayer;
            int f38 = f37.CountBuffs();
            int f39 = (int)SD((f37.statLifeMax2 - f37.statLife) * 100, f37.inventory.Max(_ => _.healLife));
            var f40 = spriteBatch;

            if (-1 < f34)
            {
                a0.Insert(f34, new LegacyGameInterfaceLayer("", () =>
                {
                    if (!playerInventory && "Off" != f35.f12 && 0 < f38) Terraria.Utils.DrawBorderString(f40, $"{f38 + ("Current Buffs" != f35.f12 ? "/" + f37.buffType.Length : "")}", new Vector2(70 + 418 * ((f38 - 1) / 11f - (f38 - 1) / 11), 76 + 50 * ((f38 - 1) / 11)), f35.f13);
                    if ((0 < f37.HeldItem.useAmmo && f37.HasAmmo(f37.HeldItem, true) || ModPlayer.f1) && f35.f0) f21.Draw(f40, f36);
                    if ("Always" == f35.f3 || "Off" != f35.f3 && (!f37.dead && (0 < f37.breath && f37.breath < f37.breathMax || 0 < f37.lavaTime && f37.lavaTime < f37.lavaMax) || ModPlayer.f1)) f22.Draw(f40, f36);
                    if ("Always" == f35.f14 || "Off" != f35.f14 && ModPlayer.f1) f23.Draw(f40, f36);
                    if (f1)
                    {
                        if (!gamePaused && f37.controlJump)
                        {
                            f4++;
                            if (1 < f4) f3++;
                        }
                        f23.Draw(f40, f36);
                        if (f2) f3 = f4 = 0;
                    }
                    else f3 = f4 = 0;
                    if ((!f37.dead && 100 * f37.statLife / f37.statLifeMax2 <= f35.f25 || ModPlayer.f1) && f35.f24) f24.Draw(f40, f36);
                    if ((!(0 < f37.potionDelay || f35.f21 > f5 || f37.dead || f37.noItems || f37.statLife == f37.statLifeMax2) || ModPlayer.f1) && f35.f20) f25.Draw(f40, f36);
                    if (!f37.dead && "Off" != f35.f31 && f37.immune)
                    {
                        if (!gamePaused)
                        {
                            f7++;
                            if (1 < f7) f6++;
                        }
                        f26.Draw(f40, f36);
                    }
                    else f6 = f7 = ModPlayer.f4 = 0;
                    if ("Always" == f35.f31 || "Off" != f35.f31 && ModPlayer.f1) f26.Draw(f40, f36);
                    if ("Always" == f35.f37 || "Off" != f35.f37 && (0 < f37.HeldItem.mana || ModPlayer.f1)) f27.Draw(f40, f36);
                    if (f35.f44) f28.Draw(f40, f36);
                    if (ModPlayer.f1) f29.Draw(f40, f36);
                    if (f35.f49) f30.Draw(f40, f36);
                    if (f35.f54) f32.Draw(f40, f36);
                    f31.Draw(f40, f36);
                    return true;
                }, InterfaceScaleType.UI));
            }
            f10.f3 = !f35.f0;
            f10.f4 = f35.f1;
            f10.TU();
            f11.f3 = "Off" == f35.f3;
            f11.f4 = f35.f4;
            f11.TU();
            f12.f3 = "Off" == f35.f14;
            f12.f4 = f35.f15;
            f12.TU();
            f1 = !((0 < f8 && 0 == f37.mount.FlyTime && 0 == f37.wingTime || 0 < f37.wingTime && f37.jumpAgainCloud) && 0 == f37.jump && f37.controlJump) && !f37.dead && !f37.mount.CanHover && !f37.sliding && "Off" != f35.f14 && (!("Only in Flight, not on first Jump" == f35.f14 && 0 < f37.jump && f0) || ModPlayer.f1) && (!f37.mount.Active && (!f37.canCarpet && 0 < f37.carpetTime && f37.carpet || (0 < f37.rocketBoots && 0 < f37.rocketTime || f37.canCarpet) && f37.rocketRelease || 0 < f37.wingTime) || 0 < f8 || 0 < f37.jump || 0 < f37.mount.FlyTime) && 0 != f37.velocity.Y && 0 > f37.grappling[0];
            f2 = !f37.mount.Active && 0 == f37.jump && 0 == f37.rocketTime && 0 == f37.wingTime && f37.canCarpet || 0 < f8 && f37.releaseJump;
            f13.f3 = !f35.f24;
            f13.f4 = f35.f26;
            f13.f6 = $"{f37.statLife}/{f37.statLifeMax2}";
            f13.TU();
            f14.f3 = !f35.f20;
            f14.f4 = f35.f22;
            f14.TU();
            f5 = 100 < f39 ? 100 : f39;
            if (f37.releaseJump) f0 = false;
            if (0 == f37.velocity.Y || f37.sliding) f0 = true;
            a0.RemoveAll(_ => _.Name == "Vanilla: Resource Bars");
            f15.f3 = "Off" == f35.f31; ;
            f15.f4 = f35.f32;
            f15.TU();
            f8 = new[] { f37.jumpAgainBlizzard, f37.jumpAgainCloud, f37.jumpAgainFart, f37.jumpAgainSail, f37.jumpAgainSandstorm, f37.jumpAgainUnicorn }.Where(_ => _).Count();
            f16.f3 = "Off" == f35.f37;
            f16.f4 = f35.f38;
            f16.f6 = $"{f37.statMana}/{f37.statManaMax2}";
            f16.TU();
            f17.f3 = !f35.f44;
            f17.f4 = f35.f45;
            f17.TU();
            f18.TU();
            f19.f3 = !f35.f49;
            f19.f4 = f35.f50;
            f19.TU();
            f20.f3 = !f35.f54;
            f20.f4 = f35.f55;
            f20.TU();
        }
        public override void UpdateUI(GameTime a0)
        {
            f21?.Update(a0);
            f22.Update(a0);
            f23?.Update(a0);
            f24?.Update(a0);
            f25?.Update(a0);
            f26?.Update(a0);
            f27?.Update(a0);
            f28?.Update(a0);
            f29?.Update(a0);
            f30?.Update(a0);
            f31.Update(a0);
            f32?.Update(a0);
        }
        public static float SD(float a1, float a2) => 0 < a2 ? a1 / a2 : 0;
        public static void Save()
        {
            var f0 = ModContent.GetInstance<Positions>();

            f0.f0 = f10.f9;
            f0.f1 = f11.f9;
            f0.f2 = f12.f9;
            f0.f3 = f13.f9;
            f0.f4 = f14.f9;
            f0.f5 = f15.f9;
            f0.f6 = f16.f9;
            f0.f7 = f17.f9;
            f0.f8 = f18.f9;
            f0.f9 = f19.f9;
            f0.f10 = f20.f9;
            System.IO.File.WriteAllText(Terraria.ModLoader.Config.ConfigManager.ModConfigPath + "/Widgets_Positions.json", JsonConvert.SerializeObject(f0, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}