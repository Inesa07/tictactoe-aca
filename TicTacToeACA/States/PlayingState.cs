using TicTacToeACA.Core;

namespace TicTacToeACA.States;

public class PlayingState:GameState
{
    public override void Handle(GameEngine engine)
    {
        engine.PlayGame();
    }
}