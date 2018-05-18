using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Tao.Sdl;

namespace No_Colors
{

//V.0.04 Miguel Pastor - Added ExitPoint

    class ExitPoint : StaticSpriteItemsA
    {
        public ushort Time { get; set; }

        public ExitPoint()
        {
            SpriteX = 195;
            SpriteY = 30;
            Time = 800;
        }

        public ExitPoint(short x, short y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
