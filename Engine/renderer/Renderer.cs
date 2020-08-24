using Engine.renderer.Interfaces;
using PixBlocks.PythonIron.Tools.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprite = PixBlocks.PythonIron.Tools.Integration.Sprite;
using PixVector = PixBlocks.PythonIron.Tools.Integration.Vector;
using Engine.Interaction;

namespace Engine.renderer
{
    public class Renderer
    {
        List<IBlock> game;
        List<ISprite> sprites;
        List<EngineSprite> onScreen;
        MouseHandler Mouse;
        public bool render;
        bool previousRenderState;
        public Renderer(MouseHandler mouse)
        {
            render = true;
            previousRenderState = true;
            Mouse = mouse;
            game = new List<IBlock>();
            sprites = new List<ISprite>();
            onScreen = new List<EngineSprite>();
        }

        public void AddBlock(Vector position, IBlock block)
        {
            block.position = position;
            game.Add(block);
        }
        public void AddSprite(ISprite sprite)
        {
            sprites.Add(sprite);
        }
        public void ResetBlocks()
        {
            game = new List<IBlock>();
        }
        public void ResetSprites()
        {
            sprites = new List<ISprite>();
        }
        public bool IsOnScreen(EngineSprite sprite, float viewx, float viewy)
        {
            double posx = sprite.parent.position.x;
            double posy = sprite.parent.position.y;
            if (posx+sprite.size > -100+viewx && posx-sprite.size < 100+viewx && posy+sprite.size > -100+viewy && posy-sprite.size < 100+viewy)
            {
                return true;
            }
            return false;
        }
        public bool IsOnScreen(IBlock sprite, float viewx, float viewy)
        {
            foreach (PixElem elem in sprite.RenderGuide) {
                float posx = sprite.position.x + elem.xoff;
                float posy = sprite.position.y + elem.yoff;
                if (posx + elem.size > -100 + viewx && posx - elem.size < 100 + viewx && posy + elem.size > -100 + viewy && posy - elem.size < 100 + viewy)
                {
                    return true;
                }
            }
            return false;
        }
        public void RenderFrame(float camposx, float camposy)
        {
            // if not rendering
            if (!render)
            {
                foreach(ISprite s in sprites)
                {
                    s.size = 0;
                } 
                foreach(EngineSprite s in onScreen)
                {
                    if (!s.parent.IsStatic)
                    {
                        GameScene.gameSceneStatic.remove(s);
                    }
                }
            }
            if (render != previousRenderState && render)
            {
                foreach (ISprite s in sprites)
                {
                    s.size = s.BaseSize;
                }
                foreach (EngineSprite s in onScreen)
                {
                    if (!s.parent.IsStatic)
                    {
                        GameScene.gameSceneStatic.add(s);
                    }
                }
            }
            previousRenderState = render;

            Mouse.HandleActions();
            // SPRITES
            foreach (ISprite sprite in sprites)
            {
                if (sprite.positionType == PositionType.Relative)
                {
                    if (!sprite.onScreen)
                    {
                        sprite.onScreen = true;
                        Sprite s = new Sprite();
                        sprite.sprite = s;
                        s.position.x = sprite.position.x;
                        s.position.y = sprite.position.y;
                        s.image = sprite.img;
                        s.size = sprite.size;
                        s.color = sprite.color.toPixblocks();
                        GameScene.gameSceneStatic.add(s);
                    }
                    else
                    {
                        sprite.onRender();
                        sprite.sprite.position.x = sprite.position.x;
                        sprite.sprite.position.y = sprite.position.y;
                        sprite.sprite.size = sprite.size;
                    }
                }
            }

            // BLOCKS
            MouseState mouseState = Mouse.Handle();
            foreach (EngineSprite block in onScreen) {
                //!IsOnScreen(block, camposx, camposy) && !block.parent.IsStatic
                if ((!IsOnScreen(block, camposx, camposy)) && !block.parent.IsStatic)
                {
                    block.parent.onScreen = false;
                    GameScene.gameSceneStatic.remove(block);
                }
                if (block.parent.position.x-camposx != block.position.x || block.parent.position.y-camposy != block.position.y)
                {
                    block.position.x = block.parent.position.x+block.xoff-camposx;
                    block.position.y = block.parent.position.y+block.yoff-camposy;
                }

                // On Click
                if (mouseState.pressed)
                {
                        if (mouseState.position.x > block.position.x - block.size / 2 && mouseState.position.x < block.position.x + block.size / 2 &&
                            mouseState.position.y > block.position.y - block.size / 2 && mouseState.position.y < block.position.y + block.size / 2)
                        {
                            block.parent.onClick(mouseState.position.x, mouseState.position.y);
                        }
                }
            }
            foreach(IBlock block in game)
            {
                    if (IsOnScreen(block, camposx, camposy) && !block.onScreen)
                    {
                        block.onScreen = true;
                        bool first = true;
                        foreach (PixElem elem in block.RenderGuide)
                        {
                            EngineSprite blockSprite = new EngineSprite();
                            blockSprite.parent = block;
                            if (first)
                            {
                                first = false;
                                blockSprite.main = true;
                            }
                            blockSprite.image = elem.img;
                            blockSprite.size = elem.size;
                            blockSprite.color = elem.color.toPixblocks();
                            blockSprite.xoff = elem.xoff;
                            blockSprite.yoff = elem.yoff;
                            blockSprite.position = new PixVector(block.position.x + elem.xoff-camposx, block.position.y + elem.yoff-camposy);
                            GameScene.gameSceneStatic.add(blockSprite);
                            onScreen.Add(blockSprite);
                        }
                    }
                
            }
        }
    }
}
