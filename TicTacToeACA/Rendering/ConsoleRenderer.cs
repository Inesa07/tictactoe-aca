using TicTacToeACA.Models;

namespace TicTacToeACA.Rendering;

public class ConsoleRenderer : IRenderer
{
    public void Clear()
    {
        Console.Clear();
    }

    public void SetCursor(Coord position)
    {
        Console.SetCursorPosition(position.X, position.Y);
    }

    public void NewLine()
    {
        Console.WriteLine();
    }

    public void DrawText(string text, TextStyle style = TextStyle.Normal)
    {
        ApplyTextStyle(style);
        Console.Write(text);
        Console.ResetColor();
    }


    public void DrawTextAt(string text, Coord position, TextStyle style = TextStyle.Normal)
    {
        SetCursor(position);
        DrawText(text, style);
    }

    public void DrawCell(char symbol, CellStyle cellStyle)
    {
        ApplyCellStyle(cellStyle);
        Console.Write(symbol);
        Console.ResetColor();
    }

    public void DrawCellAt(char symbol, Coord position, CellStyle cellStyle)
    {
        SetCursor(position);
        DrawCell(symbol, cellStyle);
    }

    private void ApplyTextStyle(TextStyle style)
    {
        switch (style)
        {
            case TextStyle.Header:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case TextStyle.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case TextStyle.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case TextStyle.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case TextStyle.Highlight:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                break;
            case TextStyle.Muted:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
            case TextStyle.Normal:
            default:
                // Keep default colors
                break;
        }
    }

    private void ApplyCellStyle(CellStyle cellStyle)
    {
        switch (cellStyle)
        {
            case CellStyle.PlayerX:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case CellStyle.PlayerO:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case CellStyle.HighlightedEmpty:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
                break;
            case CellStyle.HighlightedOccupied:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                break;
            case CellStyle.Empty:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
        }
    }
}