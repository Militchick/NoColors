using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)
//TODO Class to Put Images for Differents Floors

namespace No_Colors
{
    class FloorP : StaticSpriteF
    {
        // Colorful Floor #3

        public FloorP()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 521; //TODO Find Sprite FloorX A
            SpriteY = 277; //TODO Find Sprite FloorY A
        }

        public FloorP(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}