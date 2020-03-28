using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
namespace Widgets
{
    class Mod0 : Mod
    {
        Item ca = new Item();
        static Config ci = ModContent.GetInstance<Config>();
        static Player lp = Main.LocalPlayer;
        UserInterface ft = new UserInterface();
        Color Rarity(int a)
        {
            switch (a)
            {
                case -11:
                    return new Color(255, 175, 0);
                case -1:
                    return Colors.RarityTrash;
                case 0:
                    return Colors.RarityNormal;
                case 1:
                    return Colors.RarityBlue;
                case 2:
                    return Colors.RarityGreen;
                case 3:
                    return Colors.RarityOrange;
                case 4:
                    return Colors.RarityRed;
                case 5:
                    return Colors.RarityPink;
                case 6:
                    return Colors.RarityPurple;
                case 7:
                    return Colors.RarityLime;
                case 8:
                    return Colors.RarityYellow;
                case 9:
                    return Colors.RarityCyan;
                case 10:
                    return new Color(255, 40, 100);
            }
            return new Color(180, 40, 255);
        }
        public override void Load()
        {
            ft.SetState(new UIState());
            new UIState().Activate();
        }
        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers)
        {
            var it = Main.itemTexture[ca.type];
            var min = 1 > Math.Min((float)ci.cah / it.Height, (float)ci.caw / it.Width) / 1.375f ? Math.Min((float)ci.cah / it.Height, (float)ci.caw / it.Width) / 1.375f : 1;
            var mti = layers.FindIndex(a => a.Name == "Vanilla: Mouse Text");
            var pp = (ci.caf ? 1 : 0) * (lp.Top - Main.screenPosition + new Vector2(0, lp.gfxOffY));
            var sb = Main.spriteBatch;

            foreach (Item i in lp.inventory)
            {
                if (i.active
                 && i.ammo == lp.HeldItem.useAmmo)
                {
                    ca = i;
                    break;
                }
            }
            for (int i = 54; 58 > i; i++)
            {
                if (lp.HeldItem.useAmmo == lp.inventory[i].ammo
                 && lp.inventory[i].active)
                {
                    ca = lp.inventory[i];
                    break;
                }
            }

            if (mti != -1)
            {
                layers.Insert(mti, new LegacyGameInterfaceLayer("", () =>
               {
                   if (-1 == lp.grappling[0]
                    && !lp.dead
                    && 0 != lp.velocity.Y
                    && 0 < lp.wingTime
                    && 0 == lp.jump
                    && ci.ftv) { ft.Draw(sb, new GameTime()); }
                   if (!lp.dead
                    && 0 < lp.HeldItem.useAmmo
                    && ci.cav
                    && lp.HasAmmo(lp.HeldItem, true))
                   {
                       if (0 < ci.cac.A) { Utils.DrawInvBG(sb, new Rectangle((int)pp.X + ci.cax, (int)pp.Y + ci.cay, ci.caw, ci.cah), ci.cac); }
                       sb.Draw(it, new Rectangle((int)Math.Round((ci.caw - it.Width * min) / 2 + ci.cax) + (int)pp.X, (int)Math.Round((ci.cah - it.Height * min) / 2 + ci.cay) + (int)pp.Y, (int)Math.Round(it.Width * min), (int)Math.Round(it.Height * min)), Color.White);
                       Utils.DrawBorderString(sb, ca.Name + (1 < ca.stack ? "\n" + ca.stack : ""), new Vector2((int)pp.X + 10 + ci.caw + ci.cax, (int)pp.Y + ci.cay), Rarity(ca.rare));
                   }
                   if (!lp.dead
                    && ci.muv)
                   {
                       sb.Draw(Main.buffTexture[150], new Vector2(ci.mux, ci.muy), Color.White);
                       Utils.DrawBorderString(sb, $"{lp.slotsMinions}/{lp.maxMinions}", new Vector2((Main.buffTexture[150].Width - Main.fontMouseText.MeasureString($"{lp.slotsMinions}/{lp.maxMinions}").X) / 2 + ci.mux, 35 + ci.muy), Color.White);
                   }
                   return true;
               }, InterfaceScaleType.UI));
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (-1 == lp.grappling[0]
             && !lp.dead
             && 0 != lp.velocity.Y
             && 0 < lp.wingTime
             && 0 == lp.jump
             && ci.ftv) { ft?.Update(gameTime); }
        }
    }
}