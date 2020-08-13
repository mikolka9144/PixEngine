using Engine;
using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        public void Start()
        {
            GameEngine engine = new GameEngine();
            engine.renderer.AddBlock(new Vector(0, 0), new Blocks.GrassBlock());
            engine.Start();
        }
    }
}
