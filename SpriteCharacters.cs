using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added Character Sheets) 

namespace No_Colors
{
    class SpriteCharacter
    {
        //Base Class To Show All Images and Sprites

        public static Image CharacterSheet = new Image("images/MC.gif", 646, 241);

        public const short SPRITECA_WIDTH = 27; 
        public const short SPRITECA_HEIGHT = 35;

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