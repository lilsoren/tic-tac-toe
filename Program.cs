using System;
using System.Collections.Generic;

namespace Program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard();
            string currentPlayer = "x";

            // Display board
            

            //get input
            while (!GameOver(board))
            {

                DisplayBoard(board);

                int turn = GetMoveChoice(currentPlayer);
                MakeMove(board, turn, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            DisplayBoard(board);
            Console.WriteLine("Game over. Thanks for playing");
        }

        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();

            //getting the numbers 1-9 for player to choose from
            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;

        }


        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine(board[0] + "|" + board[1] + "|" + board[2]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(board[3] + "|" + board[4] + "|" + board[5]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(board[6] + "|" + board[7] + "|" + board[8]);
        }


        static bool GameOver(List<string> board)
        {
            bool GameOver = false;

            if (Winner(board, "x") || Winner(board, "o") || Tie(board))
            {
                GameOver = true;
            }

            return GameOver;
        }


        static bool Winner(List<string> baord, string player)
        {
            bool Winner = false;

            if (
                //horizontal wins
                (baord[0] == player && baord[1] == player && baord[2] == player)
                || (baord[3] == player && baord[4] == player && baord[5] == player)
                || (baord[6] == player && baord[7] == player && baord[8] == player)
                //vertical wins
                || (baord[0] == player && baord[3] == player && baord[6] == player)
                || (baord[1] == player && baord[4] == player && baord[7] == player)
                || (baord[2] == player && baord[5] == player && baord[8] == player)
                //diagonal wins
                || (baord[0] == player && baord[4] == player && baord[8] == player)
                || (baord[2] == player && baord[4] == player && baord[6] == player)  
                )
            {
                Winner = true;
            }

            return Winner;
        }

        static bool Tie(List<string> board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return!foundDigit;
        }

        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        static int GetMoveChoice(String currentPlayer)
        {
            Console.Write($"{currentPlayer}, choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }


        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            int index = choice -1;

            board[index] = currentPlayer;
        }
    }
}