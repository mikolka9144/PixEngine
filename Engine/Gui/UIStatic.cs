using PixBlocks.PythonIron.Tools.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui
{
    public class UiStatic
    {
        public static string GetInput(string message)
        {
            return GameScene.gameSceneStatic.PythonCodeRunner.show(message);
        }
    }
}
