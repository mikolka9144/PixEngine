using PixBlocks.PythonIron.Tools.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interaction
{
    public class KeyboardHandler
    {
        List<Key> keys;
        public KeyboardHandler()
        {
            keys = new List<Key>();
        }
        public void AddListener(String key, Action onClick)
        {
            Key Listener = new Key(key, onClick);
            keys.Add(Listener);
        }
        public void Handle()
        {
            GameScene game = GameScene.gameSceneStatic;
            foreach(Key key in keys)
            {
                if (game.key(key.key))
                {
                    key.action();
                }
            }
        }
    }
    public class Key
    {
        public String key;
        public Action action;
        public Key(String key, Action action)
        {
            this.key = key;
            this.action = action;
        }
    }
}
