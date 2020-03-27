using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;
using Terraria;
namespace Widgets
{
    class FlightTimeBar : UIElement
    {
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            var ci = GetInstance<Config>();
            var lp = Main.LocalPlayer;
            var pp = (ci.ftf ? 1 : 0) * (lp.Top - Main.screenPosition + new Vector2(0, lp.gfxOffY));

            spriteBatch.Draw(GetTexture("Widgets/Background"), new Vector2((int)pp.X + ci.ftx, (int)pp.Y + ci.fty), Color.White);
            spriteBatch.Draw(GetTexture("Widgets/FlightTimeBar"), new Rectangle((int)pp.X + 28 + ci.ftx, (int)pp.Y + 14 + ci.fty, (int)lp.wingTime * 75 / ((0 < lp.rocketBoots ? 42 : 0) + lp.wingTimeMax), 4), Color.White);
        }
    }
}