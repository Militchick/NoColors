using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using No_Colors;
using System.Threading;

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

        Image imgchoose1, imgchoose2, imgLHand, imgLNoHand, imgRHand,imgRNoHand;
        Audio audio;
        /*MainCharacterA characterA;
        MainCharacterB characterB;*/
        int chosenPlayer = 1;
        bool noChange = false;

        //Contains initial screen (Image) with a submenu where you can choose:

        public ChooseCharacterScreen(Hardware hardware) : base(hardware)
        {
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[ChooseCharacterScreen].wav");
            audio.AddMusic("audio/[Smash].wav");
            imgchoose1 = new Image("images/ChooseCharacterA1.gif", 1366, 698);
            imgchoose2 = new Image("images/ChooseCharacterA2.gif", 1366, 698);
            imgLHand = new Image("images/left_hand_light.gif", 100, 100);
            imgLNoHand = new Image("images/left_hand_dark.gif", 100, 100);
            imgRHand = new Image("images/right_hand_light.png", 100, 100);
            imgRNoHand = new Image("images/right_hand_dark.gif", 100, 100);
            imgchoose1.MoveTo(0, 0);
            imgchoose2.MoveTo(0, 0);
        }

        public override void Show()
        {
            audio.PlayMusic(0, -1);
            //bool escPressed = false; [Only for Debug]

                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_LEFT && chosenPlayer > 1)
                {
                    audio.PlayWAV(0, 1, 0);
                    chosenPlayer = 1;
                    hardware.ClearScreen();
                    imgLHand.MoveTo(233, 223);
                    imgRNoHand.MoveTo(955, 223);
                    hardware.DrawImage(imgLHand);
                    hardware.DrawImage(imgRNoHand);
                    hardware.UpdateScreen();
                }
                else if (keyPressed == Hardware.KEY_RIGHT && chosenPlayer < 2)
                {
                    audio.PlayWAV(0, 1, 0);
                    chosenPlayer = 2;
                    hardware.ClearScreen();
                    imgLNoHand.MoveTo(233, 223);
                    imgRHand.MoveTo(955, 223);
                    hardware.DrawImage(imgLNoHand);
                    hardware.DrawImage(imgRHand);
                    hardware.UpdateScreen();
                }
                else if (keyPressed == Hardware.KEY_SPC)
                {
                    audio.StopMusic();
                    noChange = true;
                    GetChosenPlayer();
                }

            Animation();
        }

        // Choosing Player

        public int GetChosenPlayer()
        {
            return chosenPlayer;
        }

        //Animting Text

        public void Animation()
        {

            while(noChange != true)
            {
                hardware.ClearScreen();
                hardware.DrawImage(imgchoose1);
                hardware.UpdateScreen();
                Thread.Sleep(200);
                hardware.ClearScreen();
                hardware.DrawImage(imgchoose2);
                hardware.UpdateScreen();
                Thread.Sleep(200);
            }
            
        }
    }

}
