using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added First Tiles, Find Out Size of Tiles) 

namespace No_Colors
{
    // Items Sprite

    class SpriteItemsA
    {
        //Base Class To Show All Images and Sprites

        public static Image ItemsSheetA = new Image("images/item_points.gif", 375, 524);

        //Diferent Sizes

        //Small (Berry, Cherry, Clock)
        public const short SPRITEIA_WIDTH = 18; 
        public const short SPRITEIA_HEIGHT = 19;

        //Big (Only Stars or Flowers)
        public const short SPRITEIC_WIDTH = 25;
        public const short SPRITEIC_HEIGHT = 25;

        public ushort Lives { get; set; }

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

        public bool CollidesWith(SpriteItemsA sp)
        {
            return (X + SpriteItemsA.SPRITEIA_WIDTH > sp.X && X < sp.X + SpriteItemsA.SPRITEIA_WIDTH &&
                    Y + SpriteItemsA.SPRITEIA_HEIGHT > sp.Y && Y < sp.Y + SpriteItemsA.SPRITEIA_HEIGHT);
        }

        public bool CollidesWith(List<SpriteItemsA> sprites)
        {
            foreach (SpriteItemsA sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }

        public bool CollidesWithC(SpriteItemsA sp)
        {
            return (X + SpriteItemsA.SPRITEIC_WIDTH > sp.X && X < sp.X + SpriteItemsA.SPRITEIC_WIDTH &&
                    Y + SpriteItemsA.SPRITEIC_HEIGHT > sp.Y && Y < sp.Y + SpriteItemsA.SPRITEIC_HEIGHT);
        }

        public bool CollidesWithC(List<SpriteItemsA> sprites)
        {
            foreach (SpriteItemsA sp in sprites)
                if (this.CollidesWithC(sp))
                    return true;
            return false;
        }
    }
}