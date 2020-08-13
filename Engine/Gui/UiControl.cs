using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public class UiControl : Sprite, IUiControl
    {
        public Bounds hitbox { get; set; }
        public UiControl()
        {
            text = "Render Error";
            color = new Color(255, 0, 0);
        }
        public void show()
        {
            GameScene.gameSceneStatic.add(this);
        }

        public void hide()
        {
            GameScene.gameSceneStatic.remove(this);
        }

        public void onClick()
        {
            throw new NotImplementedException();
        }

        public virtual void RenderElement()
        {
            throw new Exception(this.GetType().Name + " does not implement render!");
        }
    }
}
