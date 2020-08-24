using Engine.renderer;
using Engine.renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Tools
    {
        public static ImageBlock BitmapToBlock(Bitmap bmp, int size)
        {
            ImageBlock imgBlock = new ImageBlock();
            for (int x=0; x<bmp.Width; x++)
            {
                for (int y=0; y<bmp.Height; y++)
                {
                    System.Drawing.Color pixelColor = bmp.GetPixel(x, y);
                    Engine.renderer.Color pixel = new renderer.Color(pixelColor.R, pixelColor.G, pixelColor.B);
                    imgBlock.RenderGuide.Add(new PixElem(63, pixel, size, x*size, y*size));
                }
            }
            return imgBlock;
        }
    }


    public class ImageBlock : IBlock
    {
        public List<PixElem> RenderGuide { get; }
        public Vector position { get; set; }
        public bool IsStatic { get; }
        public bool onScreen { get; set; }
        public Action<float, float> ClickEvent;

        public ImageBlock()
        {
            ClickEvent = (float clickX, float clickY) => { };
            RenderGuide = new List<PixElem>();
            position = new Vector(0, 0);
            IsStatic = false;
            onScreen = false;
        }

        public void onClick(float clickX, float clickY)
        {
            ClickEvent(clickX, clickY);
        }
        public void onUpdate()
        {
        }
    }
}
