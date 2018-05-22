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
            imgintro = new Images("imgs/IntroScreen.png", 1200, 740);
            imgintro.MoveTo(0, 0);
        }

        public override void Show()
        {
            bool escPressed = false, spacePressed = false; //Only for Debug
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
                else if (keyPressed == Hardware.KEY_SPACE)
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
        
        //TODO Play the Game -> (To the ChooseCharacterScreen Class)

        //TODO Help -> (To the HelpScreen Class)

        //TODO Credits -> (To the CreditsScreen Class)

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
                        case 1:
                            choseCharacter = new ChooseCharacterScreen(hardware);
                            break;
                        case 2:
                            help = new HelpScreen();
                            break;
                        case 3:
                            credits = new CreditsScreen();
                            break;
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
