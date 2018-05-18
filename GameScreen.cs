using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using System.IO;
//V 0.05 - Miguel Pastor (Added PointScreen, Move of Main Character)
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
        IntPtr textTimer, textSpace, textLives;
        bool top = false;
        int points, force, Gravity;
        Boolean Player_Jump;
        
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
            if (level = ("levels/level1.txt")) //Trying something #1
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
                if((HiScore()) > points) //TODO Convert numbers of HiScore to Int
                {
                    top = true;
                }

                if(top == true) //Bool to activate/deactivate de HiScore Screen
                {
                    HiScore();
                    while (hardware.KeyPress() != Hardware.KEY_SPACE) ;
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

        //CLASS HI-SCORE VERSIONS
        //V 0.05 - Miguel Pastor (Added Point Screen Class)
        //V 0.01 - Miguel Pastor (Empty Skeleton)

        private void HiScore()
        {
            List<GameScreen> Top10 = new List<GameScreen>();

            if (!File.Exists("hiscore.dat"))
            {
                StreamWriter output = File.AppendText("hiscore.dat");
                output.Close();
            }
            else
            {
                try
                {
                    StreamWriter output = File.AppendText("hiscore.dat");
                    StreamReader input = File.OpenText("hiscore.dat");
                    string line;
                    int ten = 10;

                    do
                    {
                        line = input.ReadLine();
                        if (line != null)
                        {
                            output.WriteLine(line.ToUpper());
                            ten--;
                        }
                    }
                    while ((line != null) || (ten == 0));

                    input.Close();
                    output.Close();
                }
                catch (PathTooLongException PE)
                {
                    throw PE;
                }
                catch (IOException IO)
                {
                    throw IO;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private void initTexts()
        {
            Sdl.SDL_Color black = new Sdl.SDL_Color(255, 255, 255);
            Sdl.SDL_Color white = new Sdl.SDL_Color(0, 0, 0);
            textLives = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "LIVES: ", white);
            textTimer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "TIMER: ", black);
            if (textLives == IntPtr.Zero || textTimer == IntPtr.Zero)
                Environment.Exit(5);
        }


        //TODO Add All that enters to the screen when the game is playing:

        //TODO Code to Kill Enemies if we Jump and Do Enemies Kill us if we collide laterally with them

        //TODO Finish preparing the actions of every item

        //TODO Move Enemies (Each type differently) 

        //IN PROGRESS Move Main Character (Including jump), better said, prepare input

        private void moveCharacter()
        {
            bool left = hardware.IsKPressed(Hardware.KEY_LEFT);
            bool right = hardware.IsKPressed(Hardware.KEY_RIGHT);
            bool space = hardware.IsKPressed(Hardware.KEY_SPACE);

            if (left)
            {
                if (characterA.X > 0)
                {
                    characterA.X -= characterA.STEP_LENGTH;
                    if (level.XMap1 > 0)
                        level.XMap1 -= characterA.STEP_LENGTH;
                    if (level.XMap2 > 0)
                        level.XMap2 -= characterA.STEP_LENGTH;
                    if (level.XMap3 > 0)
                        level.XMap3 -= characterA.STEP_LENGTH;
                    if (level.XMap4 > 0)
                        level.XMap4 -= characterA.STEP_LENGTH;
                    if (level.XMap5 > 0)
                        level.XMap5 -= characterA.STEP_LENGTH;
                    if (level.XMap6 > 0)
                        level.XMap6 -= characterA.STEP_LENGTH;
                }


                if (characterB.X > 0)
                {
                    characterB.X -= characterB.STEP_LENGTH;
                    if (level.XMap1 > 0)
                        level.XMap1 -= characterB.STEP_LENGTH;
                    if (level.XMap2 > 0)
                        level.XMap2 -= characterB.STEP_LENGTH;
                    if (level.XMap3 > 0)
                        level.XMap3 -= characterB.STEP_LENGTH;
                    if (level.XMap4 > 0)
                        level.XMap4 -= characterB.STEP_LENGTH;
                    if (level.XMap5 > 0)
                        level.XMap5 -= characterB.STEP_LENGTH;
                    if (level.XMap6 > 0)
                        level.XMap6 -= characterB.STEP_LENGTH;
                }
            }
            if (left)
            {
                if (characterA.X < level.Width - SpriteCharacter.SPRITECA_WIDTH)
                {
                    characterA.X += characterA.STEP_LENGTH;
                    if (level.XMap1 < 0)
                        level.XMap1 += characterA.STEP_LENGTH;
                    if (level.XMap2 < 0)
                        level.XMap2 += characterA.STEP_LENGTH;
                    if (level.XMap3 < 0)
                        level.XMap3 += characterA.STEP_LENGTH;
                    if (level.XMap4 < 0)
                        level.XMap4 += characterA.STEP_LENGTH;
                    if (level.XMap5 < 0)
                        level.XMap5 += characterA.STEP_LENGTH;
                    if (level.XMap6 < 0)
                        level.XMap6 += characterA.STEP_LENGTH;
                }


                if (characterB.X < level.Width - SpriteCharacter.SPRITECA_WIDTH)
                {
                    characterB.X -= characterB.STEP_LENGTH;
                    if (level.XMap1 > 0)
                        level.XMap1 -= characterB.STEP_LENGTH;
                    if (level.XMap2 > 0)
                        level.XMap2 -= characterB.STEP_LENGTH;
                    if (level.XMap3 > 0)
                        level.XMap3 -= characterB.STEP_LENGTH;
                    if (level.XMap4 > 0)
                        level.XMap4 -= characterB.STEP_LENGTH;
                    if (level.XMap5 > 0)
                        level.XMap5 -= characterB.STEP_LENGTH;
                    if (level.XMap6 > 0)
                        level.XMap6 -= characterB.STEP_LENGTH;
                }
            }
            if (space)
            {
                Force = Gravity;
                Player_Jump = true;
            }
        }

        //Code to fall after jump

        private void timer_Gravity_Tick(object sender, EventArgs e)
        {
            if(!Player_Jump && pb_Player.Location.Y +
                pb_Player.Height < WorldFrame.Height - 2 
                && !Collision_Top(pb_Player))
            {
                pb_Player.Top += Speed_Fall;
            }

            if(!Player_Jump && pb_Player.Location.Y +pb_Player.Height > WorldFrame.Height - 1)
            {
                pb_Player.Top--;
            }
        }

        //Code to jump (IN PROGRESS)

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if(Force > 0)
            {

            }
        }

        //TODO Move items and give items to every item and enemies

        //TODO Check Collisions and update screen

        //TODO Add Pause Class Here

        //TODO Add Timer

        //TODO Add LoseLives Class and GameOver Class inside the "kill enemies comment" more or less
    }
}
