using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class BLB : Widget
    {
        protected override void DrawSelf(SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var lp = Terraria.Main.LocalPlayer;
            var con = "Always" == ci.blbv || 0 < lp.breath && lp.breath < lp.breathMax && 0 < lp.lavaTime && lp.lavaTime < lp.lavaMax || MP.pm;

            void DrawBar(bool _, Color a, float b, SpriteBatch c, Texture2D d, int e = 0)
            {
                c.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)tp.X + (_ ? 20 : 4), (int)tp.Y + 4 + e, 50, 10), Color.Black);
                c.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)tp.X + (_ ? 20 : 4), (int)tp.Y + 4 + e, (int)b, 10), a);
                c.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((_ ? 16 : 0) + tp.X, tp.Y + e), Color.White);
                if (_) c.Draw(d, new Vector2(tp.X, tp.Y + e), Color.White);
            }
            Height.Set(con ? 34 : 18, 0);
            DrawBar(ci.blbi, Gradient(ci.lbrg, ci.lbsc, ci.lbec, Mod0.SD(lp.lavaTime, lp.lavaMax)), Mod0.SD(50 * lp.lavaTime, lp.lavaMax), sb, GetTexture("Widgets/sprites/bli"), con ? 16 : 0);
            if ("Always" == ci.blbv || 0 < lp.breath && lp.breath < lp.breathMax || MP.pm) DrawBar(ci.blbi, Gradient(ci.bbrg, ci.bbsc, ci.bbec, Mod0.SD(lp.breath, lp.breathMax)), Mod0.SD(50 * lp.breath, lp.breathMax), sb, GetTexture("Widgets/sprites/bbi"));
            base.DrawSelf(sb);
            Width.Set(ci.blbi ? 74 : 58, 0);
        }
    }
}