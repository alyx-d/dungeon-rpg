using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerState : CharacterState
{
    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.InputAttack))
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }
}