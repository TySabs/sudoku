﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/************************************************************
 *                                                          *
 *  CSCI 473/504           Assignment 5         Fall 2018   *                                             
 *                                                          *
 *  Programmers: Tyler Saballus                             *
 *                                                          *
 *  Date Due:   Nov-15 (Turned in one day late)             *                          
 *                                                          *
 *  Purpose:    This is a Sudoku app that allows users to   *
 *              play the popular Sudoku game.               *
 ***********************************************************/

namespace Sudoku
{
    public partial class SudokuApp : Form
    {
        public SudokuApp()
        {
            InitializeComponent();
            PopulateDiffComboBox();
            InitFrameSize();
            CenterToScreen();
            InitPuzzleLists();
            PopulateGrid();
        }

        private void InitFrameSize()
        {
            int h = (int) (Screen.PrimaryScreen.WorkingArea.Height * 0.65);
            int w = (int) (Screen.PrimaryScreen.WorkingArea.Width * 0.65);
            Size = new Size(w, h);
        }

        private void BuildPuzzleList(List<Puzzle> puzzleList, string source)
        {
            Puzzle p;
            string filePath;
            for (int i = 1; i < 5; i++)
            {
                filePath = source + i + ".txt";
                p = new Puzzle(filePath);
                puzzleList.Add(p);
            }
        }

        private void InitPuzzleLists()
        {
            string easySrc = "../../Properties/Resources/puzzles/easy/e",
                   mediumSrc = "../../Properties/Resources/puzzles/medium/m",
                   hardSrc = "../../Properties/Resources/puzzles/hard/h";

            BuildPuzzleList(easyPuzzles, easySrc);
            BuildPuzzleList(mediumPuzzles, mediumSrc);
            BuildPuzzleList(hardPuzzles, hardSrc);
        }

        private void InitGrid()
        {
            Puzzle p = easyPuzzles[0];
            SelectedPuzzle = p;
            FillGrid();
        }


    }
}
