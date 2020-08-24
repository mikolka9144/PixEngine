using Engine;
using Engine.Game.Gui;
using Engine.Gui.Components;
using Engine.renderer;
using Engine.renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Game
{
    public class Game : IGame
    {
        public GameEngine engine { get; set; }

        Vector campos;
        public Game()
        {
            campos = new Vector(0, 0);
        }

        public void Start()
        {
            engine = new GameEngine();


            Bitmap image = new Bitmap(@"Path to bitmap");
            ImageBlock block = Tools.BitmapToBlock(image, 1);
            block.ClickEvent = (float clickX, float clickY) =>
            {
                throw new Exception(clickX + " " + clickY);
            };
            engine.Renderer.AddBlock(new Vector(0, 0), block);


            engine.Setup(this);
            engine.Renderer.RenderFrame(0, 0);
            engine.StartGame();
        }
        public void onRender()
        {
            engine.setCameraPosition(campos.x, campos.y);
        }
    }
}
