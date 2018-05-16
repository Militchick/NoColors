using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot D of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorD : StaticSpriteA
    {
        // Old Chess Floor

        public FloorD()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 45;
            SpriteY = 36; 
        }

        public FloorD(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
