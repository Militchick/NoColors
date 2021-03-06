﻿using No_Colors;
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
        bool nomusic = false;
        bool change = false;
        bool spacePressed = false;
        bool exit = false;
        bool noexit = true;
        Image imgintro1, imgintro2, imgintro3, imgintro4, imgintrochange;
        Audio audio, WAV;
        ChooseCharacterScreen choseCharacter;
        IntroScreenSpa Spanish;
        HelpScreen help;
        CreditsScreen credits;
        int choseMenu = 1;

        //Contains initial screen (Image) with a submenu where you can choose:
        

        public IntroScreen(Hardware hardware) : base(hardware)
        {
            exit = false;
            audio = new Audio(44100, 2, 4096);
            WAV = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[IntroScreen].wav");
            WAV.AddWAV("audio/[Select].wav");
            imgintro1 = new Image("images/IntroScreen.png", 1366, 698);
            imgintro2 = new Image("images/IntroScreen_2.png", 1366, 698);
            imgintro3 = new Image("images/IntroScreen_3.png", 1366, 698);
            imgintro4 = new Image("images/IntroScreen_4.png", 1366, 698);
            imgintrochange = new Image("images/IntroScreen_Change.png", 1366, 698);
            imgintro1.MoveTo(0, 0);
            imgintro2.MoveTo(0, 0);
            imgintro3.MoveTo(0, 0);
            imgintro4.MoveTo(0, 0);
            imgintrochange.MoveTo(0, 0);
        }
        

        public override void Show()
        {
            //bool escPressed = false; //Only for Debug

            hardware.ClearScreen();
            hardware.DrawImage(imgintrochange);
            hardware.UpdateScreen();
            System.Threading.Thread.Sleep(1000);
            hardware.ClearScreen();
            hardware.DrawImage(imgintro1);
            hardware.UpdateScreen();
            int choseMenu = 1;
            Console.WriteLine("Value: " + choseMenu);

            Console.WriteLine("Playing Music...");

            audio.PlayMusic(0, -1);

            Console.WriteLine("Waiting input...");

            do
            {
                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_DOWN)
                {
                    if (choseMenu >= 1 && choseMenu <= 3)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        choseMenu++;

                        if (choseMenu == 2)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro2);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 3)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro3);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 4)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro4);
                            hardware.UpdateScreen();
                        }
                    }

                    Console.WriteLine("Value: " + choseMenu);
                }
                else if (keyPressed == Hardware.KEY_UP)
                {

                    if (choseMenu >= 2 && choseMenu <= 4)
                    {
                        WAV.PlayWAV(0, 1, 0);
                        choseMenu--;

                        if (choseMenu == 1)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro1);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 2)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro2);
                            hardware.UpdateScreen();
                        }
                        else if (choseMenu == 3)
                        {
                            hardware.ClearScreen();
                            hardware.DrawImage(imgintro3);
                            hardware.UpdateScreen();
                        }
                    }

                    Console.WriteLine("Value: " + choseMenu);
                }
                else if (keyPressed == Hardware.KEY_SPC)
                {
                    Console.WriteLine("Enter: " + choseMenu);

                    if (choseMenu != 4)
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
                else if (keyPressed == Hardware.KEY_S)
                {
                    change = true;
                }

                if (change == true)
                {
                    Spanish = new IntroScreenSpa(hardware);
                    Spanish.Show();
                }
                
            }
            while (spacePressed == false || change == false);

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
                Environment.Exit(0);
            }
            return exit;
        }
    }
}
