using Engine.renderer;
using Engine.renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Resources.Blocks
{
    class HandlerBlock : IBlock
    {
        public List<PixElem> RenderGuide { get; }
        public Vector position { get; set; }
        IGame game;
        public bool IsStatic { get; set; }
        public bool onScreen { get; set; }

        public HandlerBlock(IGame game)
        {
            onScreen = false;
            IsStatic = true;
            this.game = game;
            RenderGuide = new List<PixElem>();
            RenderGuide.Add(new PixElem(63, new Color(0, 0, 0), 0, 0f, 0f));
        }

        public void onClick(float clickX, float clickY)
        {
            return;
        }

        public void onUpdate()
        {
            game.engine.Keyboard.Handle();
        }
    }
}
