using Engine.Interaction;
using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui.Components
{
    class Input : UiControl
    {
        Button btn;
        public Input(Vector position, string text, string message, int fontSize, Color color, UserInterface Ui, MouseHandler mouse, Action<string> onInput)
        {
            btn = new Button(position, text, fontSize, color, mouse, () =>
            {
                onInput(UiStatic.GetInput(message));
            });
            Ui.AddElement(btn);
        }
        public void updateText(string newText)
        {
            btn.text = newText;
        }
        public override void RenderElement()
        {
            size = 0;
        }
    }
}
