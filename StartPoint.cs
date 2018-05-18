using System;
using System.Collections.Generic;
using System.Linq;

// V. 0.04 Miguel Pator - Added a StartPoint Class to use on file levels

namespace No_Colors
{
    class StartPoint: StaticSpriteMC
    {
        public StartPoint(short x, short y)
        {
            X = x;
            Y = y;
        }
    }
}
