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

        bool spacePressed = false;
        bool exit = false;
        bool noexit = true;
        Image imgintro, imgLHand;
        Audio audio, WAV;
        ChooseCharacterScreen choseCharacter;
        HelpScreen help;
        CreditsScreen credits;
        int choseMenu = 1;
        float y = 61;

        //Contains initial screen (Image) with a submenu where you can choose:
        

        public IntroScreen(Hardware hardware) : base(hardware)
        {
            exit = false;
            audio = new Audio(44100, 2, 4096);
            WAV = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[IntroScreen].wav");
            WAV.AddWAV("audio/[Select].wav");
            imgintro = new Image("images/IntroScreen.png", 1366, 698);
            imgLHand = new Image("images/left_hand_light.gif", 100, 100);
            imgintro.MoveTo(0, 0);
        }

        public override void Show()
        {
            //bool escPressed = false; //Only for Debug

            audio.PlayMusic(0, -1);
            Selection();
            audio.StopMusic();
        }

        // Select Option (Only Space and Esc)


        public void Selection()
        {
            do
            {
                hardware.ClearScreen();
                hardware.DrawImage(imgintro);
                hardware.DrawImage(imgLHand);
                hardware.UpdateScreen();

                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_DOWN)
                {
                    if (choseMenu >= 1 && choseMenu <= 3)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        choseMenu++;
                        y += 250;
                    }

                    Console.WriteLine("Value: " + choseMenu + " Y: " + y);

                    imgLHand.MoveTo(60, (short)(imgLHand.Y));
                }
                else if (keyPressed == Hardware.KEY_UP)
                {

                    if (choseMenu >= 2 && choseMenu <= 4)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        y -= 250;
                        choseMenu--;
                    }

                    Console.WriteLine("Value: " + choseMenu + " Y: " + y);

                    imgLHand.MoveTo(60, (float)(imgLHand.Y));
                }
                else if (keyPressed == Hardware.KEY_SPC)
                {
                    Console.WriteLine("Enter: " + choseMenu);

                    if(choseMenu != 4)
                    {
                        noexit = true;
                        exit = false;
                        Console.WriteLine("ExitV1: " + exit);
                        Console.WriteLine("ExitV2: " + noexit);
                    }
                    else
                    {

                        exit = true;
                        noexit = false;
                        Console.WriteLine("ExitV1: " + exit);
                        Console.WriteLine("ExitV2: " + noexit);
                    }

                    spacePressed = true;
                }
            }
            while (spacePressed != true);
        }

        public int ChoseMenu
        {
            get
            {
                return choseMenu;
            }
            set
            {
                choseMenu = value;

                if (value >= 1 && value <= 4)
                {
                    int keyPressed = hardware.KeyPress();
                    if (spacePressed == true)
                    {
                        switch (value)
                        {
                            //Play the Game -> (To the ChooseCharacterScreen Class)
                            case 1:
                                Console.WriteLine("Play Value:" + value);
                                choseCharacter = new ChooseCharacterScreen(hardware);
                                choseCharacter.Show();
                                break;
                            //Help -> (To the HelpScreen Class)
                            case 2:
                                Console.WriteLine("Help Value:" + value);
                                help = new HelpScreen(hardware);
                                help.Show();
                                break;
                            //Credits -> (To the CreditsScreen Class)
                            case 3:
                                Console.WriteLine("Credits Value:" + value);
                                credits = new CreditsScreen(hardware);
                                credits.Show();
                                break;
                            //Exit -> (Quit The Game)
                            case 4:
                                Console.WriteLine("Exit Value:" + value);
                                GetExit();
                                break;
                        }
                    }
                }
            }
        }

        public bool GetExit()
        {
            if (exit == true && noexit == false)
            {
                Console.WriteLine("Quitting...");
                noexit = false;
            }
            return exit;
        }
    }
}
