using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot A of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorA : StaticSpriteA
    {
        // Old Grass Floor

        public FloorA()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 0;
            SpriteY = 28;
        }

        public FloorA(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
