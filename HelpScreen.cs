using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.08 - Miguel Pastor (HelpScreen)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class HelpScreen : Screen
    {
        IntPtr textSpace;
        bool back;
        Audio audio;
        IntroScreen intro;
        Image imgHelp;
        Font font;

        public HelpScreen(Hardware hardware) : base(hardware)
        {
            back = false;
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("audio/[HelpScreen].mp3");
            imgHelp = new Image("images/HelpScreen.gif", 1200, 740);
            imgHelp.MoveTo(0, 0);
        }

        public override void Show()
        {
            //Contains a Fixed Image explaining the game (With words)
            hardware.DrawImage(imgHelp);
            hardware.UpdateScreen();

            //That image also will have a message saying "Press Space to Go Back"
            Sdl.SDL_Color white = new Sdl.SDL_Color(0, 0, 0);
            textSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "PRESS SPACE TO GO BACK...", white);
            audio.PlayMusic(0, -1);

            do
            {
                int keyPressed = hardware.KeyPress();
                if (keyPressed == Hardware.KEY_SPC)
                {
                    back = true;
                    intro.Show();
                }
            }
            while (back == true);

            back = false;
        }
    }
}
