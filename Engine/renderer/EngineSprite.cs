using Engine.renderer.Interfaces;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer
{
    public class EngineSprite : Sprite
    {
        public IBlock parent;
        public bool main;
        public override void update()
        {
            base.update();
            if (main)
            {
                parent.onUpdate();
            }
        }
    }
}
