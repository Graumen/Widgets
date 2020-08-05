using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using Terraria.UI;
namespace Widgets
{
    class PWB : UIElement
    {
        public bool md, mo;
        public delegate void MD();
        public event MD omd;
        Texture2D tex;
        public PWB(int _, int a, int b, int c, Texture2D d)
        {
            Height.Set(_, 0);
            Left.Set(a, 0);
            tex = d;
            Top.Set(b, 0);
            Width.Set(c, 0);
        }
        protected override void DrawSelf(SpriteBatch sb)
        {
            if (mo) LocalPlayer.mouseInterface = true;
            mo = ContainsPoint(MouseScreen);
            sb.Draw(tex, new Vector2(GetDimensions().X, GetDimensions().Y), Color.White * (md || mo ? 1 : 0.5f));
        }
        public override void MouseDown(UIMouseEvent _)
        {
            if (null != PW.widget) omd();
            md = true;
            MP.br = 0;
            PlaySound(12);
        }
        public override void MouseOver(UIMouseEvent _) { if (MP.pm) PlaySound(12); }
        public override void MouseUp(UIMouseEvent _) => md = false;
    }
}