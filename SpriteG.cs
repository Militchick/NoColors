using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Only to Base Color Floors

    class SpriteG
    {
        //Base Class To Show All Images and Sprites

        public static Image TilesSheetG = new Image("images/color_final_tiles.gif", 702, 411);

        public const short SPRITEG_WIDTH = 46;
        public const short SPRITEG_HEIGHT = 21;

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

        public bool CollidesWith(SpriteG sp)
        {
            return (X + SpriteG.SPRITEG_WIDTH > sp.X && X < sp.X + SpriteG.SPRITEG_WIDTH &&
                    Y + SpriteG.SPRITEG_HEIGHT > sp.Y && Y < sp.Y + SpriteG.SPRITEG_HEIGHT);
        }

        public bool CollidesWith(List<SpriteG> sprites)
        {
            foreach (SpriteG sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}