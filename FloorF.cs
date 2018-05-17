using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot F of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorF : StaticSpriteA
    {
        // Old Block Floor

        public FloorF()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 10;
            SpriteY = 0; 
        }

        public FloorF(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
