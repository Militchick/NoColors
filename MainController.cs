using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.03 - Miguel Pastor (Added Screens to Show)
//V 0.02 - Miguel Pastor (Added Hardware Controller)
//V 0.01 - Miguel Pastor (Almost Empty Skeleton, added width and height of the screen)

namespace No_Colors
{
    class MainController
    {
        public const short SCREEN_WIDTH = 1200;
        public const short SCREEN_HEIGHT = 640;

        const float MOVEMENT_INCREMENT = 0.3f;
        const float MAX_VERTICAL_SPEED = 2.0f;
        const float VERTICAL_SPEED_DECREMENT = 0.015f;

        static void main(string[] args)
        {
            //Here will be the controller code to move 
            //"between screens with images" and the game

            Hardware hardware = new Hardware(1200, 740, 24, false);


            IntroScreen intro = new IntroScreen(hardware);
            CreditsScreen credits = new CreditsScreen(hardware);
            HelpScreen help = new HelpScreen(hardware);
            // ChooseCharacterScreen chooseCharacter = new ChooseCharacterScreen(hardware); 
            // [ACTUALLY ON GAMESCREEN, TODO PUT IT ON THEIR CLASS]
            GameScreen game;

            do
            {
                hardware.ClearScreen();
                intro.Show();
                if (!intro.GetExit())
                {
                    intro.Show();
                    if(intro.ChoseMenu == 1)
                    {
                        chooseCharacter.Show();
                        game = new GameScreen(hardware);
                        game.ChosenPlayer = chooseCharacter.GetChosenPlayer();
                        hardware.ClearScreen();
                        game.Show();
                        hardware.ClearScreen();
                    }
                    else if(intro.ChoseMenu == 2)
                    {
                        help.Show();
                        help = new HelpScreen(hardware);
                    }
                    else if(intro.ChoseMenu == 3)
                    {
                        credits.Show();
                        credits = new CreditsScreen(hardware);
                    }
                }
            }
            while (!intro.GetExit());
        }
    }
}
