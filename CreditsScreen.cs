using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.09 - Miguel Pastor (CreditsScreen)
//V 0.08 - Miguel Pastor (Almost All CreditsScreen)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class CreditsScreen : Screen
    {
        Audio audio;
        Images backCredits;
        Font fontm, fontb;
        IntroScreen intro;

        public CreditsScreen(Hardware hardware) : base(hardware)
        {
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[CreditsScreen].mp3");
            backCredits = new Images("images/backCredits.gif", 1200, 740);
            fontm = new Font("fonts/vga850.fon", 18);
            fontb = new Font("fonts/vga850.fon", 24);
            backCredits.MoveTo(0, 0);

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
        protected short yText = 40;
        protected short startY = 600;
        protected bool finished = false;
        protected bool nextName = false;

        public void Run()
        {
            while(!finished)
            {
                nextName = false;

                hardware.ClearScreen();
                Hardware.DrawHiddenImage(backCredits, 0, 0);
                Hardware.WriteHiddenText("Credits", 512, 10, 0x00, 0x00, 0x00, fontb);
                yText = 40;
                for(int i = 0; i < names.Length; i++)
                {
                    for (int j = 0; j < names.Length; j++)
                    {
                        Hardware.WriteHiddenText(bignames[j], 500, (short)(startY + yText), 0x00, 0x00, 0x00, fontb);
                        yText += 22;
                    }
                    Hardware.WriteHiddenText(names[i], 500, (short)(startY + yText), 0x00, 0x00, 0x00, fontm);
                    yText += 22;
                }

                //That image also will have a message at the end saying "Press Space to Go Back"

                Hardware.WriteHiddenText("PRESS SPACE TO GO BACK...", 10, (short)(yText + 15), 0x00, 0x00, 0x00, fontm);
                Hardware.ShowHiddenScreen();

                Hardware.Pause(20);
                if (hardware.IsKPressed(Hardware.KEY_SPC))
                    finished = true;
                if (startY < -800)
                    finished = true;
                
                startY -= 2;

                if((finished == true) || (nextName = false))
                {
                    audio.StopMusic();
                }
            }
        }

        //TODO [Fixed Image]

    }
}
