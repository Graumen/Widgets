using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class HD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            Height.Set(22, 0);
            sb.Draw(GetTexture("Widgets/sprites/hdi"), new Vector2(x, y), Color.White);
            Utils.DrawBorderString(sb, Mod0.cap + "%", new Vector2(23 + x, y), GetInstance<Config>().hdc);
            base.DrawSelf(sb);
            Width.Set(59, 0);
        }
    }
}