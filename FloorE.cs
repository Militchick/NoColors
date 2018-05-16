using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)
//TODO Class to Put Images for Differents Floors

namespace No_Colors
{
    class FloorE : StaticSpriteA
    {
        // Old Block Eyes Floor

        public FloorE()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 82;
            SpriteY = 45;
        }

        public FloorE(short x, short y) : this()
        {
            X = x;
            Y = y;
        }
    }
}