using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    class SpriteA
    {
        //Base Class To Show All Images and Sprites

        public static Images TilesSheetA = new Images("images/tiles.gif", 188, 56);

        public const short SPRITEA_WIDTH = 8; 
        public const short SPRITEA_HEIGHT = 9;

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

        public bool CollidesWith(SpriteA sp)
        {
            return (X + SpriteA.SPRITEA_WIDTH > sp.X && X < sp.X + SpriteA.SPRITEA_WIDTH &&
                    Y + SpriteA.SPRITEA_HEIGHT > sp.Y && Y < sp.Y + SpriteA.SPRITEA_HEIGHT);
        }

        public bool CollidesWith(List<SpriteA> sprites)
        {
            foreach (SpriteA sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}
