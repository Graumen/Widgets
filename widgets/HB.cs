using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class HB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var lp = Terraria.Main.LocalPlayer;

            Height.Set(ci.hbi ? 22 : 18, 0);
            sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.hbi ? 24 : 4) + x, (ci.hbi ? 6 : 4) + y, 50, 10), Color.Black);
            sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.hbi ? 24 : 4) + x, (ci.hbi ? 6 : 4) + y, 50 * lp.statLife / lp.statLifeMax2, 10), Gradient(ci.hbrg, ci.hbsc, ci.hbec, (float)lp.statLife / lp.statLifeMax2));
            sb.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((ci.hbi ? 20 : 0) + x, (ci.hbi ? 2 : 0) + y), Color.White);
            if (ci.hbi) sb.Draw(GetTexture("Widgets/sprites/hbi"), new Vector2(x, y), Color.White);
            base.DrawSelf(sb);
            Width.Set(ci.hbi ? 78 : 58, 0);
        }
    }
}