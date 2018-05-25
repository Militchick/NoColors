using System;
using System.Collections.Generic;
using System.Linq;

//V 0.03 (Added Character Directions)

namespace No_Colors
{
    class MainCharacterA : MovableSpriteA
    {
        public byte STEP_LENGTH;
        public ushort Lives { get; set; }
        public ushort Points { get; set; }
        public ushort Time { get; set; }

        public MainCharacterA()
        {
            Points = 0;
            Lives = 3;
        }
    }

    class MainCharacterB : MovableSpriteB
    {
        public byte STEP_LENGTH;
        public ushort Lives { get; set; }
        public ushort Points { get; set; }
        public ushort Time { get; set; }

        public MainCharacterB()
        {
            Points = 0;
            Lives = 4;
        }

    }
}
