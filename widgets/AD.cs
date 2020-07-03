using Microsoft.Xna.Framework;
using static System.Math;
using static Terraria.ID.Colors;
using Terraria;
namespace Widgets
{
    class AD : Widget
    {
        Item ca = new Item();
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = Terraria.ModLoader.ModContent.GetInstance<Config>();
            var bc = ci.adc;
            var lp = Main.LocalPlayer;
            var rc = new System.Collections.Generic.Dictionary<int, Color> { [0] = RarityNormal, [1] = RarityBlue, [-1] = RarityTrash, [10] = new Color(255, 40, 100), [11] = new Color(180, 40, 255), [-11] = new Color(255, 175, 0), [2] = RarityGreen, [3] = RarityOrange, [4] = RarityRed, [5] = RarityPink, [6] = RarityPurple, [7] = RarityLime, [8] = RarityYellow, [9] = RarityCyan };
            var tex = Main.itemTexture[0 < ca.type ? ca.type : 2177];
            var _ = Min(44f / tex.Height, 44f / tex.Width) / 1.375;
            var scale = 1 < _ ? 1 : _;
            var txt = ca.Name + (1 < ca.stack ? "\n" + ca.stack : "");

            foreach (var item in lp.inventory) if (item.active && item.ammo == lp.HeldItem.useAmmo)
                {
                    ca = item;
                    break;
                }
            for (var slot = 54; 58 > slot; slot++) if (lp.HeldItem.useAmmo == lp.inventory[slot].ammo && lp.inventory[slot].active)
                {
                    ca = lp.inventory[slot];
                    break;
                }
            Height.Set(1 < ca.stack ? 48 : 44, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle((int)tp.X, (int)tp.Y, 44, 44), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            sb.Draw(tex, new Rectangle((int)Round((44 - tex.Width * scale) / 2 + tp.X), (int)Round((44 - tex.Height * scale) / 2 + tp.Y), (int)Round(tex.Width * scale), (int)Round(tex.Height * scale)), Color.White * (0 < ca.type ? 1 : 0.5f));
            Utils.DrawBorderString(sb, txt, new Vector2(49 + tp.X, tp.Y), rc[ca.rare]);
            base.DrawSelf(sb);
            Width.Set("" != txt ? 49 + Main.fontMouseText.MeasureString(txt).X : 44, 0);
        }
    }
}