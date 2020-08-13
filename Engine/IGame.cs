using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IGame
    {
        GameEngine engine { get; set; }
        void Start();
        void onRender();
    }
}
