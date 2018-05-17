using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot B of Wall Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class WallB : StaticSpriteA
    {
        // Right Old Lower Veggie Wall

        public WallB()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 64;
            SpriteY = 45;
        }

        public WallB(short x, short y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
