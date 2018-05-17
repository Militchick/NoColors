using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot K of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorK : StaticSpriteA
    {
        // Left Old Veggie Floor

        public FloorK()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 55;
            SpriteY = 36; 
        }

        public FloorK(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}