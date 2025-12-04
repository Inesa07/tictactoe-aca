namespace TicTacToeACA.Models.Board;

public interface IBoard
{
    bool IsPositionEmpty(int position);
    int[] GetAvailablePositions();
    void Reset();
    bool PlaceSymbol(int position, char symbol);
    bool CheckWin(char symbol);
    bool IsFull();
    void Display(int highlightPos);
    void ClearPosition(int position);
    bool InBounds(int position);
}