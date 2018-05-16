using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot C of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorC : StaticSpriteA
    {
        // Old Bridge Floor

        public FloorC()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 73;
            SpriteY = 27;
        }

        public FloorC(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
