using Engine;
using Engine.Game.Gui;
using Engine.Gui.Components;
using Engine.renderer;
using System;
using System.Collections.Generic;
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

            MainMenu menu = new MainMenu(engine.Mouse);
            menu.RenderUI();

            engine.Renderer.AddBlock(new Vector(0, 0), new Blocks.GrassBlock());
            engine.Renderer.AddSprite(new Player());

            //movement
            engine.Keyboard.AddListener("w", () => {
                campos.y += 2;
            });
            engine.Keyboard.AddListener("s", () => {
                campos.y -= 2;
            });
            engine.Keyboard.AddListener("a", () => {
                campos.x -= 2;
            });
            engine.Keyboard.AddListener("d", () => {
               campos.x += 2;
            });


            engine.Setup(this);
            engine.Renderer.RenderFrame(0, 0);
            menu.ShowUi(engine.Renderer);
            engine.StartGame();
        }
        public void onRender()
        {
            engine.setCameraPosition(campos.x, campos.y);
        }
    }
}
