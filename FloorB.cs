using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot B of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorB : StaticSpriteA
    {
        // Old Passage Floor

        public FloorB()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 18;
            SpriteY = 27;
        }

        public FloorB(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
