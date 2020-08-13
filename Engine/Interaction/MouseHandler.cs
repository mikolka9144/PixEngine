using Engine.Gui;
using Engine.renderer;
using PixBlocks.PythonIron.Tools.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixVector = PixBlocks.PythonIron.Tools.Integration.Vector;

namespace Engine.Interaction
{
    public class MouseAction
    {
        public Action action;
        public Bounds hitbox;
        public MouseAction(Bounds hitbox, Action action)
        {
            this.hitbox = hitbox;
            this.action = action;
        }
    }
    public class MouseHandler
    {
        List<MouseAction> actions;
        public MouseHandler()
        {
            actions = new List<MouseAction>();
        }
        public void addAction(Bounds hitbox, Action action)
        {
            actions.Add(new MouseAction(hitbox, action));
        }
        public MouseState Handle()
        {
            if (GameScene.gameSceneStatic.mouse.pressed)
            {
                PixVector mousepos = GameScene.gameSceneStatic.mouse.position;
                return new MouseState(true, new Vector(mousepos.x, mousepos.y));
            }
            return new MouseState(false, new Vector(0, 0));
        }
        public void HandleActions()
        {
            if (GameScene.gameSceneStatic.mouse.pressed)
            {
                PixVector mpos = GameScene.gameSceneStatic.mouse.position;
                foreach (MouseAction a in actions) {
                    if (mpos.x > a.hitbox.position.x && mpos.x < a.hitbox.position.x + a.hitbox.size.x &&
                        mpos.y > a.hitbox.position.y && mpos.y < a.hitbox.position.y + a.hitbox.size.y)
                    {
                        a.action();
                    }
                }
            }
        }
    }
    public class MouseState
    {
        public bool pressed;
        public Vector position;
        public MouseState(bool pressed, Vector position)
        {
            this.pressed = pressed;
            this.position = position;
        }
    }
}
