using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Only to Color Floors #1

    class SpriteD
    {
        //Base Class To Show All Images and Sprites

        public static Image TilesSheetD = new Image("images/color_final_tiles.gif", 702, 411);

        public const short SPRITED_WIDTH = 87; 
        public const short SPRITED_HEIGHT = 22;

        public short X { get; set; }
        public short Y { get; set; }
        public short SpriteX { get; set; }
        public short SpriteY { get; set; }

        public void MoveTo(short x, short y)
        {
            X = x;
            Y = y;
        }


        //Collisions (Study to Only Collisions from the top on other classes)

        public bool CollidesWith(SpriteD sp)
        {
            return (X + SpriteD.SPRITED_WIDTH > sp.X && X < sp.X + SpriteD.SPRITED_WIDTH &&
                    Y + SpriteD.SPRITED_HEIGHT > sp.Y && Y < sp.Y + SpriteD.SPRITED_HEIGHT);
        }

        public bool CollidesWith(List<SpriteD> sprites)
        {
            foreach (SpriteD sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}
