using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Tao.Sdl;

//V 0.06 - Miguel Pastor - (Fixed Some Mistakes from the last time) 
//V 0.04 - Miguel Pastor (Start Adding Things to Level Class)
//V 0.01 - Miguel Pastor (Empty Skeleton)

namespace No_Colors
{

    //Information of all level object will be here

    class Level
    {

        // Open txt to read the levels from 1 to 5 

        // List of Walls and Floors

        public List<SpriteA> floorA { get; }
        public List<SpriteA> floorB { get; }
        public List<SpriteA> floorC { get; }
        public List<SpriteA> floorD { get; }
        public List<SpriteA> floorE { get; }
        public List<SpriteA> floorF { get; }
        public List<SpriteC> floorG { get; }
        public List<SpriteC> floorH { get; }
        public List<SpriteC> floorI { get; }
        public List<SpriteC> floorJ { get; }
        public List<SpriteA> floorK { get; }
        public List<SpriteA> floorL { get; }
        public List<SpriteA> floorM { get; }
        public List<SpriteD> floorN { get; }
        public List<SpriteE> floorO { get; }
        public List<SpriteF> floorP { get; }
        public List<SpriteG> floorQ { get; }
        public List<SpriteA> wallA { get; }
        public List<SpriteA> wallB { get; }

        // List of Items (Coming Soon)

        public List<SpriteItemsA> items { get; }

        // List of Scroll, Entrance, Exit, Enemies, etc...

        public List<Enemies> enemy { get; }
        public Image BackgroundA { get; set; }
        public Image BackgroundB { get; set; }
        public Image BackgroundC { get; set; }
        public Image BackgroundD { get; set; }
        public Image BackgroundE { get; set; }
        public ExitPoint ExitLevel { get; set; }
        public ExitExPoint ExitExLevel { get; set; }
        public StartPoint Start { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public short XMap1 { get; set; }
        public short YMap1 { get; set; }
        public short XMap2 { get; set; }
        public short YMap2 { get; set; }
        public short XMap3 { get; set; }
        public short YMap3 { get; set; }
        public short XMap4 { get; set; }
        public short YMap4 { get; set; }
        public short XMap5 { get; set; }
        public short YMap5 { get; set; }
        public short XMap6 { get; set; }
        public short YMap6 { get; set; }

        // To recognize the file by name on other classes

        public Level(string fileName)
        {
            floorA = new List<SpriteA>();
            floorB = new List<SpriteA>();
            floorC = new List<SpriteA>();
            floorE = new List<SpriteA>();
            floorF = new List<SpriteA>();
            floorG = new List<SpriteC>();
            floorH = new List<SpriteC>();
            floorI = new List<SpriteC>();
            floorJ = new List<SpriteC>();
            floorK = new List<SpriteA>();
            floorL = new List<SpriteA>();
            floorM = new List<SpriteA>();
            floorN = new List<SpriteD>();
            floorO = new List<SpriteE>();
            floorP = new List<SpriteF>();
            floorQ = new List<SpriteG>();
            wallA = new List<SpriteA>();
            wallB = new List<SpriteA>();
            items = new List<SpriteItemsA>();
            enemy = new List<Enemies>();
            BackgroundA = new Image("images/Background_white.gif", 2500, 920);
            BackgroundB = new Image("images/Background_grey.gif", 2500, 920);
            BackgroundC = new Image("images/Backgroundlastlevel_normalscroll.gif", 2500, 920);
            BackgroundD = new Image("images/FinalBackground.gif", 13000, 650);
            BackgroundE = new Image("images/Backgroundlastlevel_verticalscroll.gif", 920, 2500);

            // Prepare Map

            XMap1 = YMap1 = 0;
            XMap2 = YMap2 = 0;
            XMap3 = YMap3 = 0;
            XMap4 = YMap4 = 0;
            XMap5 = YMap5 = 0;
            XMap6 = YMap6 = 0;

            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length > 0)
            {
                Width = (short)(lines[0].Length * SpriteA.SPRITEA_WIDTH);
                Height = (short)(lines.Length * SpriteA.SPRITEA_HEIGHT);

                Width = (short)(lines[0].Length * SpriteC.SPRITEC_WIDTH);
                Height = (short)(lines.Length * SpriteC.SPRITEC_HEIGHT);

                Width = (short)(lines[0].Length * SpriteD.SPRITED_WIDTH);
                Height = (short)(lines.Length * SpriteD.SPRITED_HEIGHT);

                Width = (short)(lines[0].Length * SpriteE.SPRITEE_WIDTH);
                Height = (short)(lines.Length * SpriteE.SPRITEE_HEIGHT);

                Width = (short)(lines[0].Length * SpriteF.SPRITEF_WIDTH);
                Height = (short)(lines.Length * SpriteF.SPRITEF_HEIGHT);

                Width = (short)(lines[0].Length * SpriteG.SPRITEG_WIDTH);
                Height = (short)(lines.Length * SpriteG.SPRITEG_HEIGHT);

                Width = (short)(lines[0].Length * SpriteItemsA.SPRITEIA_WIDTH);
                Height = (short)(lines.Length * SpriteItemsA.SPRITEIA_HEIGHT);

                Width = (short)(lines[0].Length * SpriteItemsB.SPRITEIB_WIDTH);
                Height = (short)(lines.Length * SpriteItemsB.SPRITEIB_HEIGHT);

                Width = (short)(lines[0].Length * SpriteCharacter.SPRITECA_WIDTH);
                Height = (short)(lines.Length * SpriteCharacter.SPRITECA_HEIGHT);

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        if (lines[i][j] == 'A') // Floors on Level
                        {
                            AddFloorA(new FloorA((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'B')
                        {
                            AddFloorB(new FloorB((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'C')
                        {
                            AddFloorC(new FloorC((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'D')
                        {
                            AddFloorD(new FloorD((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'E')
                        {
                            AddFloorE(new FloorE((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'F')
                        {
                            AddFloorF(new FloorF((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'G')
                        {
                            AddFloorG(new FloorG((short)(j * SpriteC.SPRITEC_WIDTH), (short)(i * SpriteC.SPRITEC_HEIGHT)));
                        }
                        else if (lines[i][j] == 'H')
                        {
                            AddFloorH(new FloorH((short)(j * SpriteC.SPRITEC_WIDTH), (short)(i * SpriteC.SPRITEC_HEIGHT)));
                        }
                        else if (lines[i][j] == 'I')
                        {
                            AddFloorI(new FloorI((short)(j * SpriteC.SPRITEC_WIDTH), (short)(i * SpriteC.SPRITEC_HEIGHT)));
                        }
                        else if (lines[i][j] == 'J')
                        {
                            AddFloorJ(new FloorJ((short)(j * SpriteC.SPRITEC_WIDTH), (short)(i * SpriteC.SPRITEC_HEIGHT)));
                        }
                        else if (lines[i][j] == 'K')
                        {
                            AddFloorK(new FloorK((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'L')
                        {
                            AddFloorL(new FloorL((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'M')
                        {
                            AddFloorM(new FloorM((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'N')
                        {
                            AddFloorN(new FloorN((short)(j * SpriteD.SPRITED_WIDTH), (short)(i * SpriteD.SPRITED_HEIGHT)));
                        }
                        else if (lines[i][j] == 'O')
                        {
                            AddFloorO(new FloorO((short)(j * SpriteE.SPRITEE_WIDTH), (short)(i * SpriteE.SPRITEE_HEIGHT)));
                        }
                        else if (lines[i][j] == 'P')
                        {
                            AddFloorP(new FloorP((short)(j * SpriteF.SPRITEF_WIDTH), (short)(i * SpriteF.SPRITEF_HEIGHT)));
                        }
                        else if (lines[i][j] == 'Q')
                        {
                            AddFloorQ(new FloorQ((short)(j * SpriteG.SPRITEG_WIDTH), (short)(i * SpriteG.SPRITEG_HEIGHT)));
                        }
                        else if (lines[i][j] == 'a') // Walls on Level
                        {
                            AddWallA(new WallA((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'b') // +8 (On downcase vocabulary)
                        {
                            AddWallB(new WallB((short)(j * SpriteA.SPRITEA_WIDTH), (short)(i * SpriteA.SPRITEA_HEIGHT)));
                        }
                        else if (lines[i][j] == '1')
                        {
                            XMap1 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap1 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap1 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap1 = (short)(i * SpriteC.SPRITEC_HEIGHT);*/

                        }
                        else if (lines[i][j] == '2')
                        {
                            XMap2 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap2 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap2 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap2 = (short)(i * SpriteC.SPRITEC_HEIGHT);*/
                        }
                        else if (lines[i][j] == '3')
                        {
                            XMap3 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap3 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap3 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap3 = (short)(i * SpriteC.SPRITEC_HEIGHT);*/

                        }
                        else if (lines[i][j] == '4')
                        {
                            XMap4 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap4 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap4 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap4 = (short)(i * SpriteC.SPRITEC_HEIGHT);*/
                        }
                        else if (lines[i][j] == '5')
                        {
                            XMap5 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap5 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap5 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap5 = (short)(i * SpriteC.SPRITEC_HEIGHT);*/
                        }
                        else if (lines[i][j] == '6')
                        {
                            XMap6 = (short)(j * SpriteA.SPRITEA_WIDTH);
                            YMap6 = (short)(i * SpriteA.SPRITEA_HEIGHT);
                            /*XMap6 = (short)(j * SpriteC.SPRITEC_WIDTH);
                            YMap6 = (short)(i * SpriteC.SPRITEC_HEIGHT);
                            XMap6 = (short)(j * SpriteD.SPRITED_WIDTH);
                            YMap6 = (short)(i * SpriteD.SPRITED_HEIGHT);
                            XMap6 = (short)(j * SpriteE.SPRITEE_WIDTH);
                            YMap6 = (short)(i * SpriteE.SPRITEE_HEIGHT);
                            XMap6 = (short)(j * SpriteF.SPRITEF_WIDTH);
                            YMap6 = (short)(i * SpriteF.SPRITEF_HEIGHT);
                            XMap6 = (short)(j * SpriteG.SPRITEG_WIDTH);
                            YMap6 = (short)(i * SpriteG.SPRITEG_HEIGHT);*/
                        }
                        else if (lines[i][j] == 'S') //Start Point
                        {
                            Start = new StartPoint((short)(j * SpriteCharacter.SPRITECA_WIDTH), (short)(i * SpriteCharacter.SPRITECA_HEIGHT));
                            //Start.X -= XMap;
                            //Start.Y -= YMap;
                        }
                        else if (lines[i][j] == 'z') //Normal Exit Point
                        {
                            ExitLevel = new ExitPoint((short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT));
                        }
                        else if (lines[i][j] == 'Z') //Final Exit Point
                        {
                            ExitExLevel = new ExitExPoint((short)(j * SpriteItemsB.SPRITEIB_WIDTH), (short)(i * SpriteItemsB.SPRITEIB_HEIGHT));
                        }
                        else if (lines[i][j] == 'Y') // Points Star
                        {
                            items.Add(new Items(Items.ItemType.Y_STAR, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'X') // Points Star x2
                        {
                            items.Add(new Items(Items.ItemType.R_STAR, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'W') // Points Star x3 and Life
                        {
                            items.Add(new Items(Items.ItemType.G_STAR, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'V') // Points Flower
                        {
                            items.Add(new Items(Items.ItemType.F_FLOWER, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'U') // Points Flower x2
                        {
                            items.Add(new Items(Items.ItemType.I_FLOWER, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'T') // Points Flower x3 and Time
                        {
                            items.Add(new Items(Items.ItemType.P_FLOWER, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'R') // Points Berry
                        {
                            items.Add(new Items(Items.ItemType.R_BERRY, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'y') // Points Berry x2
                        {
                            items.Add(new Items(Items.ItemType.P_BERRY, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        else if (lines[i][j] == 'x') // Points Cherry
                        {
                            items.Add(new Items(Items.ItemType.CHERRY, (short)(j * SpriteItemsA.SPRITEIA_WIDTH), (short)(i * SpriteItemsA.SPRITEIA_HEIGHT)));
                        }
                        //TODO ADD ENEMIES

                    }
                }

            }

        }
        public void AddWallA(WallA w)
        {
            wallA.Add(w);
        }
        public void AddWallB(WallB x)
        {
            wallB.Add(x);
        }
        public void AddFloorA(FloorA v)
        {
            floorA.Add(v);
        }
        public void AddFloorB(FloorB u)
        {
            floorB.Add(u);
        }
        public void AddFloorC(FloorC s)
        {
            floorC.Add(s);
        }
        public void AddFloorD(FloorD t)
        {
            floorD.Add(t);
        }
        public void AddFloorE(FloorE r)
        {
            floorE.Add(r);
        }
        public void AddFloorF(FloorF q)
        {
            floorF.Add(q);
        }
        public void AddFloorG(FloorG p)
        {
            floorG.Add(p);
        }
        public void AddFloorH(FloorH o)
        {
            floorH.Add(o);
        }
        public void AddFloorI(FloorI m)
        {
            floorI.Add(m);
        }
        public void AddFloorJ(FloorJ n)
        {
            floorJ.Add(n);
        }
        public void AddFloorK(FloorK r)
        {
            floorK.Add(r);
        }
        public void AddFloorL(FloorL j)
        {
            floorL.Add(j);
        }
        public void AddFloorM(FloorM k)
        {
            floorM.Add(k);
        }
        public void AddFloorN(FloorN l)
        {
            floorN.Add(l);
        }
        public void AddFloorO(FloorO i)
        {
            floorO.Add(i);
        }
        public void AddFloorP(FloorP h)
        {
            floorP.Add(h);
        }
        public void AddFloorQ(FloorQ f)
        {
            floorQ.Add(f);
        }


        public ushort CollidesCharacterAWith1_UPItem(MainCharacterA characterA)
        {
            int pos = 0;
            ushort result = 0;
            while (pos < items.Count && result == 0)
            {
                if (characterA.CollidesWith(items[pos]))
                {
                    result += items[pos].Lives;
                    items.RemoveAt(pos);
                }
                pos++;
            }
            return result;
        }

        public ushort CollidesCharacterBWith1_UPItem(MainCharacterB characterB)
        {
            int pos = 0;
            ushort result = 0;
            while (pos < items.Count && result == 0)
            {
                if (characterB.CollidesWith(items[pos]))
                {
                    result += items[pos].Lives;
                    items.RemoveAt(pos);
                }
                pos++;
            }
            return result;
        }

        public bool CollidesCharacterWithItems(MainCharacterA characterA)
        {
            int pos = 0;
            bool collided = false;
            while (pos < items.Count && !collided)
            {
                if (characterA.CollidesWith(items[pos]))
                {
                    collided = true;
                    items.RemoveAt(pos);
                }
                pos++;
            }
            return collided;
        }

        public bool CollidesCharacterWithItemsB(MainCharacterB characterB)
        {
            int pos = 0;
            bool collided = false;
            while (pos < items.Count && !collided)
            {
                if (characterB.CollidesWith(items[pos]))
                {
                    collided = true;
                    items.RemoveAt(pos);
                }
                pos++;
            }
            return collided;
        }
    
    }
}
