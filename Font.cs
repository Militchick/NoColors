using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.05 Miguel Pastor (Added Complete Font Class)
//V 0.03 Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class Font
    {
        //Class used to choose font of words

        IntPtr fontType;

        public Font(string fileName, int fontSize)
        {
            fontType = SdlTtf.TTF_OpenFont(fileName, fontSize);
            if(fontType == IntPtr.Zero)
            {
                Console.WriteLine("Font type not found");
                Environment.Exit(2);
            }
        }

        public IntPtr GetFontType()
        {
            return fontType;
        }
    }
}
