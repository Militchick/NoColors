using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{

    class PointsScreen
    {

        //This Special Screen Only Shows After a Game Over Screen or When You Win All Levels

        bool Top = false;



        public static void HiScore()
        {

        }

        public bool TopReturn(bool Top)
        {
            return Top;
        }

        //TODO Contains All Ten Hi-Scores using a comparation between them inside a file called "HiScores"
        //At the end of all scores must appear "Press Space to Continue" and go to the IntroScreen Again

    }
}
