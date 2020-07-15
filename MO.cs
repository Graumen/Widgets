using static Terraria.Main;
using Terraria.UI;
namespace Widgets
{
    class MO : UIElement
    {
        public MO(int _, int a, int b, int c)
        {
            Height.Set(_, 0);
            Left.Set(a, 0);
            Top.Set(b, 0);
            Width.Set(c, 0);
        }
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb) { if (ContainsPoint(MouseScreen)) LocalPlayer.mouseInterface = true; }
        public override void MouseOver(UIMouseEvent evt) { if (MP.pm) PlaySound(12); }
    }
}