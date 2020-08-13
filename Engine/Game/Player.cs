using Engine.renderer.Interfaces;
using Sprite = PixBlocks.PythonIron.Tools.Integration.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.renderer;

namespace Engine.Game
{
    class Player : ISprite
    {
        public PositionType positionType { get; }
        public Vector position { get; set; }
        public bool onScreen { get; set; }
        public Sprite sprite { get; set; }
        public int img { get; }
        public int size { get; set; }
        public int BaseSize { get; }
        public Color color { get; }

        public Player()
        {
            positionType = PositionType.Relative;
            position = new Vector(0, 0);
            img = 0;
            size = 5;
            BaseSize = 5;
            color = new Color(0, 0, 255);
        }

        public void onRender()
        {

        }
    }
}
