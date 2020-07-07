using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using static Terraria.Main;
using System.IO;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;
namespace Widgets
{
    class Mod0 : Mod
    {
        public static bool fj, ftbc, ftbc2;
        public static int tft, ft, cap, tit, it, jc;
        public static ModHotKey hk;
        static AD ad = new AD();
        static BLB blb = new BLB();
        static FTB ftb = new FTB();
        static HB hb = new HB();
        static HD hd = new HD();
        static ITB itb = new ITB();
        static MAD mad = new MAD();
        static MD md = new MD();
        static PW pw = new PW();
        static RTC rtc = new RTC();
        static SD sd = new SD();
        UserInterface adui = new UserInterface(), blbui = new UserInterface(), ftbui = new UserInterface(), hbui = new UserInterface(), hdui = new UserInterface(), hv = new UserInterface(), itbui = new UserInterface(), madui = new UserInterface(), mdui = new UserInterface(), pwui = new UserInterface(), rtcui = new UserInterface(), sdui = new UserInterface();
        public override void Load()
        {
            var pi = ModContent.GetInstance<Positions>();

            ad.cp = pi.ad;
            adui.SetState(ad);
            blb.cp = pi.blb;
            blbui.SetState(blb);
            ftb.cp = pi.ftb;
            ftbui.SetState(ftb);
            hb.cp = pi.hb;
            hbui.SetState(hb);
            hd.cp = pi.hd;
            hdui.SetState(hd);
            hk = RegisterHotKey("Positioning Mode", "");
            hv.SetState(new HV());
            itb.cp = pi.itb;
            itbui.SetState(itb);
            mad.cp = pi.mad;
            madui.SetState(mad);
            md.cp = pi.md;
            mdui.SetState(md);
            pw.cp = pi.pw;
            pwui.SetState(pw);
            rtc.cp = pi.rtc;
            rtcui.SetState(rtc);
            sd.cp = pi.sd;
            sdui.SetState(sd);
        }
        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> il)
        {
            int mti = il.FindIndex(_ => _.Name == "Vanilla: Mouse Text");
            var ci = ModContent.GetInstance<Config>();
            var gt = new GameTime();
            var lp = LocalPlayer;
            int cb = lp.CountBuffs();
            int he = (int)SD((lp.statLifeMax2 - lp.statLife) * 100, lp.inventory.Max(_ => _.healLife));
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
            ad.ds = !ci.adv;
            ad.flw = ci.adf;
            ad.TU();
            blb.ds = "Off" == ci.blbv;
            blb.flw = ci.blbf;
            blb.TU();
            cap = 100 < he ? 100 : he;
            ftb.ds = "Off" == ci.ftbv;
            ftb.flw = ci.ftbf;
            ftb.TU();
            ftbc = !((0 < jc && 0 == lp.mount.FlyTime && 0 == lp.wingTime || 0 < lp.wingTime && lp.jumpAgainCloud) && 0 == lp.jump && lp.controlJump) && !lp.dead && !lp.mount.CanHover && !lp.sliding && "Off" != ci.ftbv && (!("Only in Flight, not on first Jump" == ci.ftbv && 0 < lp.jump && fj) || MP.pm) && (!lp.mount.Active && (!lp.canCarpet && 0 < lp.carpetTime && lp.carpet || (0 < lp.rocketBoots && 0 < lp.rocketTime || lp.canCarpet) && lp.rocketRelease || 0 < lp.wingTime) || 0 < jc || 0 < lp.jump || 0 < lp.mount.FlyTime) && 0 != lp.velocity.Y && 0 > lp.grappling[0];
            ftbc2 = !lp.mount.Active && 0 == lp.jump && 0 == lp.rocketTime && 0 == lp.wingTime && lp.canCarpet || 0 < jc && lp.releaseJump;
            hb.ds = !ci.hbv;
            hb.flw = ci.hbf;
            hb.ht = $"{lp.statLife}/{lp.statLifeMax2}";
            hb.TU();
            hd.ds = !ci.hdv;
            hd.flw = ci.hdf;
            hd.TU();
            if (lp.releaseJump) fj = false;
            if (0 == lp.velocity.Y || lp.sliding) fj = true;
            il.RemoveAll(_ => _.Name == "Vanilla: Resource Bars");
            itb.ds = "Off" == ci.itbv; ;
            itb.flw = ci.itbf;
            itb.TU();
            jc = new[] { lp.jumpAgainBlizzard, lp.jumpAgainCloud, lp.jumpAgainFart, lp.jumpAgainSail, lp.jumpAgainSandstorm, lp.jumpAgainUnicorn }.Where(_ => _).Count();
            mad.ds = "Off" == ci.madv;
            mad.flw = ci.madf;
            mad.ht = $"{lp.statMana}/{lp.statManaMax2}";
            mad.TU();
            md.ds = !ci.mdv;
            md.flw = ci.mdf;
            md.TU();
            pw.TU();
            rtc.ds = !ci.rtcv;
            rtc.flw = ci.rtcflw;
            rtc.TU();
            sd.ds = !ci.sdv;
            sd.flw = ci.sdf;
            sd.TU();
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
            var mcp = Terraria.ModLoader.Config.ConfigManager.ModConfigPath;
            var pi = ModContent.GetInstance<Positions>();

            Directory.CreateDirectory(mcp);
            pi.ad = ad.cp;
            pi.blb = blb.cp;
            pi.ftb = ftb.cp;
            pi.hb = hb.cp;
            pi.hd = hd.cp;
            pi.itb = itb.cp;
            pi.mad = mad.cp;
            pi.md = md.cp;
            pi.pw = pw.cp;
            pi.rtc = rtc.cp;
            pi.sd = sd.cp;
            File.WriteAllText(mcp + "/Widgets_Positions.json", JsonConvert.SerializeObject(pi, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        public static float SD(float _, float a) => 0 < a ? _ / a : 0;
    }
}