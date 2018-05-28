using No_Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.10 - Miguel Pastor (Trying to fix "Image not found" error, and added hand selection)
//V 0.03 - Miguel Pastor (Complete Main Menu)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class IntroScreen : Screen
    {

        bool exit;
        Image imgintro, imgLHand;
        Audio audio;
        ChooseCharacterScreen choseCharacter;
        HelpScreen help;
        CreditsScreen credits;
        int choseMenu = 1;
        int x = 21, y = 70;

        //Contains initial screen (Image) with a submenu where you can choose:
        

        public IntroScreen(Hardware hardware) : base(hardware)
        {
            exit = false;
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[IntroScreen].mp3");
            imgintro = new Image("images/IntroScreen.png", 1366, 768);
            imgLHand = new Image("images/left_hand_light.gif", 144, 144);
            imgintro.MoveTo(0, 0);
        }

        public override void Show()
        {
            bool escPressed = false; //Only for Debug
            bool spacePressed = false; 
            hardware.DrawImage(imgintro);
            imgLHand.MoveTo(x, y);
            hardware.DrawImage(imgLHand);
            hardware.UpdateScreen();
            audio.PlayMusic(0, -1);

            do
            {
                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_UP)
                {
                    choseMenu--;
                    imgLHand.MoveTo(x, y - 70);
                    hardware.DrawImage(imgLHand);
                }
                else if(keyPressed == Hardware.KEY_DOWN)
                {
                    choseMenu++;
                    imgLHand.MoveTo(x, y + 70);
                    hardware.DrawImage(imgLHand);
                }
                else if (keyPressed == Hardware.KEY_SPC)
                {
                    spacePressed = true;
                    exit = false;
                }
            }
            while (!escPressed && !spacePressed);
            audio.StopMusic();
        }

        // Select Option (Only Space and Esc)

        

        public bool GetExit()
        {
            return exit;
        }

        public int ChoseMenu
        {
            get
            {
                return choseMenu;
            }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    choseMenu = value;

                    int keyPressed = hardware.KeyPress();
                    if (keyPressed == Hardware.KEY_SPC)
                    {
                        switch (value)
                        {
                            //Play the Game -> (To the ChooseCharacterScreen Class)
                            case 1:
                                choseCharacter = new ChooseCharacterScreen(hardware);
                                break;
                            //Help -> (To the HelpScreen Class)
                            case 2:
                                help = new HelpScreen(hardware);
                                break;
                            //Credits -> (To the CreditsScreen Class)
                            case 3:
                                credits = new CreditsScreen(hardware);
                                break;
                            //Exit -> (Quit The Game)
                            case 4:
                                GetExit();
                                break;
                        }
                    }
                }
            }
        }
    }
}
