﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InsertionSortWithVisualizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] visualizerSize = { 29, 120 }; // rows and columns of console

            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int[] newDispl = new int[visualizerSize[1]];
            int[] curDispl = new int[visualizerSize[1]];
            int temp = 0;

            /*
             * Possible colors:
             * 0 : Reset Color
             * 1 : Blue
             * 2 : Red
             * 3 : Green
             * 4 : Cyan
             * 5 : Dark Blue
             * 6 : Foreground Red
             */

            int toInsert = 0;
            bool fromStart = false;
            int insertIndex = -1;
            bool insertFlag = false;

            for (int x = 0; x < arr.Length; x++)
                arr[x] = rnd.Next(visualizerSize[0]) + 1;

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using insertion sort... Press any key to begin...");
            Console.ReadKey();
            //Console.Clear(); 
            #endregion

            for (int x = 1; x < arr.Length; x++)
            /*
             * We start from 1 because 0 has nothing to its left
             * it is assumed that 0 is already sorted
             */
            {
                newDispl[x] = 4;
                insertIndex = -1;
                insertFlag = false;
                // checking if x is in correct location
                #region Highlighting cell to be checked
                for (int a = 0; a < arr.Length; a++)
                //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                {
                    for (int b = visualizerSize[0]; b > 0; b--)
                    //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                    {
                        if (newDispl[a] != curDispl[a])
                        {
                            Console.SetCursorPosition(a, b - 1);
                            switch (newDispl[a])
                            {
                                case 0:
                                    Console.ResetColor();
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case 6:
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    break;
                            }

                            if (arr[a] > visualizerSize[0] - b)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                    }

                    curDispl[a] = newDispl[a];
                    newDispl[a] = 0;
                }
                Console.SetCursorPosition(0, 29);
                Console.Write("Pass {0} : Initializing . . .                                          ", x);
                //Console.ReadKey();
                //Thread.Sleep(200);
                //Console.Clear(); 
                #endregion

                // the algorithm that begins its search from the 0 index
                if (fromStart)
                {
                    for (int y = 0; y < x; y++)
                    {
                        // searching
                        newDispl[x] = 1;
                        newDispl[y] = 2;
                        #region Highlighting cell being searched
                        for (int a = 0; a < arr.Length; a++)
                        //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                        {
                            for (int b = visualizerSize[0]; b > 0; b--)
                            //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                            {
                                if (newDispl[a] != curDispl[a])
                                {
                                    Console.SetCursorPosition(a, b - 1);
                                    switch (newDispl[a])
                                    {
                                        case 0:
                                            Console.ResetColor();
                                            break;
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                    }

                                    if (arr[a] > visualizerSize[0] - b)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }

                            curDispl[a] = newDispl[a];
                            newDispl[a] = 0;
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Pass {0} : Searching. . .                                              ", x);
                        //Console.ReadKey();
                        //Thread.Sleep(200);
                        //Console.Clear(); 
                        #endregion
                        if (arr[x] < arr[y])
                        {
                            insertFlag = true;
                            insertIndex = y;
                            break;
                        }
                    }
                }
                else
                {
                    for (int y = x - 1; y >= 0; y--)
                    {
                        // searching
                        newDispl[x] = 1;
                        newDispl[y] = 2;
                        #region Highlighting cell being searched
                        for (int a = 0; a < arr.Length; a++)
                        //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                        {
                            for (int b = visualizerSize[0]; b > 0; b--)
                            //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                            {
                                if (newDispl[a] != curDispl[a])
                                {
                                    Console.SetCursorPosition(a, b - 1);
                                    switch (newDispl[a])
                                    {
                                        case 0:
                                            Console.ResetColor();
                                            break;
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                    }

                                    if (arr[a] > visualizerSize[0] - b)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }

                            curDispl[a] = newDispl[a];
                            newDispl[a] = 0;
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Pass {0} : Searching. . .                                              ", x);
                        //Console.ReadKey();
                        //Thread.Sleep(200);
                        //Console.Clear(); 
                        #endregion
                        if (arr[x] < arr[y])
                        {
                            insertFlag = true;
                            insertIndex = y;
                        }
                        else
                            break;
                    }
                }

                if (insertFlag)
                {
                    //Console.WriteLine("Preparing to move...");

                    toInsert = arr[x];
                    arr[x] = 0;
                    newDispl[x] = 6;

                    #region Preparing to move
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case 5:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    case 6:
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Moving value to memory. . .                                 ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion


                    // this is the logic that moves values around
                    for (int y = x - 1; y >= insertIndex; y--)
                    {
                        arr[y + 1] = arr[y];
                        arr[y] = -1;

                        newDispl[y + 1] = 5;
                        newDispl[y] = 6;

                        #region Moving
                        for (int a = 0; a < arr.Length; a++)
                        //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                        {
                            for (int b = visualizerSize[0]; b > 0; b--)
                            //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                            {
                                if (newDispl[a] != curDispl[a])
                                {
                                    Console.SetCursorPosition(a, b - 1);
                                    switch (newDispl[a])
                                    {
                                        case 0:
                                            Console.ResetColor();
                                            break;
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                    }

                                    if (arr[a] > visualizerSize[0] - b)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }

                            curDispl[a] = newDispl[a];
                            newDispl[a] = 0;
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Pass {0} : Moving . . .                                                ", x);
                        //Console.ReadKey();
                        //Thread.Sleep(200);
                        //Console.Clear(); 
                        #endregion
                    }

                    arr[insertIndex] = toInsert;
                    newDispl[insertIndex] = 4;
                    #region Placing
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case 5:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    case 6:
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Placing value in its proper place . . .                     ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                }
            }

            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
