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
        public static int cap, ft, it, jc, tft, tit;
        public static ModHotKey hk;
        public static Widget[] wl = { new AD(), new BLB(), new FTB(), new HB(), new HD(), new ITB(), new MAD(), new MD(), new PW(), new RTC(), new SD() };
        UserInterface adui = new UserInterface(), blbui = new UserInterface(), ftbui = new UserInterface(), hbui = new UserInterface(), hdui = new UserInterface(), hv = new UserInterface(), itbui = new UserInterface(), madui = new UserInterface(), mdui = new UserInterface(), pwui = new UserInterface(), rtcui = new UserInterface(), sdui = new UserInterface();
        public override void Load()
        {
            foreach (var _ in wl)
            {
                _.Height.Set(0, 0);
                _.Width.Set(0, 0);
            }
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
                    if ((0 < lp.HeldItem.useAmmo && lp.HasAmmo(lp.HeldItem, true) || MP.pm) && ci.adv)
                    {
                        adui.Draw(sb, gt);
                        wl[0].drawn = true;
                    }
                    else wl[0].drawn = false;
                    if ("Always" == ci.blbv || "Off" != ci.blbv && (!lp.dead && (0 < lp.breath && lp.breath < lp.breathMax || 0 < lp.lavaTime && lp.lavaTime < lp.lavaMax) || MP.pm))
                    {
                        blbui.Draw(sb, gt);
                        wl[1].drawn = true;
                    }
                    else wl[1].drawn = false;
                    if (ftbc)
                    {
                        if (!gamePaused && lp.controlJump)
                        {
                            ft++;
                            if (1 < ft) tft++;
                        }
                        ftbui.Draw(sb, gt);
                        if (ftbc2) tft = ft = 0;
                        wl[2].drawn = true;
                    }
                    else
                    {
                        ft = tft = 0;
                        wl[2].drawn = false;
                    }
                    if ("Always" == ci.ftbv || "Off" != ci.ftbv && MP.pm)
                    {
                        ftbui.Draw(sb, gt);
                        wl[2].drawn = true;
                    }
                    else wl[2].drawn = false;
                    if ((!lp.dead && 100 * lp.statLife / lp.statLifeMax2 <= ci.hbsf || MP.pm) && ci.hbv)
                    {
                        hbui.Draw(sb, gt);
                        wl[3].drawn = true;
                    }
                    else wl[3].drawn = false;
                    if ((!(0 < lp.potionDelay || cap < ci.hdsu || lp.dead || lp.noItems || lp.statLife == lp.statLifeMax2) || MP.pm) && ci.hdv)
                    {
                        hdui.Draw(sb, gt);
                        wl[4].drawn = true;
                    }
                    else wl[4].drawn = false;
                    if (!lp.dead && "Off" != ci.itbv && lp.immune)
                    {
                        if (!gamePaused)
                        {
                            it++;
                            if (1 < it) tit++;
                        }
                        itbui.Draw(sb, gt);
                        wl[5].drawn = true;
                    }
                    else
                    {
                        it = tit = MP.it = 0;
                        wl[5].drawn = false;
                    }
                    if ("Always" == ci.itbv || "Off" != ci.itbv && MP.pm)
                    {
                        itbui.Draw(sb, gt);
                        wl[5].drawn = true;
                    }
                    else wl[5].drawn = false;
                    if ("Always" == ci.madv || "Off" != ci.madv && (0 < lp.HeldItem.mana || MP.pm))
                    {
                        madui.Draw(sb, gt);
                        wl[6].drawn = true;
                    }
                    else wl[6].drawn = false;
                    if (ci.mdv)
                    {
                        mdui.Draw(sb, gt);
                        wl[7].drawn = true;
                    }
                    else wl[7].drawn = false;
                    if (MP.pm)
                    {
                        pwui.Draw(sb, gt);
                        wl[8].drawn = true;
                    }
                    else wl[8].drawn = false;
                    if (ci.rtcv)
                    {
                        rtcui.Draw(sb, gt);
                        wl[9].drawn = true;
                    }
                    else wl[9].drawn = false;
                    if (ci.sdv)
                    {
                        sdui.Draw(sb, gt);
                        wl[10].drawn = true;
                    }
                    else wl[10].drawn = false;
                    hv.Draw(sb, gt);
                    return true;
                }, InterfaceScaleType.UI));
            }
            if (!md)
            {
                wl[0].cx = pi.adx;
                wl[0].cy = pi.ady;
                wl[1].cx = pi.blbx;
                wl[1].cy = pi.blby;
                wl[2].cx = pi.ftbx;
                wl[2].cy = pi.ftby;
                wl[3].cx = pi.hbx;
                wl[3].cy = pi.hby;
                wl[4].cx = pi.hdx;
                wl[4].cy = pi.hdy;
                wl[5].cx = pi.itbx;
                wl[5].cy = pi.itby;
                wl[6].cx = pi.madx;
                wl[6].cy = pi.mady;
                wl[7].cx = pi.mdx;
                wl[7].cy = pi.mdy;
                wl[8].cx = pi.pwx;
                wl[8].cy = pi.pwy;
                wl[9].cx = pi.rtcx;
                wl[9].cy = pi.rtcy;
                wl[10].cx = pi.sdx;
                wl[10].cy = pi.sdy;
            }
            cap = 100 < he ? 100 : he;
            foreach (var _ in wl) _.TU();
            ftbc = !((0 < jc && 0 == lp.mount.FlyTime && 0 == lp.wingTime || 0 < lp.wingTime && lp.jumpAgainCloud) && 0 == lp.jump && lp.controlJump) && !lp.dead && !lp.mount.CanHover && !lp.sliding && "Off" != ci.ftbv && (!("Only in Flight, not on first Jump" == ci.ftbv && 0 < lp.jump && fj) || MP.pm) && (!lp.mount.Active && (!lp.canCarpet && 0 < lp.carpetTime && lp.carpet || (0 < lp.rocketBoots && 0 < lp.rocketTime || lp.canCarpet) && lp.rocketRelease || 0 < lp.wingTime) || 0 < jc || 0 < lp.jump || 0 < lp.mount.FlyTime) && 0 != lp.velocity.Y && 0 > lp.grappling[0];
            ftbc2 = !lp.mount.Active && 0 == lp.jump && 0 == lp.rocketTime && 0 == lp.wingTime && lp.canCarpet || 0 < jc && lp.releaseJump;
            if (lp.releaseJump) fj = false;
            if (0 == lp.velocity.Y || lp.sliding) fj = true;
            il.RemoveAll(_ => _.Name == "Vanilla: Resource Bars");
            jc = new[] { lp.jumpAgainBlizzard, lp.jumpAgainCloud, lp.jumpAgainFart, lp.jumpAgainSail, lp.jumpAgainSandstorm, lp.jumpAgainUnicorn }.Where(_ => _).Count();
            wl[0].ds = !ci.adv;
            wl[0].flw = ci.adf;
            wl[1].ds = "Off" == ci.blbv;
            wl[1].flw = ci.blbf;
            wl[10].ds = !ci.sdv;
            wl[10].flw = ci.sdf;
            wl[2].ds = "Off" == ci.ftbv;
            wl[2].flw = ci.ftbf;
            wl[3].ds = !ci.hbv;
            wl[3].flw = ci.hbf;
            wl[3].ht = $"{lp.statLife}/{lp.statLifeMax2}";
            wl[4].ds = !ci.hdv;
            wl[4].flw = ci.hdf;
            wl[5].ds = "Off" == ci.itbv; ;
            wl[5].flw = ci.itbf;
            wl[6].ds = "Off" == ci.madv;
            wl[6].flw = ci.madf;
            wl[6].ht = $"{lp.statMana}/{lp.statManaMax2}";
            wl[7].ds = !ci.mdv;
            wl[7].flw = ci.mdf;
            wl[9].ds = !ci.rtcv;
            wl[9].flw = ci.rtcflw;
        }
        public override void Unload()
        {
            hk = null;
            PW.widget = null;
        }
        public override void UpdateUI(GameTime gt)
        {
            adui?.Update(gt);
            blbui?.Update(gt);
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

            pi.adx = wl[0].x;
            pi.ady = wl[0].y;
            pi.blbx = wl[1].x;
            pi.blby = wl[1].y;
            pi.ftbx = wl[2].x;
            pi.ftby = wl[2].y;
            pi.hbx = wl[3].x;
            pi.hby = wl[3].y;
            pi.hdx = wl[4].x;
            pi.hdy = wl[4].y;
            pi.itbx = wl[5].x;
            pi.itby = wl[5].y;
            pi.madx = wl[6].x;
            pi.mady = wl[6].y;
            pi.mdx = wl[7].x;
            pi.mdy = wl[7].y;
            pi.pwx = wl[8].x;
            pi.pwy = wl[8].y;
            pi.rtcx = wl[9].x;
            pi.rtcy = wl[9].y;
            pi.sdx = wl[10].x;
            pi.sdy = wl[10].y;
        }
        public static float SD(float _, float a) => 0 < a ? _ / a : 0;
    }
}