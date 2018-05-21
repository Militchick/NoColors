using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.06 - Miguel Pastor (ChoosenCharacterScreen Class Complete)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class ChooseCharacterScreen : Screen
    {

        bool back;
        Images imgchoose;
        Audio audio;
        MainCharacterA characterA;
        MainCharacterB characterB;
        int chosenPlayer;
        IntPtr textChoose, textBack;

        //Contains initial screen (Image) with a submenu where you can choose:

        public ChooseCharacterScreen(Hardware hardware) : base(hardware)
        {
            back = false;
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[ChooseCharacterScreen].mp3");
            imgchoose = new Images("imgs/ChooseCharacter.gif", 1200, 740);
            imgchoose.MoveTo(0, 0);
        }

        public override void Show()
        {
            bool escPressed = false, spacePressed = false; //Only for Debug
            hardware.DrawImage(imgchoose);
            hardware.UpdateScreen();
            audio.PlayMusic(0, -1);

            if (spacePressed)
            {
                audio.StopMusic();
            }
            
            hardware.WriteText(textChoose, 327, 73);
            hardware.WriteText(textChoose, 517, 469);
        }

        // Choosing Player

        public int ChosenPlayer
        {
            get
            {
                return chosenPlayer;
            }
            set
            {
                if (value >= 1 && value <= 3)
                {
                    chosenPlayer = value;
                    switch (value)
                    {
                        case 1:
                            characterA = new Wario();
                            break;
                        case 2:
                            characterB = new Waluigi();
                            break;
                        case 3:
                            back = true;
                            if(back == true)
                            {
                                //IntroScreen(); [Back to the screen of before]
                            }
                            break;
                    }
                }
            }
        }
        //Contains a Fixed Image with Both Main Characters and the Words "Choose Character" Below



        //TODO And a Hand Image to Choose Character (With a Shadow Hand on the Character Un-selected)

    }
}
