﻿using ChessMi.Core.Data.Models;
using ChessMi.Core.Services.Interfaces;
using ChessMi.Core.Data.Enums;
using ChessMi.Core.Data.Models;
using static ChessMi.Core.Common.GlobalConstants;

namespace ChessMi.Core.Services
{
    public class BoardGeneratorService
    {

        /// <summary>
        /// Generates a two dimensional array of Tile which will be our board.
        /// </summary>
        /// <returns></returns>
        public static Tile[,] Generate() // Could move to Interface
        {
            Tile[,] board = new Tile[BoardRows, BoardColumns];

            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    Tile tile;
                    Figure figure = GetFigure(i, j);

                    if ((i + j) % 2 == 0)
                    {
                        tile = new Tile(i, j, Color.White, figure);
                    }
                    else
                    {
                        tile = new Tile(i, j, Color.Black, figure);
                    }

                    board[i, j] = tile;
                }
            }


            return board;
        }

        /// <summary>
        /// Returns the generated figure on startup.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>Pawn, Rook, Bishop, Knight, Queen or a King</returns>
        private static Figure GetFigure(int row, int col)
        {
            Figure figure = new Empty(row, col);

            if (row == 0)
            {
                if (col == 0 || col == 7)
                {
                    figure = new Rook(row, col, Color.Black);
                }

                if (col == 1 || col == 6)
                {
                    figure = new Knight(row, col, Color.Black);
                }

                if (col == 2 || col == 5)
                {
                    figure = new Bishop(row, col, Color.Black);
                }

                if (col == 4)
                {
                    figure = new King(row, col, Color.Black);
                }

                if (col == 3)
                {
                    figure = new Queen(row, col, Color.Black);
                }
            }

            if (row == 1)
            {
                figure = new Pawn(row, col, Color.Black);
            }

            if (row == 6)
            {
                figure = new Pawn(row, col, Color.White);
            }

            if (row == 7)
            {
                if (col == 0 || col == 7)
                {
                    figure = new Rook(row, col, Color.White);
                }

                if (col == 1 || col == 6)
                {
                    figure = new Knight(row, col, Color.White);
                }

                if (col == 2 || col == 5)
                {
                    figure = new Bishop(row, col, Color.White);
                }

                if (col == 4)
                {
                    figure = new King(row, col, Color.White);
                }

                if (col == 3)
                {
                    figure = new Queen(row, col, Color.White);
                }
            }

            return figure;
        }
    }
}