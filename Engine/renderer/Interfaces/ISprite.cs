using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer.Interfaces
{
    public enum PositionType
    {
        Relative,
        Absolute
    }
    public interface ISprite
    {
        PositionType positionType { get; }
        Vector position { get; set; }
        bool onScreen { get; set; }
        Sprite sprite { get; set; }
        int img { get; }
        int size { get; set; }
        int BaseSize { get; }
        Color color { get; }

        void onRender();
    }
}
