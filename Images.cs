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
        float x, y;
        short imageWidth, imageHeight;
        IntPtr image;

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

        public void MoveTo(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float GetX()
        {
            return x;
        }

        public float GetY()
        {
            return y;
        }

        public short GetImageWidth()
        {
            return ImageWidth;
        }

        public short GetImageHeight()
        {
            return ImageHeight;
        }

        public IntPtr GetImage()
        {
            return image;
        }

        public bool CollidesWith(Images img, short w1, short h1, short w2, short h2)
        {
            return (x + w1 >= img.x && x <= img.x + w2 &&
                    y + h1 >= img.y && y <= img.y + h2);
        }

        public void Fall()
        {
            this.y++;
        }

        public bool IsOver(Images img)
        {
            return (this.CollidesWith(img, this.GetImageWidth(), this.GetImageHeight(),
                img.GetImageWidth(), img.GetImageHeight()) &&
                img.GetY() >= this.GetY() + this.GetImageHeight() * 0.9);
        }
    }
}