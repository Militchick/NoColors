using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Only to Color Floors #3

    class SpriteF
    {
        //Base Class To Show All Images and Sprites

        public static Images TilesSheetF = new Images("images/color_final_tiles.gif", 702, 411);

        public const short SPRITEF_WIDTH = 33; 
        public const short SPRITEF_HEIGHT = 17;

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

        public bool CollidesWith(SpriteF sp)
        {
            return (X + SpriteF.SPRITEF_WIDTH > sp.X && X < sp.X + SpriteF.SPRITEF_WIDTH &&
                    Y + SpriteF.SPRITEF_HEIGHT > sp.Y && Y < sp.Y + SpriteF.SPRITEF_HEIGHT);
        }

        public bool CollidesWith(List<SpriteF> sprites)
        {
            foreach (SpriteF sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}