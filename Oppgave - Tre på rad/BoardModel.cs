using System;
using System.Threading;

namespace Oppgave___Tre_på_rad
{
    public class BoardModel
    {
        private static Random _random = new Random();
        public string[] board = new string[9];
        public string winner;
        public bool victory = false;
        public int moves = 0;
        public bool GameOver = false;


        public BoardModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = " ";
            }
        }


        public void SetCross(string position)
        {
            var x = GetPosition(position);
            if (board[x] == " ")
            {
                board[x] = "x";
                moves++;
                CheckVictory();
            }
        }

        public void SetCross(int position)
        {
            if (board[position] == " ")
            {
                board[position] = "x";
                moves++;
                CheckVictory();
            }
        }

        public void SetCircle(string position)
        {
            board[GetPosition(position)] = "o";
            moves++;
            CheckVictory();
        }

        public void SetCircle(int position)
        {
            board[position] = "o";
            moves++;
            CheckVictory();
        }

        public static int GetPosition(string position)
        {
            int number = 0;
            if (position == "a2") number = 1;
            else if (position == "a3") number = 2;
            else if (position == "b1") number = 3;
            else if (position == "b2") number = 4;
            else if (position == "b3") number = 5;
            else if (position == "c1") number = 6;
            else if (position == "c2") number = 7;
            else if (position == "c3") number = 8;
            return number;
        }

        public void SetRandomCircle()
        {
            while(true)
            {
                var randomPosition = _random.Next(9);
                if (board[randomPosition] == " ")
                {
                    SetCircle(randomPosition);
                    break;
                }
            }
        }

        public void CheckVictory()
        {
            if (board[0] != " " && board[0] == board[3] && board[0] == board[6]) SetVictory(0);
            else if (board[1] != " " && board[1] == board[4] && board[1] == board[7]) SetVictory(1);
            else if (board[2] != " " && board[2] == board[5] && board[2] == board[8]) SetVictory(2);
            else if (board[0] != " " && board[0] == board[1] && board[0] == board[2]) SetVictory(0);
            else if (board[3] != " " && board[3] == board[4] && board[3] == board[5]) SetVictory(3);
            else if (board[6] != " " && board[6] == board[7] && board[6] == board[8]) SetVictory(6);
            else if (board[0] != " " && board[0] == board[4] && board[0] == board[8]) SetVictory(0);
            else if (board[2] != " " && board[2] == board[4] && board[2] == board[6]) SetVictory(2);
        }

        public void SetVictory(int position)
        {
            GameOver = true;
            victory = true;
            winner = board[position];
        }

        public void CheckMoveCount()
        {
            if (moves > 8)
            {
                GameOver = true;
            }
        }

        public void Reset()
        {
            Console.Clear();
            moves = 0;
            GameOver = false;
            Initialize();
            victory = false;
            winner = "";
        }
    }
}