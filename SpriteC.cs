using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    class SpriteC
    {
        //Base Class To Show All Images and Sprites

        public static Image TilesSheetC = new Image("images/more_tiles_2.gif", 128, 88);

        public const short SPRITEC_WIDTH = 16; 
        public const short SPRITEC_HEIGHT = 16;

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

        public bool CollidesWith(SpriteC sp)
        {
            return (X + SpriteC.SPRITEC_WIDTH > sp.X && X < sp.X + SpriteC.SPRITEC_WIDTH &&
                    Y + SpriteC.SPRITEC_HEIGHT > sp.Y && Y < sp.Y + SpriteC.SPRITEC_HEIGHT);
        }

        public bool CollidesWith(List<SpriteC> sprites)
        {
            foreach (SpriteC sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}
