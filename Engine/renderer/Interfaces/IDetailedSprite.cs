using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer.Interfaces
{
    public interface IDetailedSprite
    {
        List<ISprite> RenderGuide { get; }
        void AddDetail(ISprite sprite);
    }
}
