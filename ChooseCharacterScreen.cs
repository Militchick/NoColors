using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using No_Colors;

//V 0.11 - Miguel Pastor (Found a way to know Images errors)
//V 0.10 - Miguel Pastor (Trying to fix "Image not found" error and added hand selections)
//V 0.07 - Miguel Pastor (Fixed Third Option of Menu that don't let go back to IntroScreen)
//V 0.06 - Miguel Pastor (ChoosenCharacterScreen Class Complete)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class ChooseCharacterScreen : Screen
    {
        //Contains a Fixed Image with Both Main Characters and the Words "Choose Character" Below

        Image imgchoose, imgLHand, imgLNoHand, imgRHand,imgRNoHand;
        Audio audio;
        /*MainCharacterA characterA;
        MainCharacterB characterB;*/
        int chosenPlayer = 1;
        IntPtr textChoose; /*textBack;*/

        //Contains initial screen (Image) with a submenu where you can choose:

        public ChooseCharacterScreen(Hardware hardware) : base(hardware)
        {
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[ChooseCharacterScreen].mp3");
            imgchoose = new Image("images/ChooseCharacter.gif", 1200, 740);
            imgLHand = new Image("images/left_hand_light.gif", 144, 144);
            imgLNoHand = new Image("images/left_hand_dark.gif", 144, 144);
            imgRHand = new Image("images/right_hand_light.png", 144, 144);
            imgRNoHand = new Image("images/right_hand_dark.gif", 144, 144);
            imgchoose.MoveTo(0, 0);
        }

        public override void Show()
        {
            //bool escPressed = false; [Only for Debug]
            hardware.DrawImage(imgchoose);
            hardware.UpdateScreen();
            audio.PlayMusic(0, -1);

            int keyPressed = hardware.KeyPress();
            if (keyPressed == Hardware.KEY_LEFT && chosenPlayer > 1)
            {
                 //audio.PlayWAV(0, 1, 0);
                 chosenPlayer = 1;
                 imgLHand.MoveTo(233, 223);
                 imgRNoHand.MoveTo(955, 223);
            }
            else if (keyPressed == Hardware.KEY_RIGHT && chosenPlayer < 2)
            {
                 //audio.PlayWAV(0, 1, 0);
                 chosenPlayer = 2;
                 imgLNoHand.MoveTo(233, 223);
                 imgRHand.MoveTo(955, 223);
            }
            else if (keyPressed == Hardware.KEY_SPC)
            {
                audio.StopMusic();
                GetChosenPlayer();
            }
            
            hardware.WriteText(textChoose, 327, 73);
            hardware.WriteText(textChoose, 517, 469);
        }

        // Choosing Player

        public int GetChosenPlayer()
        {
            return chosenPlayer;
        }
    }

}
