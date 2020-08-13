using Engine.renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixBlocks.TopPanel.Components.Basic;
using Engine.Interaction;
using Engine.Resources.Blocks;
using Engine.Resources;

namespace Engine
{
    public class GameEngine
    {
        public Renderer Renderer;
        public KeyboardHandler Keyboard;
    
        RenderBlock renderBlock;
        public MouseHandler Mouse;

        public GameEngine()
        {
            Mouse = new MouseHandler();
            Keyboard = new KeyboardHandler();
            Renderer = new Renderer(Mouse);
        }
        public void Setup(IGame game)
        {
            // Renderer Block
            renderBlock = new RenderBlock(game, () => { game.onRender(); });
            game.engine.Renderer.AddBlock(new Vector(0,0), renderBlock);

            // Handler Block
            game.engine.Renderer.AddBlock(new Vector(0, 0), new HandlerBlock(game));
        }
        public void StartGame()
        {
            PixBlocks.PythonIron.Tools.Game.GameScene.gameSceneStatic.start();
        }

        // Camera
        public void setCameraPosition(float x, float y)
        {
            renderBlock.campos.x = x;
            renderBlock.campos.y = y;
        }
        public Vector getCameraPosition()
        {
            return renderBlock.campos;
        }
    }
}
