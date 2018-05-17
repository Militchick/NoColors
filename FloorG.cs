using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot G of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorG : StaticSpriteC
    {
        // Left Old Clock Floor

        public FloorG()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 79;
            SpriteY = 16;
        }

        public FloorG(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
