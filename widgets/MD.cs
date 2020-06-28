using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class MD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = LocalPlayer;

            Height.Set(30, 0);
            a0.Draw(GetTexture("Widgets/sprites/mdi"), new Vector2(f8.X, f8.Y), Color.White);
            Terraria.Utils.DrawBorderString(a0, $"{f0.slotsMinions}/{f0.maxMinions}", new Vector2(35 + f8.X, f8.Y), GetInstance<Config>().f46);
            base.DrawSelf(a0);
            Width.Set(35 + fontMouseText.MeasureString($"{f0.slotsMinions}/{f0.maxMinions}").X, 0);
        }
    }
}