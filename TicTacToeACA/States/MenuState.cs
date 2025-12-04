using TicTacToeACA.Core;

namespace TicTacToeACA.States;

public class MenuState : GameState
{
    public override void Handle(GameEngine engine)
    {
        engine.ShowMenu();
    }
}