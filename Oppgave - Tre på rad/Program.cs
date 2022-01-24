using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oppgave___Tre_på_rad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boardModel = new BoardModel();
            NewGame(boardModel);
        }

        private static void  NewGame(BoardModel boardModel)
        {
            while (true)
            {
                Console.Clear();
                BoardView.Show(boardModel);
                Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
                var position = Console.ReadLine();
                boardModel.SetCross(position);
                if (GameOver(boardModel)) break;
                boardModel.SetRandomCircle();
                if (GameOver(boardModel)) break;
            }
        }

        public static bool GameOver(BoardModel boardModel)
        {
            if (boardModel.GameOver)
            {
                if (boardModel.victory)
                {
                    if (boardModel.winner == "x") Console.WriteLine($"{boardModel.winner} has won!\nDo you want to win again? If yes write: reset\n");
                    else Console.WriteLine($"You didn't win!\nDo you want to lose again? If yes write: reset\n");
                }
                if (Console.ReadLine() == "reset")
                {
                    boardModel.Reset();
                    NewGame(boardModel);
                }
                return true;
            }
            return false;
        }
    }
}
