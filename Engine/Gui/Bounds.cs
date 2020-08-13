using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public class Bounds
    {
        public Vector position;
        public Vector size;
        public Bounds(float x, float y, float w, float h)
        {
            this.position = new Vector(x, y);
            this.size = new Vector(w, h);
        }
    }
}
