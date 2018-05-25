using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;
using System.Threading;

//V 0.10 - Miguel Pastor (Trying to fix "Image not found" error)
//V 0.05 - Miguel Pastor (KeyEvents)
//V 0.02 - Miguel Pastor (Key Inputs, Arguments, Constructor, 
//Destructor, Updating Screen Method, Clear Screen Method, and Add Text Method)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class Hardware
    {
        //Class that will prepare all hardware necesary

        //All Keys Inputs
        public const int KEY_ESC = Sdl.SDLK_ESCAPE; //Only while Debugging to Quit the Game
        public const int KEY_UP = Sdl.SDLK_UP;
        public const int KEY_DOWN = Sdl.SDLK_DOWN;
        public const int KEY_LEFT = Sdl.SDLK_LEFT;
        public const int KEY_RIGHT = Sdl.SDLK_RIGHT;
        public const int KEY_SPC = Sdl.SDLK_SPACE;
        public const int KEY_P = Sdl.SDLK_p;

        //All arguments to the Hardware Constructor and Destructor
        short screenHeight;
        short screenWidth;
        short colorDepth;
        IntPtr screen;
        static short width, height;
        static short startX, startY;
        static IntPtr hiddenScreen;

        public Hardware(short width, short height, short depth, bool fullScreen)
        {
            screenWidth = width;
            screenHeight = height;
            colorDepth = depth;

            int flags = Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT;
            if (fullScreen)
                flags = flags | Sdl.SDL_FULLSCREEN;

            Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
            screen = Sdl.SDL_SetVideoMode(screenWidth, screenHeight, colorDepth, flags);
            Sdl.SDL_Rect rect = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_SetClipRect(screen, ref rect);

            SdlTtf.TTF_Init();
        }

        ~Hardware()
        {
            Sdl.SDL_Quit();
        }

        //Draws an image on Current Coordinates

        public void DrawImage(Image img)
        {

            Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, img.ImageWidth,
                img.ImageHeight);
            Sdl.SDL_Rect target = new Sdl.SDL_Rect(img.X, img.Y, 
                img.ImageWidth, img.ImageHeight);
            Sdl.SDL_BlitSurface(img.ImagePtr, ref source, screen, ref target);
        }

        // Draws a sprite from a sprite sheet in 
        // the specified X and Y position of the screen

        public void DrawImage(Image images, short x, short y, short width, short height)
        {
            Sdl.SDL_Rect src = new Sdl.SDL_Rect(x, y, width, height);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)images.GetX(), (short)images.GetY(),
                width, height);
            Sdl.SDL_BlitSurface(images.GetImage(), ref src, screen, ref dest);
        }

        public void DrawSprite(Image image, short xScreen, short yScreen, 
            short x, short y, short width, short height)
        {
            Sdl.SDL_Rect src = new Sdl.SDL_Rect(x, y, width, height);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect(xScreen, yScreen, width, height);
            Sdl.SDL_BlitSurface(image.ImagePtr, ref src, screen, ref dest);
        }

        //Update screen
        public void UpdateScreen()
        {
            Sdl.SDL_Flip(screen);
        }

        // Clears the screen
        public void ClearScreen()
        {
            Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_FillRect(screen, ref source, 0);
        }

        //Detects a key pressed by the user and 
        //returns the code of the key pressed

        public int KeyPress()
        {
            int press = -1;

            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event keyEvent;
            if(Sdl.SDL_PollEvent(out keyEvent) == 1)
            {
                if(keyEvent.type == Sdl.SDL_KEYDOWN)
                {
                    press = keyEvent.key.keysym.sym;
                }
            }
            return press;
        }

        //Checks if a given key is now being pressed
        public bool IsKPressed(int key)
        {
            bool pressed = false;
            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event evt;
            Sdl.SDL_PollEvent(out evt);
            int numKeys;
            byte[] keys = Sdl.SDL_GetKeyState(out numKeys);
            if (keys[key] == 1)
                pressed = true;
            return pressed;
        }

        // Writes a text in the specified coordinates
        public void WriteText(IntPtr textAsImage, short x, short y)
        {
            Sdl.SDL_Rect src = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect(x, y, screenWidth, screenHeight);
            Sdl.SDL_BlitSurface(textAsImage, ref src, screen, ref dest);
        }

        // Get Movement from keys

        public void GetEvents(out int key)
        {
            key = -1;
            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event evt;
            if (Sdl.SDL_PollEvent(out evt) == 1)
            {
                if (evt.type == Sdl.SDL_KEYDOWN)
                {
                    key = evt.key.keysym.sym;
                }
            }
        }

        //Credits Hardware

        public static void Pause(int milisegundos)
        {
            Thread.Sleep(milisegundos);
        }

        public static void DrawHiddenImage(Image image, int x, int y)
        {
            drawHiddenImage(image.GetPointer(), x + startX, y + startY);
        }

        public static void ShowHiddenScreen()
        {
            Sdl.SDL_Flip(hiddenScreen);
        }

        public static void WriteHiddenText(string txt,
    short x, short y, byte r, byte g, byte b, Font f)
        {
            Sdl.SDL_Color color = new Sdl.SDL_Color(r, g, b);
            IntPtr textoComoImagen = SdlTtf.TTF_RenderText_Solid(
                f.GetFontType(), txt, color);
            if (textoComoImagen == IntPtr.Zero)
                Environment.Exit(5);

            Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, width, height);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect(
                (short)(x + startX), (short)(y + startY),
                width, height);

            Sdl.SDL_BlitSurface(textoComoImagen, ref origen,
                hiddenScreen, ref dest);

            Sdl.SDL_FreeSurface(textoComoImagen);
        }

        private static void drawHiddenImage(IntPtr image, int x, int y)
        {
            Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, width, height);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y,
                width, height);
            Sdl.SDL_BlitSurface(image, ref origin, hiddenScreen, ref dest);
        }

        public static int GetWidth()
        {
            return width;
        }

        public static int GetHeight()
        {
            return height;
        }

        // Scroll Methods
/*
        public static void ResetScroll()
        {
            startX = startY = 0;
        }

        public static void ScrollTo(short newStartX, short newStartY)
        {
            startX = newStartX;
            startY = newStartY;
        }

        public static void ScrollHorizontally(short xDespl)
        {
            startX += xDespl;
        }

        public static void ScrollVertically(short yDespl)
        {
            startY += yDespl;
        }

    */
    }
}
