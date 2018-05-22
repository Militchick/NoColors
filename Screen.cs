using System;
using System.Collections.Generic;
using System.Linq;

//V 0.03 - Miguel Pastor (Screen Class now Difference Between Screens)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class Screen
    {
        //Screen Class to Show a Different Screen
        //On the game

        protected Hardware hardware;

        public Screen (Hardware hardware)
        {
            this.hardware = hardware;
        }

        public virtual void Show()
        {
        }

    }
}
