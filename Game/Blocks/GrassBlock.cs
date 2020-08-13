using Engine.renderer;
using Engine.renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Blocks
{
    public class GrassBlock : IBlock
    {
        public List<PixElem> RenderGuide { get; }
        public int id { get; set; }
        public Vector position { get; set; }

        public GrassBlock()
        {
            RenderGuide = new List<PixElem>();
            RenderGuide.Add(new PixElem(63, new Color(0, 255, 0), 10, 0f, 0f));
        }

        public void onClick(float clickX, float clickY)
        {
            throw new NotImplementedException();
        }
    }
}
