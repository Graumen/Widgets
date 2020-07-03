using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class FTB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var lp = LocalPlayer;
            var ct = lp.carpetTime;
            var wt = lp.wingTime;

            Height.Set(ci.ftbi ? 22 : 18, 0);
            if ((0 < lp.jump || lp.releaseJump) && 1 < Mod0.jc) Terraria.Utils.DrawBorderString(sb, "" + Mod0.jc, new Vector2((ci.ftbi ? 85 : 63) + tp.X, tp.Y), Color.White);
            sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.ftbi ? 26 : 4) + (int)tp.X, (ci.ftbi ? 6 : 4) + (int)tp.Y, 50, 10), Color.Black);
            if (0 == lp.velocity.Y && lp.releaseJump || Mod0.ftbc) sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.ftbi ? 26 : 4) + (int)tp.X, (ci.ftbi ? 6 : 4) + (int)tp.Y, Mod0.ftbc2 ? 50 : 0 < lp.jump ? (int)Mod0.SD(50 * lp.jump, lp.jump + Mod0.tft) : lp.mount.Active ? (int)Mod0.SD(50 * lp.mount.FlyTime, lp.mount.FlyTime + Mod0.tft) : 0 < wt ? (int)Mod0.SD(50 * wt, Mod0.tft + wt) : 0 < lp.rocketTime ? (int)Mod0.SD(50 * lp.rocketTime, lp.rocketTimeMax) : (int)Mod0.SD(50 * ct, ct + Mod0.tft), 10), Gradient(ci.ftbrg, ci.ftbsc, ci.ftbec, Mod0.ftbc2 ? 1 : 0 < lp.jump ? Mod0.SD(lp.jump, lp.jump + Mod0.tft) : lp.mount.Active ? Mod0.SD(lp.mount.FlyTime, lp.mount.FlyTime + Mod0.tft) : 0 < wt ? Mod0.SD(wt, Mod0.tft + wt) : 0 < lp.rocketTime ? Mod0.SD(lp.rocketTime, lp.rocketTimeMax) : Mod0.SD(ct, ct + Mod0.tft)));
            sb.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((ci.ftbi ? 22 : 0) + tp.X, (ci.ftbi ? 2 : 0) + tp.Y), Color.White);
            if (ci.ftbi) sb.Draw((0 < Mod0.jc || 0 == lp.velocity.Y) && lp.releaseJump || 0 < lp.jump ? GetTexture("Widgets/sprites/ftbi2") : Mod0.ftbc ? 0 < wt || lp.mount.Active ? GetTexture("Widgets/sprites/ftbi4") : 0 < lp.rocketBoots && 0 < lp.rocketTime ? GetTexture("Widgets/sprites/ftbi3") : GetTexture("Widgets/sprites/ftbi") : GetTexture("Widgets/sprites/ftbi5"), new Vector2(tp.X, tp.Y), Color.White);
            base.DrawSelf(sb);
            Width.Set((1 < Mod0.jc ? 5 + fontMouseText.MeasureString("" + Mod0.jc).X : 0) + (ci.ftbi ? 80 : 58), 0);
        }
    }
}