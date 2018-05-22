using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using No_Colors;

//V 0.07 - Miguel Pastor (Fixed Third Option of Menu that don't let go back to IntroScreen)
//V 0.06 - Miguel Pastor (ChoosenCharacterScreen Class Complete)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class ChooseCharacterScreen : Screen
    {

        Images imgchoose;
        Audio audio;
        MainCharacterA characterA;
        MainCharacterB characterB;
        int chosenPlayer;
        IntPtr textChoose, textBack;

        //Contains initial screen (Image) with a submenu where you can choose:

        public ChooseCharacterScreen(Hardware hardware) : base(hardware)
        {
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

        public int GetChosenPlayer()
        {
            return chosenPlayer;
        }

        //Contains a Fixed Image with Both Main Characters and the Words "Choose Character" Below



        //TODO And a Hand Image to Choose Character (With a Shadow Hand on the Character Un-selected)
    }

}
