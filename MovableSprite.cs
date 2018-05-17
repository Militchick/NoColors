using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    // Main Character A

    class MovableSpriteA: SpriteCharacter
    {

        //Class to prepare animation to all Mobile Items, Enemies, Characters, etc

        const byte TOTAL_MOVEMENTS = 3; //To Left, To Right, and Jump
        const byte SPRITE_CHANGE = 26;

        public enum SpriteMovementA { LEFT, SPACE, RIGHT};
        public SpriteMovementA CurrentDirection { get; set; }
        public byte CurrentSprite { get; set; }

        //Adding the sprites through pixels and the coordinates in a X,Y position from the left

        byte currentSpriteChange;

        public int[][] SpriteXCoordinates = new int[TOTAL_MOVEMENTS][];
        public int[][] SpriteYCoordinates = new int[TOTAL_MOVEMENTS][];

        public MovableSpriteA()
        {
            CurrentSprite = 0;
            CurrentDirection = SpriteMovementA.RIGHT;
            currentSpriteChange = 0;
            CurrentDirection = SpriteMovementA.SPACE;
        }


        public void Animate(SpriteMovementA movement)
        {
            if(movement != CurrentDirection)
            {
                CurrentDirection = movement;
                CurrentSprite = 0;
                currentSpriteChange = 0;
            }
            else
            {
                currentSpriteChange++;
                if(currentSpriteChange >= SPRITE_CHANGE)
                {
                    currentSpriteChange = 0;
                    CurrentSprite = (byte)((CurrentSprite + 1) % SpriteXCoordinates[(int)CurrentDirection].Length);
                }
            }
            UpdateSpriteCoordinates();
        }

        public void UpdateSpriteCoordinates()
        {
            SpriteX = (short)(SpriteXCoordinates[(int)CurrentDirection][CurrentSprite]);
            SpriteY = (short)(SpriteYCoordinates[(int)CurrentDirection][CurrentSprite]);
        }
    }


// Main Character B

class MovableSpriteB : SpriteCharacter
    {

        //Class to prepare animation to all Mobile Items, Enemies, Characters, etc

        const byte TOTAL_MOVEMENTS = 3; //To Left, To Right, and Jump
        const byte SPRITE_CHANGE = 26;

        public enum SpriteMovementB { LEFT, SPACE, RIGHT };
        public SpriteMovementB CurrentDirection { get; set; }
        public byte CurrentSprite { get; set; }

        //Adding the sprites through pixels and the coordinates in a X,Y position from the left

        byte currentSpriteChange;

        public int[][] SpriteXCoordinatesB = new int[TOTAL_MOVEMENTS][];
        public int[][] SpriteYCoordinatesB = new int[TOTAL_MOVEMENTS][];

        public MovableSpriteB()
        {
            CurrentSprite = 0;
            CurrentDirection = SpriteMovementB.RIGHT;
            currentSpriteChange = 0;
            CurrentDirection = SpriteMovementB.SPACE;
        }


        public void Animate(SpriteMovementB movement)
        {
            if (movement != CurrentDirection)
            {
                CurrentDirection = movement;
                CurrentSprite = 0;
                currentSpriteChange = 0;
            }
            else
            {
                currentSpriteChange++;
                if (currentSpriteChange >= SPRITE_CHANGE)
                {
                    currentSpriteChange = 0;
                    CurrentSprite = (byte)((CurrentSprite + 1) % SpriteXCoordinatesB[(int)CurrentDirection].Length);
                }
            }
            UpdateSpriteCoordinates();
        }

        public void UpdateSpriteCoordinates()
        {
            SpriteX = (short)(SpriteXCoordinatesB[(int)CurrentDirection][CurrentSprite]);
            SpriteY = (short)(SpriteYCoordinatesB[(int)CurrentDirection][CurrentSprite]);

        }
    }

}
