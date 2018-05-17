using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot I of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorI : StaticSpriteC
    {
        // Right Old Clock Floor (Continuous)

        public FloorI()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 103;
            SpriteY = 16; 
        }

        public FloorI(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}