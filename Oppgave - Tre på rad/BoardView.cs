using System;

namespace Oppgave___Tre_på_rad
{
    public class BoardView
    {
        public BoardView()
        {
            
        }

        public static void Show(BoardModel b)
        {
            Console.Write($@"  a b c
 ┌─────┐
1|{b.board[0]} {b.board[3]} {b.board[6]}│
2|{b.board[1]} {b.board[4]} {b.board[7]}│
3|{b.board[2]} {b.board[5]} {b.board[8]}│
 └─────┘");
        }
    }
}