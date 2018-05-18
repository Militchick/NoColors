using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.03 - Miguel Pastor (Added Main Character)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class GameScreen : Screen
    {
        //TODO Add the Background, Audio and Level coming from other classes

        MainCharacterA characterA;
        MainCharacterB characterB;
        Level level;
        int chosenPlayer;
        Font font;
        Audio audio;
        IntPtr textTimer, textSpace;
        TopReturn top;
        
        // Choosing Player

        public int ChosenPlayer
        {
            get
            {
                return chosenPlayer;
            }
            set
            {
                if(value >= 1 && value <= 2)
                {
                    chosenPlayer = value;
                    switch(value)
                    {
                        case 1:
                            characterA = new Wario();
                            break;
                        case 2:
                            characterB = new Waluigi();
                            break;
                    }
                }
            }
        }

        public GameScreen(Hardware hardware) : base(hardware)
        {
            font = new Font("fonts/vga850.fon", 20);
            audio = new Audio(44100, 2, 4096);
            level = new Level("levels/level1.txt");
            if (level = ("levels/level1.txt")); //Trying something #1
            {
                audio.AddMusic("audio/[Level1].mp3");
            }
            else if (level = "levels/level2.txt") // #2
            {
                audio.AddMusic("audio/[Level2].mp3");
            }
            else if (level = "levels/level3.txt") // #3
            {
                audio.AddMusic("audio/[Level3].mp3");
            }
            else if (level = "levels/level4.txt") // #4
            {
                audio.AddMusic("audio/[Level4].mp3");
            }
            else if (level = "levels/level5.txt") // #5
            {
                audio.AddMusic("audio/[Level5].mp3");
            }
            initTexts();
        }

        public void DecreaseTime(Object o)
        {
            Sdl.SDL_Color black = new Sdl.SDL_Color(255, 255, 255);
            if (characterA.Lives > 0)
            {
                characterA.Time--;
                textTimer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "TIME: " + characterA.Time, black);
            }
            else if (characterB.Lives > 0)
            {
                characterB.Time--;
                textTimer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "TIME: " + characterB.Time, black);
            }
            else
            {
                if(top == true) //Bool to activate/deactivate de HiScore Screen
                {
                    PointsScreen.HiScore();
                }

                Images imgGameOver;
                imgGameOver = new Images("images/GameOverImage.png", 1200, 740);
                imgGameOver.MoveTo(0, 0);
                hardware.DrawImage(imgGameOver);
                hardware.UpdateScreen();
                textSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "PRESS SPACE TO CONTINUE...", black);
                while (hardware.KeyPress() != Hardware.KEY_SPACE) ;
            }
            
        }

        //TODO Add All that enters to the screen when the game is playing:

        //TODO Code to Kill Enemies if we Jump and Do Enemies Kill us if we collide laterally with them

        //TODO Finish preparing the actions of every item

        //TODO Move Enemies (Each type differently) 

        //TODO Move Main Character (Including jump), better said, prepare input

        //TODO Move items and give items to every item and enemies

        //TODO Check Collisions and update screen

        //TODO Add Pause Class Here

        //TODO Add Timer

        //TODO Add LoseLives Class and GameOver Class inside the "kill enemies comment" more or less
    }
}
