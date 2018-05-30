using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tao.Sdl;

//V 0.08 - Miguel Pastor (HelpScreen)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class HelpScreen : Screen
    {
        IntPtr textSpace;
        bool back = false;
        Audio audio;
        //IntroScreen intro;
        MainController controller;
        Image imgHelp;
        Font font;

        public HelpScreen(Hardware hardware) : base(hardware)
        {
            back = false;
            audio = new Audio(44100, 2, 4096);
            //intro = new IntroScreen(hardware);
            controller = new MainController();
            audio.AddMusic("audio/[HelpScreen].wav");
            font = new Font("fonts/vga850.fon", 24);
            imgHelp = new Image("images/HelpScreen.gif", 1366, 698);
            imgHelp.MoveTo(0, 0);
        }

        public override void Show()
        {
            //Contains a Fixed Image explaining the game (With words)
            hardware.DrawImage(imgHelp);
            hardware.UpdateScreen();
            audio.PlayMusic(0, -1);
            
            do
            {
                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_SPC)
                {
                    back = true;
                    controller.Start();
                }
            }
            while (back != true);

            back = false;
        }
    }
}
