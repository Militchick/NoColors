using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot H of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorH : StaticSpriteC
    {
        // Left Old Clock Floor (Continuous)

        public FloorH()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 92;
            SpriteY = 16; 
        }

        public FloorH(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}