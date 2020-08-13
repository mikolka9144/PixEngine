using Engine.renderer;
using Sprite = PixBlocks.PythonIron.Tools.Integration.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui.Components
{
    public class Background : UiControl
    {
        Color Mycolor;
        public Background(Color color)
        {
            this.Mycolor = color;
        }
        public override void RenderElement()
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(0, 0);
            image = 63;
            size = 200;
            color = Mycolor.toPixblocks();
        }
    }
}
