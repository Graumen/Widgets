using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class MAD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var lp = Main.LocalPlayer;
            var txt = 0 < (int)(lp.HeldItem.mana * lp.manaCost) ? "" + lp.statMana / (int)(lp.HeldItem.mana * lp.manaCost) : "∞";

            if (ci.madb)
            {
                sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.madi ? 20 : 4) + (int)tp.X, (int)tp.Y + 4, 50, 10), Color.Black);
                sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.madi ? 20 : 4) + (int)tp.X, (int)tp.Y + 4, 50 * lp.statMana / lp.statManaMax2, 10), Gradient(ci.madrg, ci.madsc, ci.madec, (float)lp.statMana / lp.statManaMax2));
                sb.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((ci.madi ? 16 : 0) + tp.X, tp.Y), Color.White);
                if (ci.madi) sb.Draw(GetTexture("Widgets/sprites/madi2"), new Vector2(10 + tp.X, tp.Y), Color.White);
            }
            else Utils.DrawBorderString(sb, txt, new Vector2(23 + tp.X, tp.Y), Color.White);
            Height.Set(18, 0);
            if (!ci.madb || ci.madi) sb.Draw(GetTexture("Widgets/sprites/madi"), new Vector2(tp.X, tp.Y), Color.White);
            base.DrawSelf(sb);
            Width.Set(ci.madb ? ci.madi ? 74 : 58 : 23 + Main.fontMouseText.MeasureString(txt).X, 0);
        }
    }
}