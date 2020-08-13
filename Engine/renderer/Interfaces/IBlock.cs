using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer.Interfaces
{
    public interface IBlock
    {
        List<PixElem> RenderGuide { get; }
        Vector position { get; set; }
        bool IsStatic { get; }
        bool onScreen { get; set; }
        void onClick(float clickX, float clickY);
        void onUpdate();
    }
}
