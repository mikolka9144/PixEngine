using Engine.Gui;
using Engine.Gui.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.renderer;
using Engine.Interaction;

namespace Engine.Game.Gui
{
    class MainMenu : UserInterface
    {
        Input input;
        public MainMenu(MouseHandler mouse)
        {
            AddElement(new Background(new Color(255, 255, 255)));
            input = new Input(new Vector(0, 0), "< 0 >", "Type something", 10, new Color(0, 255, 0), this, mouse, (string inputText) =>
            {
                input.updateText("< " + inputText + " >");
            });
            AddElement(input);
        }
    }
}
