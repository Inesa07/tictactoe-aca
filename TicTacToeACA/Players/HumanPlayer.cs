using TicTacToeACA.Models;
using TicTacToeACA.Models.Board;

namespace TicTacToeACA.Players;

public class HumanPlayer : Player
{
    private Coord _selectedGridPosition;

    public HumanPlayer(string name, char symbol) : base(name, symbol)
    {
    }
    
    public override int GetMove(IBoard board)
    {
        int move = -1;

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                _selectedGridPosition = MoveInDirection(Coord.Left,board);
                break;
            case ConsoleKey.RightArrow:
                _selectedGridPosition = MoveInDirection(Coord.Right,board);
                break;
            case ConsoleKey.UpArrow:
                _selectedGridPosition = MoveInDirection(Coord.Up,board);
                break;
            case ConsoleKey.DownArrow:
                _selectedGridPosition = MoveInDirection(Coord.Down,board);
                break;
            case ConsoleKey.Enter:
                move = GridToLinearPosition(_selectedGridPosition);
                if (board.IsPositionEmpty(move))
                {
                    return move;
                }

                move = -1;
                break;
        }

        return move;
    }

    private Coord MoveInDirection(Coord direction,IBoard board)
    {
        Coord newPosition = _selectedGridPosition + direction;
        return Coord.Clamp(newPosition, Coord.Zero, Board.Bounds - Coord.One);
    }

    private int GridToLinearPosition(Coord coord)
    {
        return coord.Y * Board.Width + coord.X;
    }

    private Coord LinearToGridPosition(int position)
    {
        return new Coord(position % Board.Width, position / Board.Width);
    }

    public int GetSelectedPosition() => GridToLinearPosition(_selectedGridPosition);

}