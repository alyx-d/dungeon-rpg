using DungeonRpg.Scripts.General;
using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();

        CharacterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.InputAttack))
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }

    private void HandleZeroHealth()
    {
        CharacterNode.StateMachineNode.SwitchState<PlayerDeathState>();
    }
}