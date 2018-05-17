using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.03 - Miguel Pastor (Added Main Character)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class GameScreen : Screen
    {
        //TODO Add the Background, Audio and Level coming from other classes

        MainCharacterA characterA;
        MainCharacterB characterB;
        Level level;
        int chosenPlayer;
        Font font;
        Audio audio;
        IntPtr textTimer;
        
        // Choosing Player

        public int ChosenPlayer
        {
            get
            {
                return chosenPlayer;
            }
            set
            {
                if(value >= 1 && value <= 2)
                {
                    chosenPlayer = value;
                    switch(value)
                    {
                        case 1:
                            characterA = new Wario();
                            break;
                        case 2:
                            characterB = new Waluigi();
                            break;
                    }
                }
            }
        }

        //TODO Add All that enters to the screen when the game is playing:

        //TODO Code to Kill Enemies if we Jump and Do Enemies Kill us if we collide laterally with them

        //TODO Finish preparing the actions of every item

        //TODO Move Enemies (Each type differently) 

        //TODO Move Main Character (Including jump), better said, prepare input

        //TODO Move items and give items to every item and enemies

        //TODO Check Collisions and update screen

        //TODO Add Pause Class Here

        //TODO Add Timer

        //TODO Add LoseLives Class and GameOver Class inside the "kill enemies comment" more or less
    }
}
