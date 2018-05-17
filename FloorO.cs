using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Ready Slot O of Floor Tile)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class FloorO : StaticSpriteE
    {
        // Colorful Floor #2

        public FloorO()
        {
            //Don't Work Yet, must implement on other classes
            SpriteX = 507;
            SpriteY = 306;
        }

        public FloorO(short x, short y): this()
        {
            X = x;
            Y = y;
        }
    }
}
