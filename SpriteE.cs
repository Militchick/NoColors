using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Only to Color Floors #2

    class SpriteE
    {
        //Base Class To Show All Images and Sprites

        public static Images TilesSheetE = new Images("images/color_final_tiles.gif", 702, 411);

        public const short SPRITEE_WIDTH = 79; //???
        public const short SPRITEE_HEIGHT = 23; //???

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

        public bool CollidesWith(SpriteE sp)
        {
            return (X + SpriteE.SPRITEE_WIDTH > sp.X && X < sp.X + SpriteE.SPRITEE_WIDTH &&
                    Y + SpriteE.SPRITEE_HEIGHT > sp.Y && Y < sp.Y + SpriteE.SPRITEE_HEIGHT);
        }

        public bool CollidesWith(List<SpriteE> sprites)
        {
            foreach (SpriteE sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}