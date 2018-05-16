using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)
//TODO Class to Put Images for Differents Floors

namespace No_Colors
{
    class FloorI : StaticSpriteC
    {
        // Right Old Clock Floor (Continuous)

        public FloorI()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 103;
            SpriteY = 16; 
        }

        public FloorI(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}