using Engine.Interaction;
using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui.Components
{
    class Button : UiControl
    {
        Vector Myposition;
        string Mymessage;
        int MyfontSize;
        MouseHandler mouse;
        Color Mycolor;
        Action MyonClick;
        public Button(Vector position, string message, int fontSize, Color color, MouseHandler mouse, Action onClick)
        {
            this.Myposition = position;
            this.Mymessage = message;
            this.MyfontSize = fontSize;
            this.Mycolor = color;
            this.mouse = mouse;
            this.MyonClick = onClick;
        }
        public override void RenderElement()
        {
            hitbox = new Bounds(Myposition.x - (MyfontSize*Mymessage.Length)/2, Myposition.y-MyfontSize/2, MyfontSize*Mymessage.Length, MyfontSize);
            mouse.addAction(hitbox, MyonClick);
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(Myposition.x, Myposition.y);
            text = Mymessage;
            color = Mycolor.toPixblocks();
        }
    }
}
