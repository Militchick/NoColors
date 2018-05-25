using System;
using System.Collections.Generic;
using System.Linq;

//V 0.02 - Miguel Pastor (Added Character Sheets) 

namespace No_Colors
{
    class SpriteEnemies
    {
        //Base Class To Show All Images and Sprites

        public static Image EnemiesSheet = new Image("images/Enemies.gif", 712, 128);

        //Small Enemies

        public const short SPRITEEA_WIDTH = 16;
        public const short SPRITEEA_HEIGHT = 17;

        // Medium Enemies

        public const short SPRITEEB_WIDTH = 17;
        public const short SPRITEEB_HEIGHT = 25;

        // Boss

        public const short SPRITEED_WIDTH = 33;
        public const short SPRITEED_HEIGHT = 33;

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

        public bool CollidesWith(SpriteEnemies sp)
        {
            return (X + SpriteEnemies.SPRITEEA_WIDTH > sp.X && X < sp.X + SpriteEnemies.SPRITEEA_WIDTH &&
                    Y + SpriteEnemies.SPRITEEA_HEIGHT > sp.Y && Y < sp.Y + SpriteEnemies.SPRITEEA_HEIGHT);
        }

        public bool CollidesWith(List<SpriteEnemies> sprites)
        {
            foreach (SpriteEnemies sp in sprites)
                if (this.CollidesWith(sp))
                    return true;
            return false;
        }

        public bool CollidesWith2(SpriteEnemies sp)
        {
            return (X + SpriteEnemies.SPRITEEB_WIDTH > sp.X && X < sp.X + SpriteEnemies.SPRITEEB_WIDTH &&
                    Y + SpriteEnemies.SPRITEEB_HEIGHT > sp.Y && Y < sp.Y + SpriteEnemies.SPRITEEB_HEIGHT);
        }

        public bool CollidesWith2(List<SpriteEnemies> sprites)
        {
            foreach (SpriteEnemies sp in sprites)
                if (this.CollidesWith2(sp))
                    return true;
            return false;
        }

        public bool CollidesWith3(SpriteEnemies sp)
        {
            return (X + SpriteEnemies.SPRITEED_WIDTH > sp.X && X < sp.X + SpriteEnemies.SPRITEED_WIDTH &&
                    Y + SpriteEnemies.SPRITEED_HEIGHT > sp.Y && Y < sp.Y + SpriteEnemies.SPRITEED_HEIGHT);
        }

        public bool CollidesWith3(List<SpriteEnemies> sprites)
        {
            foreach (SpriteEnemies sp in sprites)
                if (this.CollidesWith3(sp))
                    return true;
            return false;
        }

    }
}