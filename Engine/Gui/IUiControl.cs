using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public interface IUiControl
    {
        Bounds hitbox { get; }
        void hide();
        void show();
        void onClick();
        void RenderElement();
    }
}
