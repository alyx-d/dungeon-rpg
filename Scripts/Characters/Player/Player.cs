using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.InputLeft,
            GameConstants.InputRight,
            GameConstants.InputForward,
            GameConstants.InputBackward
        );
    }
}