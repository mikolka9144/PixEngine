using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer
{
    public class PixElem
    {
        public int img;
        public Color color;
        public int size;
        public float xoff;
        public float yoff;
        public PixElem(int image, Color color, int size, float xoff, float yoff)
        {
            this.img = image;
            this.color = color;
            this.size = size;
            this.xoff = xoff;
            this.yoff = yoff;
        }
    }
    public class Color
    {
        public int r;
        public int g;
        public int b;
        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public PixBlocks.PythonIron.Tools.Integration.Color toPixblocks()
        {
            return new PixBlocks.PythonIron.Tools.Integration.Color(r, g, b);
        }
    }
}
