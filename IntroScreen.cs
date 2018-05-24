using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.03 - Miguel Pastor (Complete Main Menu)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class IntroScreen : Screen
    {

        bool exit;
        Images imgintro;
        Audio audio;
        ChooseCharacterScreen choseCharacter;
        HelpScreen help;
        CreditsScreen credits;
        int choseMenu;

        //Contains initial screen (Image) with a submenu where you can choose:

        public IntroScreen(Hardware hardware) : base(hardware)
        {
            exit = false;
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[IntroScreen].mp3");
            imgintro = new Images("images/IntroScreen.png", 1200, 740);
            imgintro.MoveTo(0, 0);
        }

        public override void Show()
        {
            bool escPressed = false; //Only for Debug
            bool spacePressed = false; 
            hardware.DrawImage(imgintro);
            hardware.UpdateScreen();
            audio.PlayMusic(0, -1);

            do
            {
                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_ESC)
                {
                    escPressed = true;
                    exit = true;
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
                if (value >= 1 && value <= 2)
                {
                    choseMenu = value;
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

        //TODO The Hand (with their Shadow Hands) will be used to select option
    }
}
