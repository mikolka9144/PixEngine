using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprite = PixBlocks.PythonIron.Tools.Integration.Sprite;

namespace Engine.Gui.Components
{
    public class Label : UiControl
    {
        Vector Myposition;
        string Mymessage;
        int MyfontSize;
        Color Mycolor;
        public Label(Vector position, string message, int fontSize, Color color)
        {
            this.Myposition = position;
            this.Mymessage = message;
            this.MyfontSize = fontSize;
            this.Mycolor = color;
        }
        public override void RenderElement()
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(Myposition.x, Myposition.y);
            size = MyfontSize;
            text = Mymessage;
            color = Mycolor.toPixblocks();
        }
    }
}
