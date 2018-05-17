using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot J of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorJ : StaticSpriteC
    {
        // Right Old Clock Floor

        public FloorJ()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 115;
            SpriteY = 16;
        }

        public FloorJ(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}