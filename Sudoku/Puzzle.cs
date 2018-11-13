﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Puzzle
    {
        public bool IsSolved { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSaved { get; set; }
        public int Timer { get; set; }
        public int RecordTime { get; set; }
        public char[,] InitialState;
        public char[,] SolutionState;
        public char[,] SavedState;

        // Constructor
        public Puzzle(string filePath)
        {
            IsSolved = false;
            IsCompleted = false;
            IsSaved = false;

            Timer = 0;
            RecordTime = 0;

            using (StreamReader inFile = new StreamReader(filePath))
            {
                string buffer;
                buffer = inFile.ReadLine();
                InitialState = new char[9, 9];
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        InitialState[i, j] = buffer[j];
                    } // end inner for-loop

                    buffer = inFile.ReadLine();
                } // end outer for-loop

                Console.WriteLine("Initial State");
                PrintPuzzleState(InitialState);
                Console.WriteLine();

                buffer = inFile.ReadLine();
                SolutionState = new char[9, 9];
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        SolutionState[i, j] = buffer[j];
                    } // end inner for-loop

                    buffer = inFile.ReadLine();
                } // end outer for-loop

                Console.WriteLine("Solution State");
                PrintPuzzleState(SolutionState);
                Console.WriteLine();
            }
        } // end Constructor
        
        public static double CalculateDifficultyAverage(List<Puzzle> puzzlePool)
        {
            int total, sum;
            for (total = 0, sum = 0; total < puzzlePool.Count; total++)
            {
                sum += puzzlePool[total].RecordTime;
            }

            return sum / total;
        }

        public void PrintPuzzleState(char[,] state)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(state[i, j]);
                }

                Console.WriteLine();
            }
        }
    } // end Puzzle class
} // end Sudoku namespace
