using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot A of Wall Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class WallA : StaticSpriteA
    {
        // Left Old Lower Veggie Wall

        public WallA()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 55;
            SpriteY = 45; 
        }

        public WallA(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
