using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    class SpriteB
    {
        //Base Class To Show All Images and Sprites

        public static Image TilesSheetB = new Image("images/more_tiles.gif", 286, 189);

        public const short SPRITEB_WIDTH = 17;
        public const short SPRITEB_HEIGHT = 17; 

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

        public bool CollidesWith(SpriteB sp)
        {
            return (X + SpriteB.SPRITEB_WIDTH > sp.X && X < sp.X + SpriteB.SPRITEB_WIDTH &&
                    Y + SpriteB.SPRITEB_HEIGHT > sp.Y && Y < sp.Y + SpriteB.SPRITEB_HEIGHT);
        }

        public bool CollidesWith(List<SpriteB> sprites)
        {
            foreach (SpriteB sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}
