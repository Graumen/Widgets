using Microsoft.Xna.Framework;
using static System.Math;
using static Terraria.ID.Colors;
using Terraria;
namespace Widgets
{
    class AD : Widget
    {
        Item f0 = new Item();
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f1 = Terraria.ModLoader.ModContent.GetInstance<Config>();
            var f2 = f1.f2;
            var f3 = Main.itemTexture[0 < f0.type ? f0.type : 2177];
            var f4 = Main.LocalPlayer;
            var f5 = Min(44f / f3.Height, 44f / f3.Width) / 1.375;
            var f6 = 1 < f5 ? 1 : f5;
            var f7 = f0.Name + (1 < f0.stack ? "\n" + f0.stack : "");

            Color Rarity()
            {
                switch (f0.rare)
                {
                    case 0: return RarityNormal;
                    case 1: return RarityBlue;
                    case -1: return RarityTrash;
                    case 10: return new Color(255, 40, 100);
                    case -11: return new Color(255, 175, 0);
                    case 2: return RarityGreen;
                    case 3: return RarityOrange;
                    case 4: return RarityRed;
                    case 5: return RarityPink;
                    case 6: return RarityPurple;
                    case 7: return RarityLime;
                    case 8: return RarityYellow;
                    case 9: return RarityCyan;
                }
                return new Color(180, 40, 255);
            }
            foreach (var f8 in f4.inventory) if (f8.active && f8.ammo == f4.HeldItem.useAmmo)
                {
                    f0 = f8;
                    break;
                }
            for (var f9 = 54; 58 > f9; f9++) if (f4.HeldItem.useAmmo == f4.inventory[f9].ammo && f4.inventory[f9].active)
                {
                    f0 = f4.inventory[f9];
                    break;
                }
            Height.Set(1 < f0.stack ? 48 : 44, 0);
            if (0 < f2.A) Utils.DrawInvBG(a0, new Rectangle((int)f8.X, (int)f8.Y, 44, 44), new Color(f2.R * f2.A / 255, f2.G * f2.A / 255, f2.B * f2.A / 255, f2.A));
            a0.Draw(f3, new Rectangle((int)Round((44 - f3.Width * f6) / 2 + f8.X), (int)Round((44 - f3.Height * f6) / 2 + f8.Y), (int)Round(f3.Width * f6), (int)Round(f3.Height * f6)), Color.White * (0 < f0.type ? 1 : 0.5f));
            Utils.DrawBorderString(a0, f7, new Vector2(49 + f8.X, f8.Y), Rarity());
            base.DrawSelf(a0);
            Width.Set("" != f7 ? 49 + Main.fontMouseText.MeasureString(f7).X : 44, 0);
        }
    }
}