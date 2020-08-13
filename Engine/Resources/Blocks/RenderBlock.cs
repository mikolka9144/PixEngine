using Engine.renderer;
using Engine.renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Resources.Blocks
{
    public class RenderBlock : IBlock
    {
        public List<PixElem> RenderGuide { get; }
        public int id { get; set; }
        public Vector position { get; set; }
        IGame game;
        Action onRender;
        public bool IsStatic { get; }
        public bool onScreen { get; set; }
        public Vector campos;

        public RenderBlock(IGame game, Action onRender)
        {
            onScreen = false;
            IsStatic = true;
            campos = new Vector(0, 0);
            this.onRender = onRender;
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
            onRender();
            game.engine.Renderer.RenderFrame(campos.x, campos.y);
        }
        
    }
}
