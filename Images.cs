using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.02 - Miguel Pastor (Read Images)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class Images
    {
        //Contain all information about the images and sprites in the game

            public short X { get; set; }
            public short Y { get; set; }
            public short ImageWidth { get; set; }
            public short ImageHeight { get; set; }
            public IntPtr ImagePtr { get; set; }

            public Images(string fileName, short width, short height)
            {
                ImagePtr = SdlImage.IMG_Load(fileName);
                if (ImagePtr == IntPtr.Zero)
                {
                    Console.WriteLine("Image not found");
                    Environment.Exit(1);
                }

                ImageWidth = width;
                ImageHeight = height;
            }

            public void MoveTo(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
    }