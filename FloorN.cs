using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)
//TODO Class to Put Images for Differents Floors

namespace No_Colors
{
    class FloorN : StaticSpriteD
    {
        // Colorful Floor #1

        public FloorN()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 413; 
            SpriteY = 307; 
        }

        public FloorN(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}