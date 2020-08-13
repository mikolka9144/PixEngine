using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer
{
    public class Vector
    {
        public float x;
        public float y;

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector(double x, double y)
        {
            this.x = Convert.ToSingle(x);
            this.y = Convert.ToSingle(y);
        }
        }
}
