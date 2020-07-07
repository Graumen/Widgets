using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using Terraria.UI;
namespace Widgets
{
    class PWB : UIElement
    {
        public bool md;
        int height, width, x, y;
        public delegate void _();
        public event _ omd;
        Texture2D tex;
        protected override void DrawSelf(SpriteBatch sb)
        {
            Height.Set(height, 0);
            if (ContainsPoint(MouseScreen)) LocalPlayer.mouseInterface = true;
            Left.Set(x, 0);
            sb.Draw(tex, new Vector2(GetDimensions().X, GetDimensions().Y), Color.White * (ContainsPoint(MouseScreen) ? 1 : 0.5f));
            Top.Set(y, 0);
            Width.Set(width, 0);
        }
        public override void MouseDown(UIMouseEvent _)
        {
            if (null != PW.widget) omd();
            md = MP.br = true;
            PlaySound(12);
        }
        public PWB(int Height, int Width, int X, int Y, Texture2D Tex)
        {
            height = Height;
            tex = Tex;
            width = Width;
            x = X;
            y = Y;
        }
        public override void MouseOver(UIMouseEvent _) => PlaySound(12);
    }
}