using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Added Hardware Controller)
//V 0.01 - Miguel Pastor (Almost Empty Skeleton, added width and height of the screen)

namespace No_Colors
{
    class MainController
    {
        public const short SCREEN_WIDTH = 1200;
        public const short SCREEN_HEIGHT = 640;

        public void MainScreen()
        {
            //TODO Here will be the controller code to move 
            //"between screens with images" and the game

            Hardware hardware = new Hardware(1200, 740, 24, false);
        }

    }
}
