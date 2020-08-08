using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using Terraria.UI;
namespace Widgets
{
    class PWB : UIElement
    {
        public bool cm, md;
        public delegate void _();
        public event _ omd;
        public Texture2D tex;
        protected override void DrawSelf(SpriteBatch sb)
        {
            cm = ContainsPoint(MouseScreen);
            if (cm) LocalPlayer.mouseInterface = true;
            sb.Draw(tex, new Vector2(GetDimensions().X, GetDimensions().Y), Color.White * (cm || md ? 1 : 0.5f));
        }
        public override void MouseDown(UIMouseEvent _)
        {
            if (null != PW.widget) omd();
            md = true;
            MP.br = 0;
            PlaySound(12);
        }
        public PWB(int _, int a, int b, int c)
        {
            Height.Set(_, 0);
            Left.Set(a, 0);
            Top.Set(b, 0);
            Width.Set(c, 0);
        }
        public override void MouseOver(UIMouseEvent _) { if (MP.pm) PlaySound(12); }
        public override void MouseUp(UIMouseEvent _) => md = false;
    }
}