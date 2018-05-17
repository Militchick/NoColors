using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added Character Sheets) 

namespace No_Colors
{
    class SpriteCharacter
    {
        //Base Class To Show All Images and Sprites

        public static Images CharacterSheet = new Images("images/MC.gif", 646, 241);

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

        public bool CollidesWith(SpriteCharacter sp)
        {
            return (X + SpriteCharacter.SPRITECA_WIDTH > sp.X && X < sp.X + SpriteCharacter.SPRITECA_WIDTH &&
                    Y + SpriteCharacter.SPRITECA_HEIGHT > sp.Y && Y < sp.Y + SpriteCharacter.SPRITECA_HEIGHT);
        }

        public bool CollidesWith(List<SpriteCharacter> sprites)
        {
            foreach (SpriteCharacter sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }
    }
}