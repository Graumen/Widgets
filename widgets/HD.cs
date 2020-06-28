using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class HD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            Height.Set(22, 0);
            a0.Draw(GetTexture("Widgets/sprites/hdi"), new Vector2(f8.X, f8.Y), Color.White);
            Utils.DrawBorderString(a0, Mod0.f5 + "%", new Vector2(23 + f8.X, f8.Y), GetInstance<Config>().f23);
            base.DrawSelf(a0);
            Width.Set(23 + Main.fontMouseText.MeasureString(Mod0.f5 + "%").X, 0);
        }
    }
}