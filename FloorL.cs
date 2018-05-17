using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot L of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorL : StaticSpriteA
    {
        // Right Old Veggie Floor

        public FloorL()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 64; 
            SpriteY = 36; 
        }

        public FloorL(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}