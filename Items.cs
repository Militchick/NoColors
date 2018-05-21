using System;
using System.Collections.Generic;
using System.Linq;
using Tao.Sdl;

//V 0.06 - Miguel Pastor (Added Items Enumeration)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{
    class Items : StaticSpriteItemsA
    {
        //Since Almost all items will give us points, the only thing to do here is:

        //Check what is an item with the console

        //Give an Amount of Points for Each Different Type of Item

        //TODO And connect to the GameScreen

        public enum ItemType { Y_STAR, R_STAR, G_STAR, F_FLOWER,
        I_FLOWER, P_FLOWER, R_BERRY, P_BERRY, CHERRY}

        public ushort Lives { get; set; }
        public ushort Time { get; set; }
        public short Points { get; set; }
        public Items(ItemType type)
        {
            if(type == ItemType.Y_STAR)
            {
                Points = 200;
                SpriteX = 9;
                SpriteY = 30;
            }
            else if (type == ItemType.R_STAR)
            {
                Points = 400;
                SpriteX = 129;
                SpriteY = 30;
            }
            else if (type == ItemType.G_STAR)
            {
                Points = 600;
                Lives = 1;
                SpriteX = 69;
                SpriteY = 30;
            }
            else if (type == ItemType.F_FLOWER)
            {
                Points = 300;
                SpriteX = 12;
                SpriteY = 440;
            }
            else if (type == ItemType.I_FLOWER)
            {
                Points = 600;
                SpriteX = 100;
                SpriteY = 440;
            }
            else if (type == ItemType.P_FLOWER)
            {
                Points = 1000;
                Time = 100;
                SpriteX = 186;
                SpriteY = 434;
            }
            else if (type == ItemType.R_BERRY)
            {
                Points = 1200;
                SpriteX = 186;
                SpriteY = 326;
            }
            else if (type == ItemType.P_BERRY)
            {
                Points = 2400;
                SpriteX = 236;
                SpriteY = 326;
            }
            else if (type == ItemType.CHERRY)
            {
                Points = 1500;
                SpriteX = 8;
                SpriteY = 198;
            }
        }

        public Items(ItemType type, short x, short y) : this(type)
        {
            X = x;
            Y = y;
        }

    }
}
