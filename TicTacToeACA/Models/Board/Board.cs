using TicTacToeACA.Rendering;

namespace TicTacToeACA.Models.Board;

public class Board : IBoard
{
    private IRenderer _renderer;
    private char[] _cells;

    private int[,] _winPatterns = new int[,]
    {
        { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, //Rows
        { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, //Columns
        { 0, 4, 8 }, { 2, 4, 6 } //Diagonal
    };

    public const int Width = 3;
    public const int Height = 3;

    public static readonly Coord Bounds = new Coord(Width, Height);

    public int BoardSize => Width * Height;

    public Board(IRenderer renderer)
    {
        _renderer = renderer;
        _cells = new char[BoardSize];
        Reset();
    }

    public void Reset()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            _cells[i] = ' ';
        }
    }

    public bool PlaceSymbol(int position, char symbol)
    {
        if (InBounds(position))
        {
            _cells[position] = symbol;
            return true;
        }

        return false;
    }

    public void ClearPosition(int position)
    {
        if (InBounds(position))
        {
            _cells[position] = ' ';
        }
    }

    public bool IsPositionEmpty(int position)
    {
        return InBounds(position) && _cells[position] == ' ';
    }

    public bool InBounds(int position) => position >= 0 && position < BoardSize;

    public bool IsFull()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i] == ' ')
            {
                return false;
            }
        }

        return true;
    }

    public void Display(int highlightPos)
    {
        _renderer.NewLine();
        _renderer.DrawText("      |      |      ");
        _renderer.NewLine();
        DrawBoardRow(0, 1, 2, highlightPos);

        _renderer.DrawText("______|______|______");
        _renderer.NewLine();
        _renderer.DrawText("      |      |      ");
        _renderer.NewLine();

        DrawBoardRow(3, 4, 5, highlightPos);

        _renderer.DrawText("______|______|______");
        _renderer.NewLine();
        _renderer.DrawText("      |      |      ");
        _renderer.NewLine();

        DrawBoardRow(6, 7, 8, highlightPos);
        _renderer.DrawText("      |      |      ");
        _renderer.NewLine();
        _renderer.NewLine();
    }

    private void DrawBoardRow(int pos1, int pos2, int pos3, int highlightPos)
    {
        _renderer.DrawText("  ");
        DrawCellInline(pos1, highlightPos);
        _renderer.DrawText("   |  ");
        DrawCellInline(pos2, highlightPos);
        _renderer.DrawText("   |  ");
        DrawCellInline(pos3, highlightPos);
        _renderer.DrawText("  ");
        _renderer.NewLine();
    }

    private void DrawCellInline(int pos, int highlightPos)
    {
        char cellChar = _cells[pos] == ' ' ? ' ' : _cells[pos];
        CellStyle style = GetCellStyle(pos, highlightPos);
        _renderer.DrawCell(cellChar, style);
    }

    private CellStyle GetCellStyle(int pos, int highlightPos)
    {
        bool highlighted = pos == highlightPos;
        bool occupied = _cells[pos] != ' ';

        if (highlighted)
        {
            return occupied ? CellStyle.HighlightedOccupied : CellStyle.HighlightedEmpty;
        }

        if (_cells[pos] == 'X')
        {
            return CellStyle.PlayerX;
        }

        if (_cells[pos] == 'O')
        {
            return CellStyle.PlayerO;
        }

        return CellStyle.Empty;
    }

    public bool CheckWin(char symbol)
    {
        for (int i = 0; i < _winPatterns.GetLength(0); i++)
        {
            if (_cells[_winPatterns[i, 0]] == symbol &&
                _cells[_winPatterns[i, 1]] == symbol &&
                _cells[_winPatterns[i, 2]] == symbol)
            {
                return true;
            }
        }

        return false;
    }

    public int[] GetAvailablePositions()
    {
        int[] available = new int[BoardSize]; // {0, 1, 2, 3}

        int pointer = 0;
        for (int i = 0; i < BoardSize; i++)
        {
            if (_cells[i] == ' ')
            {
                available[pointer++] = i;
            }
        }

        Array.Resize(ref available, pointer);
        return available;
    }
}