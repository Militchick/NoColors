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
        //Contains a Fixed Image with Both Main Characters and the Words "Choose Character" Below

        Images imgchoose, imgLHand, imgLNoHand, imgRHand,imgRNoHand;
        Audio audio;
        MainCharacterA characterA;
        MainCharacterB characterB;
        int chosenPlayer = 1;
        IntPtr textChoose, textBack;

        //Contains initial screen (Image) with a submenu where you can choose:

        public ChooseCharacterScreen(Hardware hardware) : base(hardware)
        {
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[ChooseCharacterScreen].mp3");
            imgchoose = new Images("imgs/ChooseCharacter.gif", 1200, 740);
            imgLHand = new Images("imgs/left_hand_light.gif", 144, 144);
            imgLNoHand = new Images("imgs/left_hand_dark.gif", 144, 144);
            imgRHand = new Images("imgs/right_hand_light.gif", 144, 144);
            imgRNoHand = new Images("imgs/right_hand_dark.gif", 144, 144);
            imgchoose.MoveTo(0, 0);
            //TODO Coordinates X, Y Hands
        }

        public override void Show()
        {
            //bool escPressed = false; [Only for Debug]
            bool spacePressed = false; 
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

        //TODO And a Hand Image to Choose Character (With a Shadow Hand on the Character Un-selected)
    }

}
