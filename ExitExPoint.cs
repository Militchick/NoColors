using System;
using System.Collections.Generic;
using System.Linq;



namespace No_Colors
{
    //V.0.04 Miguel Pastor - Added ExitExPoint

    class ExitExPoint : StaticSpriteItemsB
    {
        public ushort Time { get; set; }

        public ExitExPoint()
        {
            SpriteX = 20;
            SpriteY = 25;
            Time = 2500;
        }

        public ExitExPoint(short x, short y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
