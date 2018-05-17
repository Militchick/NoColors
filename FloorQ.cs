using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot Q of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    // Base Colorful Floor

    class FloorQ : StaticSpriteG
    {
        public FloorQ()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 702; 
            SpriteY = 411; 
        }

        public FloorQ(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}