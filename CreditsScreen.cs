using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using System.Threading;

//V 0.09 - Miguel Pastor (CreditsScreen)
//V 0.08 - Miguel Pastor (Almost All CreditsScreen)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class CreditsScreen : Screen
    {
        Audio audio;
        Image backCredits;
        Font fontm, fontb;
        //IntroScreen intro;
        MainController controller;

        public CreditsScreen(Hardware hardware) : base(hardware)
        {
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[CreditScreen].wav");
            backCredits = new Image("images/backCredits.gif", 1366, 698);
            controller = new MainController();
            fontm = new Font("fonts/vga850.fon", 18);
            fontb = new Font("fonts/vga850.fon", 24);
            backCredits.MoveTo(0, 0);
            Console.WriteLine("Reached Cred.Constructor");
        }

        //Contains a Fixed Image with names of all involved on the proyect(or all names in class)

        protected string[] bignames = { "Original game: Miguel Pastor",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "  ",
        "Project Boss: Nacho Cabanes" };

        protected string[] names = { //"Original game: Miguel Pastor",
        " ",
        "Brandon Blasco",
        "Javier Cases",
        "Marcos Cervantes",
        "Pedro Coloma",
        "Raul Gogna",
        "Moises Encinas",
        "Miguel Garcia Gil",
        "Almudena Lopez",
        "Cesar Martin",
        "Luis Martinez-Montalvo",
        "Gonzalo Martinez",
        "Daniel Miquel",
        "Guillermo Pastor",
        "Renata Pestana",
        "Angel Rebollo",
        "Querubin Santana",
        "Javier Saorin",
        "Luis Selles",
        "Victor Tebar",
        "Jose Vilaplana",
        "  " };
        //"Project Boss: Nacho Cabanes" };

        // Some Scroll
        protected short yText = 138;
        protected short startY = 698;
        protected bool finished = false;
        protected bool nextName = false;

        public void Show()
        {
            audio.PlayMusic(0, -1);

            while(!finished)
            {
                nextName = true;
                Console.WriteLine("Reached Cred. backCredits");

                hardware.ClearScreen();
                hardware.DrawImage(backCredits);
                hardware.UpdateScreen();

                int keyPressed = hardware.KeyPress();

                space();

                Hardware.WriteHiddenText("Credits", 512, 10, 0x00, 0x00, 0x00, fontb);
                yText = 40;
                for(int i = 0; i < names.Length; i++)
                {
                    for (int j = 0; j < names.Length; j++)
                    {
                        Hardware.WriteHiddenText(bignames[j], 500, (short)(startY + yText), 0x00, 0x00, 0x00, fontb);
                        yText += 22;
                        hardware.UpdateScreen();
                        space();

                    }
                    Hardware.WriteHiddenText(names[i], 500, (short)(startY + yText), 0x00, 0x00, 0x00, fontm);
                    yText += 22;
                    hardware.UpdateScreen();
                    space();
                }

                //That image also will have a message at the end saying "Press Space to Go Back"

                Hardware.WriteHiddenText("PRESS SPACE TO GO BACK...", 10, (short)(yText + 15), 0x00, 0x00, 0x00, fontm);

                Hardware.Pause(2000);
                hardware.UpdateScreen();

                if (startY < -800)
                    finished = true;
                
                startY -= 2;
                
                if ((finished == true) || (nextName = false))
                {
                    audio.StopMusic();
                    controller.Start();
                }
            }
        }

        public void space()
        {

            int keyPressed = hardware.KeyPress();

            if (keyPressed == Hardware.KEY_SPC)
                finished = true;
            
            if ((finished == true) || (nextName == false))
            {
                audio.StopMusic();
                controller.Start();
            }
        }

    }
}
