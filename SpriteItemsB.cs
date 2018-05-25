using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Final Item Sprite

    class SpriteItemsB
    {
        //Base Class To Show All Images and Sprites

        public static Image ItemsSheetB = new Image("images/LastFinalGoal.gif", 290, 160);
        
        public const short SPRITEIB_WIDTH = 123; 
        public const short SPRITEIB_HEIGHT = 115;

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

        //Needed to Give Points to the Player if the Main Character touch an Item  

        public bool CollidesWith(SpriteItemsB sp)
        {
            return (X + SpriteItemsB.SPRITEIB_WIDTH > sp.X && X < sp.X + SpriteItemsB.SPRITEIB_WIDTH &&
                    Y + SpriteItemsB.SPRITEIB_HEIGHT > sp.Y && Y < sp.Y + SpriteItemsB.SPRITEIB_HEIGHT);
        }

        public bool CollidesWith(List<SpriteItemsB> sprites)
        {
            foreach (SpriteItemsB sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }

    }
}