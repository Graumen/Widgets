using Microsoft.Xna.Framework;
using static Terraria.Main;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;
namespace Widgets
{
    class Mod0 : Mod
    {
        public static bool fj, ftbc, ftbc2, md;
        public static int tft, ft, cap, tit, it, jc;
        public static ModHotKey hk;
        public static Widget[] wl = { new AD(), new BLB(), new FTB(), new HB(), new HD(), new ITB(), new MAD(), new MD(), new PW(), new RTC(), new SD() };
        UserInterface adui = new UserInterface(), blbui = new UserInterface(), ftbui = new UserInterface(), hbui = new UserInterface(), hdui = new UserInterface(), hv = new UserInterface(), itbui = new UserInterface(), madui = new UserInterface(), mdui = new UserInterface(), pwui = new UserInterface(), rtcui = new UserInterface(), sdui = new UserInterface();
        public override void Load()
        {
            adui.SetState(wl[0]);
            blbui.SetState(wl[1]);
            ftbui.SetState(wl[2]);
            hbui.SetState(wl[3]);
            hdui.SetState(wl[4]);
            hk = RegisterHotKey("Positioning Mode", "");
            hv.SetState(new HV());
            itbui.SetState(wl[5]);
            madui.SetState(wl[6]);
            mdui.SetState(wl[7]);
            pwui.SetState(wl[8]);
            rtcui.SetState(wl[9]);
            sdui.SetState(wl[10]);
        }
        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> il)
        {
            int mti = il.FindIndex(_ => _.Name == "Vanilla: Mouse Text");
            var ci = ModContent.GetInstance<Config>();
            var gt = new GameTime();
            var lp = LocalPlayer;
            int cb = lp.CountBuffs();
            int he = (int)SD((lp.statLifeMax2 - lp.statLife) * 100, lp.inventory.Max(_ => _.healLife));
            var pi = ModContent.GetInstance<Positions>();
            var sb = spriteBatch;

            if (-1 < mti)
            {
                il.Insert(mti, new LegacyGameInterfaceLayer("", () =>
                {
                    if (!playerInventory && "Off" != ci.bdv && 0 < cb) Terraria.Utils.DrawBorderString(sb, $"{cb + ("Current Buffs" != ci.bdv ? "/" + lp.buffType.Length : "")}", new Vector2(70 + 418 * ((cb - 1) / 11f - (cb - 1) / 11), 76 + 50 * ((cb - 1) / 11)), ci.bdc);
                    if ((0 < lp.HeldItem.useAmmo && lp.HasAmmo(lp.HeldItem, true) || MP.pm) && ci.adv) adui.Draw(sb, gt);
                    if ("Always" == ci.blbv || "Off" != ci.blbv && (!lp.dead && (0 < lp.breath && lp.breath < lp.breathMax || 0 < lp.lavaTime && lp.lavaTime < lp.lavaMax) || MP.pm)) blbui.Draw(sb, gt);
                    if ("Always" == ci.ftbv || "Off" != ci.ftbv && MP.pm) ftbui.Draw(sb, gt);
                    if (ftbc)
                    {
                        if (!gamePaused && lp.controlJump)
                        {
                            ft++;
                            if (1 < ft) tft++;
                        }
                        ftbui.Draw(sb, gt);
                        if (ftbc2) tft = ft = 0;
                    }
                    else ft = tft = 0;
                    if ((!lp.dead && 100 * lp.statLife / lp.statLifeMax2 <= ci.hbsf || MP.pm) && ci.hbv) hbui.Draw(sb, gt);
                    if ((!(0 < lp.potionDelay || ci.hdsu > cap || lp.dead || lp.noItems || lp.statLife == lp.statLifeMax2) || MP.pm) && ci.hdv) hdui.Draw(sb, gt);
                    if (!lp.dead && "Off" != ci.itbv && lp.immune)
                    {
                        if (!gamePaused)
                        {
                            it++;
                            if (1 < it) tit++;
                        }
                        itbui.Draw(sb, gt);
                    }
                    else it = tit = MP.it = 0;
                    if ("Always" == ci.itbv || "Off" != ci.itbv && MP.pm) itbui.Draw(sb, gt);
                    if ("Always" == ci.madv || "Off" != ci.madv && (0 < lp.HeldItem.mana || MP.pm)) madui.Draw(sb, gt);
                    if (ci.mdv) mdui.Draw(sb, gt);
                    if (MP.pm) pwui.Draw(sb, gt);
                    if (ci.rtcv) rtcui.Draw(sb, gt);
                    if (ci.sdv) sdui.Draw(sb, gt);
                    hv.Draw(sb, gt);
                    return true;
                }, InterfaceScaleType.UI));
            }
            if (!md)
            {
                wl[0].cpx = pi.adx;
                wl[0].cpy = pi.ady;
                wl[1].cpx = pi.blbx;
                wl[1].cpy = pi.blby;
                wl[2].cpx = pi.ftbx;
                wl[2].cpy = pi.ftby;
                wl[3].cpx = pi.hbx;
                wl[3].cpy = pi.hby;
                wl[4].cpx = pi.hdx;
                wl[4].cpy = pi.hdy;
                wl[5].cpx = pi.itbx;
                wl[5].cpy = pi.itby;
                wl[6].cpx = pi.madx;
                wl[6].cpy = pi.mady;
                wl[7].cpx = pi.mdx;
                wl[7].cpy = pi.mdy;
                wl[8].cpx = pi.pwx;
                wl[8].cpy = pi.pwy;
                wl[9].cpx = pi.rtcx;
                wl[9].cpy = pi.rtcy;
                wl[10].cpx = pi.sdx;
                wl[10].cpy = pi.sdy;
            }
            wl[0].ds = !ci.adv;
            wl[0].flw = ci.adf;
            wl[0].TU();
            wl[1].ds = "Off" == ci.blbv;
            wl[1].flw = ci.blbf;
            wl[1].TU();
            cap = 100 < he ? 100 : he;
            wl[2].ds = "Off" == ci.ftbv;
            wl[2].flw = ci.ftbf;
            wl[2].TU();
            ftbc = !((0 < jc && 0 == lp.mount.FlyTime && 0 == lp.wingTime || 0 < lp.wingTime && lp.jumpAgainCloud) && 0 == lp.jump && lp.controlJump) && !lp.dead && !lp.mount.CanHover && !lp.sliding && "Off" != ci.ftbv && (!("Only in Flight, not on first Jump" == ci.ftbv && 0 < lp.jump && fj) || MP.pm) && (!lp.mount.Active && (!lp.canCarpet && 0 < lp.carpetTime && lp.carpet || (0 < lp.rocketBoots && 0 < lp.rocketTime || lp.canCarpet) && lp.rocketRelease || 0 < lp.wingTime) || 0 < jc || 0 < lp.jump || 0 < lp.mount.FlyTime) && 0 != lp.velocity.Y && 0 > lp.grappling[0];
            ftbc2 = !lp.mount.Active && 0 == lp.jump && 0 == lp.rocketTime && 0 == lp.wingTime && lp.canCarpet || 0 < jc && lp.releaseJump;
            wl[3].ds = !ci.hbv;
            wl[3].flw = ci.hbf;
            wl[3].ht = $"{lp.statLife}/{lp.statLifeMax2}";
            wl[3].TU();
            wl[4].ds = !ci.hdv;
            wl[4].flw = ci.hdf;
            wl[4].TU();
            if (lp.releaseJump) fj = false;
            if (0 == lp.velocity.Y || lp.sliding) fj = true;
            il.RemoveAll(_ => _.Name == "Vanilla: Resource Bars");
            wl[5].ds = "Off" == ci.itbv; ;
            wl[5].flw = ci.itbf;
            wl[5].TU();
            jc = new[] { lp.jumpAgainBlizzard, lp.jumpAgainCloud, lp.jumpAgainFart, lp.jumpAgainSail, lp.jumpAgainSandstorm, lp.jumpAgainUnicorn }.Where(_ => _).Count();
            wl[6].ds = "Off" == ci.madv;
            wl[6].flw = ci.madf;
            wl[6].ht = $"{lp.statMana}/{lp.statManaMax2}";
            wl[6].TU();
            wl[7].ds = !ci.mdv;
            wl[7].flw = ci.mdf;
            wl[7].TU();
            wl[8].TU();
            wl[9].ds = !ci.rtcv;
            wl[9].flw = ci.rtcflw;
            wl[9].TU();
            wl[10].ds = !ci.sdv;
            wl[10].flw = ci.sdf;
            wl[10].TU();
        }
        public override void Unload()
        {
            hk = null;
            PW.widget = null;
        }
        public override void UpdateUI(GameTime gt)
        {
            adui?.Update(gt);
            blbui.Update(gt);
            ftbui?.Update(gt);
            hbui?.Update(gt);
            hdui?.Update(gt);
            hv?.Update(gt);
            itbui?.Update(gt);
            madui?.Update(gt);
            mdui?.Update(gt);
            pwui?.Update(gt);
            rtcui?.Update(gt);
            sdui?.Update(gt);
        }
        public static void Save()
        {
            var pi = ModContent.GetInstance<Positions>();

            pi.adx = wl[0].cpx;
            pi.ady = wl[0].cpy;
            pi.blbx = wl[1].cpx;
            pi.blby = wl[1].cpy;
            pi.ftbx = wl[2].cpx;
            pi.ftby = wl[2].cpy;
            pi.hbx = wl[3].cpx;
            pi.hby = wl[3].cpy;
            pi.hdx = wl[4].cpx;
            pi.hdy = wl[4].cpy;
            pi.itbx = wl[5].cpx;
            pi.itby = wl[5].cpy;
            pi.madx = wl[6].cpx;
            pi.mady = wl[6].cpy;
            pi.mdx = wl[7].cpx;
            pi.mdy = wl[7].cpy;
            pi.pwx = wl[8].cpx;
            pi.pwy = wl[8].cpy;
            pi.rtcx = wl[9].cpx;
            pi.rtcy = wl[9].cpy;
            pi.sdx = wl[10].cpx;
            pi.sdy = wl[10].cpy;
        }
        public static float SD(float _, float a) => 0 < a ? _ / a : 0;
    }
}