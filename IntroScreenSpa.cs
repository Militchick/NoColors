using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Colors
{
    class IntroScreenSpa : Screen
    {
        public bool nomusic2 = false;
        bool change = true;
        bool spacePressed = false;
        bool exit = false;
        bool noexit = true;
        Image imgintros1, imgintros2, imgintros3, imgintros4, imgintrochange;
        IntroScreen English;
        Audio audio, WAV;
        ChooseCharacterScreen choseCharacter;
        HelpScreen help;
        CreditsScreen credits;
        int choseMenu = 5;

        public IntroScreenSpa(Hardware hardware) : base(hardware)
        {
            exit = false;
            audio = new Audio(44100, 2, 4096);
            WAV = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[IntroScreen].wav");
            WAV.AddWAV("audio/[Select].wav");
            imgintros1 = new Image("images/IntroScreen_Spa.png", 1366, 698);
            imgintros2 = new Image("images/IntroScreen_Spa_2.png", 1366, 698);
            imgintros3 = new Image("images/IntroScreen_Spa_3.png", 1366, 698);
            imgintros4 = new Image("images/IntroScreen_Spa_4.png", 1366, 698);
            imgintrochange = new Image("images/IntroScreen_Change.png", 1366, 698);
            imgintros1.MoveTo(0, 0);
            imgintros2.MoveTo(0, 0);
            imgintros3.MoveTo(0, 0);
            imgintros4.MoveTo(0, 0);
            imgintrochange.MoveTo(0, 0);
        }

        public override void Show()
        {
            hardware.ClearScreen();
            hardware.DrawImage(imgintrochange);
            hardware.UpdateScreen();
            System.Threading.Thread.Sleep(1000);
            hardware.ClearScreen();
            hardware.DrawImage(imgintros1);
            hardware.UpdateScreen();
            int choseMenu = 5;
            Console.WriteLine("Value: " + choseMenu);

            do
            {
                int keyPressed = hardware.KeyPress();

                if (keyPressed == Hardware.KEY_DOWN)
                {
                    if (choseMenu >= 5 && choseMenu <= 7)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        choseMenu++;

                        if (choseMenu == 6)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros2);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 7)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros3);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 8)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros4);
                            hardware.UpdateScreen();
                        }
                    }

                    Console.WriteLine("Value: " + choseMenu);
                }
                else if (keyPressed == Hardware.KEY_UP)
                {

                    if (choseMenu >= 6 && choseMenu <= 8)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        choseMenu--;

                        if (choseMenu == 5)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros1);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 6)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros2);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 7)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintros3);
                            hardware.UpdateScreen();
                        }
                    }

                    Console.WriteLine("Value: " + choseMenu);
                }
                else if (keyPressed == Hardware.KEY_SPC)
                {
                    Console.WriteLine("Enter: " + choseMenu);

                    if (choseMenu != 8)
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
                else if (keyPressed == Hardware.KEY_E)
                {
                    change = false;
                    Console.WriteLine("change Value = false");
                }

                if (change == false)
                {
                    English = new IntroScreen(hardware);
                    nomusic2 = true;
                    English.Show();
                }

            } while (change == true || spacePressed == false);

            audio.StopMusic();
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

                if (value >= 5 && value <= 8)
                {
                    int keyPressed = hardware.KeyPress();
                    if (spacePressed == true)
                    {
                        switch (value)
                        {
                            //Play the Game -> (To the ChooseCharacterScreen Class)
                            case 5:
                                Console.WriteLine("Play Value:" + value);
                                choseCharacter = new ChooseCharacterScreen(hardware);
                                choseCharacter.Show();
                                break;
                            //Help -> (To the HelpScreen Class)
                            case 6:
                                Console.WriteLine("Help Value:" + value);
                                help = new HelpScreen(hardware);
                                help.Show();
                                break;
                            //Credits -> (To the CreditsScreen Class)
                            case 7:
                                Console.WriteLine("Credits Value:" + value);
                                credits = new CreditsScreen(hardware);
                                credits.Show();
                                break;
                            //Exit -> (Quit The Game)
                            case 8:
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
                Environment.Exit(0);
            }
            return exit;
        }
    }
}


