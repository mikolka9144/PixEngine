using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public class UserInterface : IUserInterface
    {
        public List<IUiControl> elements { get; }
        public UserInterface()
        {
            elements = new List<IUiControl>();
        }
        public void AddElement(IUiControl element)
        {
            elements.Add(element);
        }
        public void RenderUI()
        {
            foreach (IUiControl elem in elements)
            {
                elem.RenderElement();
            }
        }
        public void ShowUi(Renderer renderer, bool pause)
        {
            if (pause)
            {
                renderer.render = false;
            }
            foreach(IUiControl elem in elements)
            {
                elem.show();
            }
        }
        public void HideUi(Renderer renderer, bool unpause)
        {
            if (unpause)
            {
                renderer.render = true;
            }
            foreach (IUiControl elem in elements)
            {
                renderer.render = true;
                elem.hide();
            }
        }
    }
}
