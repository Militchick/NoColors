using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.08 - Miguel Pastor (Almost All CreditsScreen)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class CreditsScreen : Screen
    {

        Images backCredits;
        Font fontm, fontb;

        public CreditsScreen(bool updating)
        {
            if(updating)
            {
                backCredits = new Images("credits/imgs/backCredits.gif",1200, 740);
                fontm = new Font("fonts/vga850.fon", 18);
                fontb = new Font("fonts/vga850.fon", 24);
            }
            else
            {
                backCredits = new Images("credits/imgsupdate/backCredits.gif", 1200, 740);
                fontm = new Font("fonts/vga850.fon", 18);
                fontb = new Font("fonts/vga850.fon", 24);
            }
        }

        //Contains a Fixed Image with names of all involved on the proyect(or all names in class)

        protected string[] names = { "Original game: Miguel Pastor",
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
        "  ",
        "Project Boss: Nacho Cabanes" };

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
                hardware.DrawHiddenImage(backCredits, 0, 0); //TODO Implement All Hardware Methods
                hardware.WriteHiddenText("Credits", 512, 10, 0x00, 0x00, 0x00, fontb);
                yText = 40;
                for(int i = 0; i < names.Length; i++)
                {
                    hardware.WrittenHiddenText(names[i], 500, (short)(startY + yText), 0x00, 0x00, 0x00, fontm);
                    yText += 22;
                }

                hardware.WriteHiddenText("PRESS SPACE TO GO BACK...", 10, (short)(yText + 15), 0x00, 0x00, 0x00, fontm);
                hardware.ShowHiddenScreen();

                hardware.Pause(20);
                if (hardware.KeyPressed(hardware.KEY_SPC))
                    finished = true;
                if (startY < -800)
                    finished = true;

                startY -= 2;
            }
        }

        //TODO [Fixed Image]

        //That image also will have a message at the end saying "Press Space to Go Back"

    }
}
