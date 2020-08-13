using Engine.renderer.Interfaces;
using Sprite = PixBlocks.PythonIron.Tools.Integration.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.renderer
{
    public class DetailedSprite : IDetailedSprite
    {
        public List<ISprite> RenderGuide { get; }
        public Vector position;
        public DetailedSprite()
        {
            RenderGuide.Add(new DSpriteBase(this));
        }
        public void AddDetail(ISprite sprite)
        {
            RenderGuide.Add(sprite);
        }
        public void AddToRenderer(Renderer renderer)
        {
            foreach(ISprite elem in RenderGuide)
            {
                renderer.AddSprite(elem);
            }
        }
        public void Update()
        {
            foreach(ISprite elem in RenderGuide)
            {
                elem.position.x = position.x;
                elem.position.y = position.y;
            }
        }
    }
    class DSpriteBase : ISprite
    {
        public PositionType positionType { get; }
        public Vector position { get; set; }
        public bool onScreen { get; set; }
        public Sprite sprite { get; set; }
        public int img { get; }
        public int size { get; set; }
        public int BaseSize { get; }
        public Color color { get; }
        public DetailedSprite ds { get; set; }

        public DSpriteBase(DetailedSprite ds)
        {
            this.ds = ds;
            positionType = PositionType.Relative;
            position = new Vector(0, 0);
            img = 0;
            size = 0;
            BaseSize = 0;
            color = new Color(0, 0, 0);
        }

        public void onRender()
        {
            ds.Update();
        }
    }
}
