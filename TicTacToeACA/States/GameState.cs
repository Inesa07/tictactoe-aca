using TicTacToeACA.Core;

namespace TicTacToeACA.States;

public abstract class GameState
{
    public abstract void Handle(GameEngine engine);
}