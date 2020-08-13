using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public interface IUserInterface
    {
        List<IUiControl> elements { get; }
        void AddElement(IUiControl element);
        void RenderUI();
    }
}
