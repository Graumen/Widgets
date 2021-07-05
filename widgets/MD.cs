using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class MD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var lp = LocalPlayer;

            Height.Set(30, 0);
            sb.Draw(GetTexture("Widgets/sprites/mdi"), new Vector2(x, y), Color.White);
            Terraria.Utils.DrawBorderString(sb, $"{lp.slotsMinions}/{lp.maxMinions}", new Vector2(35 + x, y), GetInstance<Config>().mdc);
            base.DrawSelf(sb);
            Width.Set(35 + fontMouseText.MeasureString($"{lp.slotsMinions}/{lp.maxMinions}").X, 0);
        }
    }
}