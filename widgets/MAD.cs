using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class MAD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = GetInstance<Config>();
            var f1 = Main.LocalPlayer;
            var f2 = 0 < (int)(f1.HeldItem.mana * f1.manaCost) ? "" + f1.statMana / (int)(f1.HeldItem.mana * f1.manaCost) : "∞";

            if (f0.f39)
            {
                a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f40 ? 20 : 4) + (int)f8.X, (int)f8.Y + 4, 50, 10), Color.Black);
                a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f40 ? 20 : 4) + (int)f8.X, (int)f8.Y + 4, 50 * f1.statMana / f1.statManaMax2, 10), Gradient(f0.f41, f0.f42, f0.f43, (float)f1.statMana / f1.statManaMax2));
                a0.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((f0.f40 ? 16 : 0) + f8.X, f8.Y), Color.White);
                if (f0.f40) a0.Draw(GetTexture("Widgets/sprites/madi2"), new Vector2(10 + f8.X, f8.Y), Color.White);
            }
            else Utils.DrawBorderString(a0, f2, new Vector2(23 + f8.X, f8.Y), Color.White);
            base.DrawSelf(a0);
            Height.Set(18, 0);
            if (!f0.f39 || f0.f40) a0.Draw(GetTexture("Widgets/sprites/madi"), new Vector2(f8.X, f8.Y), Color.White);
            Width.Set(f0.f39 ? f0.f40 ? 74 : 58 : 23 + Main.fontMouseText.MeasureString(f2).X, 0);
        }
    }
}