using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using System.IO;
using System.Threading;
using No_Colors;

//V 0.08 - Miguel Pastor (Added a First Version of Pause Submenu)
//V 0.07 - Miguel Pastor (Adding to Level and GameScreen Items [IN PROGRESS])
//V 0.06 - Miguel Pastor (Deleted ChooseCharacter Method from here
//                          and added to a class, timer IN PROGRESS)
//V 0.05 - Miguel Pastor (Added PointScreen, Move of Main Character)
//V 0.03 - Miguel Pastor (Added Main Character)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class GameScreen : Screen
    {
        //Add the Background, Audio and Level coming from other classes

        public const short SCREEN_WIDTH = 1200;
        public const short SCREEN_HEIGHT = 640;

        const int CHARACTER_SPRITE_HEIGHT = 35;
        const int CHARACTER_SPRITE_WIDTH = 27;

        const int SPRITE_MAX_COUNT = 50;

        const float MOVEMENT_INCREMENT = 0.3f;
        const float MAX_VERTICAL_SPEED = 2.0f;
        const float VERTICAL_SPEED_DECREMENT = 0.015f;

        MainCharacterA characterA;
        MainCharacterB characterB;
        Level level;
        int chosenPlayer;
        Font font;
        Audio audio;
        IntPtr textTimer, textSpace, textLives, textPause;
        bool top = false;
        int points;
        bool back = false;
        IntroScreen intro;


        public GameScreen(Hardware hardware) : base(hardware)
        {
            font = new Font("fonts/vga850.fon", 20);
            audio = new Audio(44100, 2, 4096);
            level = new Level("levels/level1.txt");
            if (level == new Level ("levels/level1.txt")) //Trying something #1
            {
                audio.AddMusic("audio/[Level1].mp3");
            }
            else if (level == new Level ("levels/level2.txt")) // #2
            {
                audio.AddMusic("audio/[Level2].mp3");
            }
            else if (level == new Level ("levels/level3.txt")) // #3
            {
                audio.AddMusic("audio/[Level3].mp3");
            }
            else if (level == new Level ("levels/level4.txt")) // #4
            {
                audio.AddMusic("audio/[Level4].mp3");
            }
            else if (level == new Level ("levels/level5.txt")) // #5
            {
                audio.AddMusic("audio/[Level5].mp3");
            }
            else if (level == new Level ("levels/levelend.txt")) // #FinalLevel
            {
                audio.AddMusic("audio/[EndScreens].mp3");
                audio.AddMusic("audio/[EndScreens2].mp3");
            }
            initTexts();
        }

        //Choosing Player

        public int ChosenPlayer
        {
            get
            {
                return chosenPlayer;
            }
            set
            {
                if (value >= 1 && value <= 3)
                {
                    chosenPlayer = value;
                    switch (value)
                    {
                        case 1:
                            characterA = new Wario();
                            break;
                        case 2:
                            characterB = new Waluigi();
                            break;
                        case 3:
                            back = true;
                            if (back == true)
                            {
                                back = false;
                                MainController.intro.Show(); //[Back to the screen of before]
                            }
                            break;
                    }
                }
            }
        }

        //Add Timer

        public void DecreaseTime(Object o)
        {
            Sdl.SDL_Color black = new Sdl.SDL_Color(255, 255, 255);
            Sdl.SDL_Color white = new Sdl.SDL_Color(0, 0, 0);
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
                textSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "PRESS SPACE TO CONTINUE...", white);
                while (hardware.KeyPress() != Hardware.KEY_SPACE) ;
            }
            
        }

        private void tick(ref DateTime timestock)
        {
            if ((DateTime.Now - timestock).TotalMilliseconds > DAMAGE_INTERVAL)
            {
                timestock = DateTime.Now;
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
                if (characterA.Y < level.Width - SpriteCharacter.SPRITECA_WIDTH)
                {
                    characterA.Y += characterA.STEP_LENGTH;
                    if (level.YMap1 < 0)
                        level.YMap1 += characterA.STEP_LENGTH;
                    if (level.YMap2 < 0)
                        level.YMap2 += characterA.STEP_LENGTH;
                    if (level.YMap3 < 0)
                        level.YMap3 += characterA.STEP_LENGTH;
                    if (level.YMap4 < 0)
                        level.YMap4 += characterA.STEP_LENGTH;
                    if (level.YMap5 < 0)
                        level.YMap5 += characterA.STEP_LENGTH;
                    if (level.YMap6 < 0)
                        level.YMap6 += characterA.STEP_LENGTH;
                }


                if (characterB.Y < level.Width - SpriteCharacter.SPRITECA_WIDTH)
                {
                    characterB.Y -= characterB.STEP_LENGTH;
                    if (level.YMap1 > 0)
                        level.YMap1 -= characterB.STEP_LENGTH;
                    if (level.YMap2 > 0)
                        level.YMap2 -= characterB.STEP_LENGTH;
                    if (level.YMap3 > 0)
                        level.YMap3 -= characterB.STEP_LENGTH;
                    if (level.YMap4 > 0)
                        level.YMap4 -= characterB.STEP_LENGTH;
                    if (level.YMap5 > 0)
                        level.YMap5 -= characterB.STEP_LENGTH;
                    if (level.YMap6 > 0)
                        level.YMap6 -= characterB.STEP_LENGTH;
                }
            }
        }

        static void Main(string[]args)
        {
            Hardware hardware = new Hardware(1200, 740, 24, false);

            int key = 0, spriteCount = 0, currentSprite = 1;
            bool left, right, isFalling = false, isJumping = false;
            float verticalSpeed = 0.0f, horizontalSpeed = 0.0f;
            Images characterA = new Images("images/MC.gif", CHARACTER_SPRITE_WIDTH, CHARACTER_SPRITE_HEIGHT);
            Images characterB = new Images("images/MC.gif", CHARACTER_SPRITE_WIDTH, CHARACTER_SPRITE_HEIGHT);
            List<Images> bricks = new List<Images>();
            characterA.MoveTo(0, 320 - CHARACTER_SPRITE_HEIGHT);
            characterB.MoveTo(0, 320 - CHARACTER_SPRITE_HEIGHT);
            while(key != Hardware.KEY_ESC) //While Debug
            {
                // Draw all
                hardware.ClearScreen();
                if(ChooseCharacterScreen.ChosenPlayer(value) = 1) //Si se ha escogido el primer personaje
                {
                    //Hardware and Code to Fix it
                    hardware.DrawImage(characterA, (short)(currentSprite * CHARACTER_SPRITE_WIDTH), 0, CHARACTER_SPRITE_HEIGHT);
                    hardware.UpdateScreen();
                }
                else if(ChooseCharacterScreen.GetChosenPlayer(chosenPlayer = 2))
                {
                    hardware.DrawImage(characterB, (short)(currentSprite * CHARACTER_SPRITE_WIDTH), 0, CHARACTER_SPRITE_HEIGHT);
                    hardware.UpdateScreen();
                }

                // Move character from the keyboard input
                hardware.GetEvents(out key);
                left = hardware.IsKPressed(Hardware.KEY_LEFT);
                right = hardware.IsKPressed(Hardware.KEY_RIGHT);

                if (isFalling)
                    characterA.Fall();
                else if(isJumping)
                {
                    currentSprite = 0;
                    characterA.MoveTo(characterA.GetX() + horizontalSpeed,
                        characterA.GetY() + verticalSpeed);
                    verticalSpeed += VERTICAL_SPEED_DECREMENT;
                    if (verticalSpeed > MAX_VERTICAL_SPEED)
                        verticalSpeed = MAX_VERTICAL_SPEED;
                }
                else if(key == Hardware.KEY_SPACE)
                {
                    isJumping = true;
                    verticalSpeed = -1 * MAX_VERTICAL_SPEED;
                    horizontalSpeed = left ? -1 * MOVEMENT_INCREMENT :
                  right ? MOVEMENT_INCREMENT : 0.0f;
                    characterA.MoveTo(characterA.GetX() + horizontalSpeed,
                                     characterA.GetY() + verticalSpeed);
                }
                else if (left || right)
                {
                    if (left && characterA.GetX() > 0)
                        characterA.MoveTo(characterA.GetX() - MOVEMENT_INCREMENT, characterA.GetY());
                    else if (right && characterA.GetX() < SCREEN_WIDTH - CHARACTER_SPRITE_WIDTH)
                        characterA.MoveTo(characterA.GetX() + MOVEMENT_INCREMENT, characterA.GetY());

                    if (spriteCount < SPRITE_MAX_COUNT)
                        spriteCount++;
                    else
                    {
                        spriteCount = 0;
                        currentSprite = (currentSprite + 1) % 3;
                        if (hardware.IsKPressed(Hardware.KEY_RIGHT))
                            currentSprite += 1;
                        else
                            currentSprite += 4;
                    }
                }

                // Check Collisions and update screen

                isFalling = !isJumping;
                isFalling = false;
                isJumping = false;

                if (characterA.GetY() >=
                    SCREEN_HEIGHT - CHARACTER_SPRITE_HEIGHT)
                {
                    characterA.MoveTo(characterA.GetX(), SCREEN_HEIGHT -
                        CHARACTER_SPRITE_HEIGHT);
                    isFalling = false;
                    isJumping = false;
                }
            }
        }

        public override void Show()
        {
            short oldX, oldY, oldXMap, oldYMap;
            DateTime timeStampFromClock = DateTime.Now;
            byte currentLevel = 1;
            bool gameOver = false;
            if (chosenPlayer == 1) //ChooseCharacter Character A
            {
                characterA.MoveTo(level.Start.X, level.Start.Y);
            }
            else if(chosenPlayer == 2) //ChooseCharacter Character B
            {
                characterB.MoveTo(level.Start.X, level.Start.Y);
            }
            audio.PlayMusic(0, -1);

            var timer = new Timer(this.DecreaseTime, null, 1000, 1000);

            //IN PROGRESS Draw Everything

            do
            {
                hardware.ClearScreen();
                if (level == new Level("levels/level1.txt"))
                {
                    hardware.DrawSprite(level.BackgroundA, 0, 0, level.XMap1, level.YMap1, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap1), (short)(wallA.Y - level.YMap1), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap1), (short)(wallB.Y - level.YMap1), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap1), (short)(floorA.Y - level.YMap1), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap1), (short)(level.ExitLevel.Y - level.YMap1), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap1), (short)(i.Y - level.YMap1), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                }
                else if (level == new Level("levels/level2.txt"))
                {
                    hardware.DrawSprite(level.BackgroundB, 0, 0, level.XMap2, level.YMap2, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap2), (short)(wallA.Y - level.YMap2), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap2), (short)(wallB.Y - level.YMap2), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap2), (short)(level.ExitLevel.Y - level.YMap2), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap2), (short)(i.Y - level.YMap2), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap2), (short)(floorA.Y - level.YMap2), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                }
                else if (level == new Level("levels/level3.txt"))
                {
                    hardware.DrawSprite(level.BackgroundB, 0, 0, level.XMap3, level.YMap3, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap3), (short)(wallA.Y - level.YMap3), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap3), (short)(wallB.Y - level.YMap3), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap3), (short)(level.ExitLevel.Y - level.YMap3), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap3), (short)(i.Y - level.YMap3), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap3), (short)(floorA.Y - level.YMap3), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                }
                else if (level == new Level("levels/level4.txt"))
                {
                    hardware.DrawSprite(level.BackgroundC, 0, 0, level.XMap4, level.YMap4, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap4), (short)(wallA.Y - level.YMap4), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap4), (short)(wallB.Y - level.YMap4), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap4), (short)(level.ExitLevel.Y - level.YMap4), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap4), (short)(i.Y - level.YMap4), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap4), (short)(floorA.Y - level.YMap4), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                }
                else if (level == new Level("levels/level5.txt"))
                {
                    hardware.DrawSprite(level.BackgroundE, 0, 0, level.XMap5, level.YMap5, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap5), (short)(wallA.Y - level.YMap5), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap5), (short)(wallB.Y - level.YMap5), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsB.ItemsSheetB, (short)(level.ExitLevel.X - level.XMap5), (short)(level.ExitLevel.Y - level.YMap5), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsB.SPRITEIB_WIDTH, SpriteItemsB.SPRITEIB_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap5), (short)(i.Y - level.YMap5), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap5), (short)(floorA.Y - level.YMap5), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                }
                else if (level == new Level("levels/tolast.txt"))
                {
                    hardware.DrawSprite(level.BackgroundE, 0, 0, level.XMap5, level.YMap5, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap5), (short)(wallA.Y - level.YMap5), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap5), (short)(wallB.Y - level.YMap5), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap5), (short)(level.ExitLevel.Y - level.YMap5), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap5), (short)(i.Y - level.YMap5), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap5), (short)(floorA.Y - level.YMap5), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);

                }
                else if (level == new Level("levels/levelend.txt"))
                {
                    hardware.DrawSprite(level.BackgroundD, 0, 0, level.XMap6, level.YMap6, MainController.SCREEN_WIDTH, MainController.SCREEN_HEIGHT);
                    foreach (WallA wallA in level.wallA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallA.X - level.XMap6), (short)(wallA.Y - level.YMap6), wallA.SpriteX, wallA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (WallB wallB in level.wallB)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(wallB.X - level.XMap6), (short)(wallB.Y - level.YMap6), wallB.SpriteX, wallB.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(level.ExitLevel.X - level.XMap6), (short)(level.ExitLevel.Y - level.YMap6), level.ExitLevel.SpriteX, level.ExitLevel.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (Items i in level.items)
                        hardware.DrawSprite(SpriteItemsA.ItemsSheetA, (short)(i.X - level.XMap6), (short)(i.Y - level.YMap6), i.SpriteX, i.SpriteY, SpriteItemsA.SPRITEIA_WIDTH, SpriteItemsA.SPRITEIA_HEIGHT);
                    foreach (FloorA floorA in level.floorA)
                        hardware.DrawSprite(SpriteA.TilesSheetA, (short)(floorA.X - level.XMap6), (short)(floorA.Y - level.YMap6), floorA.SpriteX, floorA.SpriteY, SpriteA.SPRITEA_WIDTH, SpriteA.SPRITEA_HEIGHT);
                    foreach (FloorB floorB in level.floorB)
                        hardware.DrawSprite(SpriteB.TilesSheetB, (short)(floorB.X - level.XMap6), (short)(floorB.Y - level.YMap6), floorB.SpriteX, floorB.SpriteY, SpriteB.SPRITEB_WIDTH, SpriteB.SPRITEB_HEIGHT);
                    foreach (FloorC floorC in level.floorC)
                        hardware.DrawSprite(SpriteC.TilesSheetC, (short)(floorC.X - level.XMap6), (short)(floorC.Y - level.YMap6), floorC.SpriteX, floorC.SpriteY, SpriteC.SPRITEC_WIDTH, SpriteC.SPRITEC_HEIGHT);
                    foreach (FloorD floorD in level.floorD)
                        hardware.DrawSprite(SpriteD.TilesSheetD, (short)(floorD.X - level.XMap6), (short)(floorD.Y - level.YMap6), floorD.SpriteX, floorD.SpriteY, SpriteD.SPRITED_WIDTH, SpriteD.SPRITED_HEIGHT);
                    foreach (FloorE floorE in level.floorE)
                        hardware.DrawSprite(SpriteE.TilesSheetE, (short)(floorE.X - level.XMap6), (short)(floorE.Y - level.YMap6), floorE.SpriteX, floorE.SpriteY, SpriteE.SPRITEE_WIDTH, SpriteE.SPRITEE_HEIGHT);
                    foreach (FloorF floorF in level.floorF)
                        hardware.DrawSprite(SpriteF.TilesSheetF, (short)(floorF.X - level.XMap6), (short)(floorF.Y - level.YMap6), floorF.SpriteX, floorF.SpriteY, SpriteF.SPRITEF_WIDTH, SpriteF.SPRITEF_HEIGHT);
                    foreach (FloorG floorG in level.floorG)
                        hardware.DrawSprite(SpriteG.TilesSheetG, (short)(floorG.X - level.XMap6), (short)(floorG.Y - level.YMap6), floorG.SpriteX, floorG.SpriteY, SpriteG.SPRITEG_WIDTH, SpriteG.SPRITEG_HEIGHT);
                }

                if (chosenPlayer == 1)
                    {
                        oldX = characterA.X;
                        oldY = characterA.Y;
                    }
                    else if (chosenPlayer == 2)
                    {
                        oldX = characterB.X;
                        oldY = characterB.Y;
                    }

                //Level One Map
                if(level == new Level ("levels/level1.txt"))
                {
                    oldXMap = level.XMap1;
                    oldYMap = level.YMap1;
                }
                //Level Two Map
                else if (level == new Level("levels/level2.txt"))
                {
                    oldXMap = level.XMap2;
                    oldYMap = level.YMap2;
                }
                //Level Three Map
                else if (level == new Level("levels/level3.txt"))
                {
                    oldXMap = level.XMap3;
                    oldYMap = level.YMap3;
                }
                //Level Four Map
                else if (level == new Level("levels/level4.txt"))
                {
                    oldXMap = level.XMap4;
                    oldYMap = level.YMap4;
                }
                //Level Five Map
                else if (level == new Level("levels/level5.txt"))
                {
                    oldXMap = level.XMap5;
                    oldYMap = level.YMap5;
                }
                else if (level == new Level("levels/tolast.txt"))
                {
                    oldXMap = level.XMap5;
                    oldYMap = level.YMap5;
                }
                //Final Level Map
                else if (level == new Level("levels/levelend.txt"))
                {
                    oldXMap = level.XMap6;
                    oldYMap = level.YMap6;
                }

                //Pause Menu First Version

                if (hardware.IsKPressed(Hardware.KEY_P))
                {
                    Timer storet = timer;
                    timer.Dispose();
                    audio.StopMusic();
                    hardware.ClearScreen();
                    Sdl.SDL_Color white = new Sdl.SDL_Color(0, 0, 0);
                    textPause = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "PAUSE", white);
                    textPause = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "Continue [C]", white);
                    textPause = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), "Quit [Q]", white);
                    
                    char pause = Convert.ToChar(Console.ReadLine().ToLower());

                    switch (pause)
                    {
                        case 'c': timer = storet; break; //Nothing because game continues
                        case 'q': intro.GetExit(); break; //Call GetExit
                    }
                }
            }
            while (!gameOver);
            audio.StopMusic();
            timer.Dispose();

        }

        //TODO Move items and give items to every item and enemies

        //TODO Add LoseLives Class and GameOver Class inside the "kill enemies comment" more or less
    }
}
