using TicTacToeACA.Core;

namespace TicTacToeACA.States;

public class GameOverState:GameState
{
    public override void Handle(GameEngine engine)
    {
        engine.ShowGameOver();
    }
}