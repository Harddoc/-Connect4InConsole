using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    public static class Check
    {
        public static bool FullCheck(ref int InARow, int[][] map1, int player)
        {
            //left to right check
            InARow = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (ECheck(i, j, ref InARow, map1, player))
                    {
                        return true;
                    }
                }
            }

            //up to down check
            InARow = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (SCheck(i, j, ref InARow, map1, player))
                    {
                        return true;
                    }
                }
            }
            //top left to down right
            InARow = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (SECheck(i, j, ref InARow, map1, player))
                    {
                        return true;
                    }
                }
            }
            //top right to down left
            InARow = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    //map1[i][j] = 5;

                    if (SWCheck(i, j, ref InARow, map1, player))
                    {
                        return true;
                    }
                }
            }
            return false;


            //for testing
            //for (int i = 3; i < 5; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //    if (map1[i][j]==0)
            //        {

            //            map1[i][j] = 3;
            //        }
            //    }

        }  

        public static bool ECheck(int x, int y, ref int InARow, int[][] map1, int player)
        {
            
            if (x >= 0 && x <= 6)
            {
                if (map1[y][x] == player)
                {


                    ECheck(x + 1, y, ref InARow, map1, player);
                    InARow += 1;
                    //Console.WriteLine(InARow);
                    if (InARow == 4)
                    {
                        Console.WriteLine($"{player} won");
                        return true;
                    }
                }
                else { InARow = 0; }

            }
            
            return false;
        }
        static bool SCheck(int x, int y, ref int InARow, int[][] map1, int player)
        {
            //
            if (y >= 0 && y <= 5)
            {
                if (map1[y][x] == player)
                {


                    SCheck(x, y + 1, ref InARow, map1, player);
                    InARow += 1;
                    //Console.WriteLine(InARow);
                    if (InARow == 4)
                    {
                        Console.WriteLine($"{player} won");
                        return true;
                    }
                }
                else { InARow = 0; }

            }
            
            return false;
        }
        static bool SECheck(int x, int y, ref int InARow, int[][] map1, int player)
        {
            //
            if (y >= 0 && y <= 5)
            {
                if (map1[y][x] == player)
                {


                    SECheck(x + 1, y + 1, ref InARow, map1, player);
                    InARow += 1;
                    //Console.WriteLine(InARow);
                    if (InARow == 4)
                    {
                        Console.WriteLine($"{player} won");
                        return true;
                    }
                }
                else { InARow = 0; }

            }
            return false;
        }
        public static bool SWCheck(int x, int y, ref int InARow, int[][] map1, int player)
        {
            //
            if  (x<6)
                //(y >= 0 && y <= 5)
            {
                if (map1[x][y] == player)
                {
                    SWCheck(x + 1, y - 1, ref InARow, map1, player);
                    InARow += 1;
                    //Console.WriteLine(InARow);
                    if (InARow == 4)
                    {
                        Console.WriteLine($"{player} won");
                        return true;
                    }
                }
                else { InARow = 0; }
            }
            return false;
            
        }
    }
}
