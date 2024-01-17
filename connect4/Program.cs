using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace connect4
{
    internal class Program
    {
       public static int[][] map1 = new int[6][];
       

        static void Main(string[] args)
        {
          
            //Game initialization
            map1[0] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            map1[1] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            map1[2] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            map1[3] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            map1[4] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            map1[5] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

            int currentX = 0;
            int Turn = 1;
            int InARow = 0;

            Console.CursorVisible = false;
            DrawArrow(currentX);
            DrawData(map1);
            

            //Game loop
            while (!Check.FullCheck(ref InARow, map1, 1) | !Check.FullCheck(ref InARow, map1, 2))
            {
                
                
                DrawArrow(currentX);
                currentX = Movement(currentX, ref Turn);
                DrawData(map1);
                
            }
            Console.ReadLine();

        }
        static void DrawArrow( int XPos)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("                 " );
            Console.SetCursorPosition(XPos, 0);
            Console.Write("^");
        }
        static int Movement(int XPos,ref int Turn)
        {
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (XPos==0)
                    {
                        break;
                    }
                    else 
                    {
                        XPos -= 2;
                        break;
                    }
                    
                case ConsoleKey.RightArrow:
                    if (XPos == 12)
                    {
                        break;
                    }
                    else
                    {
                        XPos += 2;
                        break;
                    }
                case ConsoleKey.Enter:

                    int choice = XPos / 2;
                    int Ypos = 5;
                Start:
                    if (map1[Ypos][choice] != 0)
                    {
                        if (Ypos==0)
                        {

                            Console.WriteLine("Wrong Move!");
                            break;
                        } 
                        Ypos -= 1;
                        goto Start;
                    }
                    else
                    {
                        map1[Ypos][choice] = Turn;
                        if (Turn == 1)
                        {
                            Turn = 2;
                        }
                        else Turn = 1;

                    }
                        

                    ;
                    break;
                    
                default:
                    break;
            }
            return XPos;
        }


        static void DrawData(int[][] map )
        {
            Console.SetCursorPosition(0, 1);
            

            for (int i = 0; i < map.Length; i++)
            {
                foreach (var item in map[i])
                {
                    if (item ==1 )
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(item + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (item == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(item + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(item + " ");
                    }

                }
                Console.WriteLine();
            }
        }
        static void DrawMap()
        {
            Console.WriteLine(
                "| | | | | | | |\n" +
                "| | | | | | | |\n" +
                "| | | | | | | |\n" +
                "| | | | | | | |\n" +
                "| | | | | | | |\n" +
                "| | | | | | | |\n" +
                "¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯\n");
        }

        
    }
}
