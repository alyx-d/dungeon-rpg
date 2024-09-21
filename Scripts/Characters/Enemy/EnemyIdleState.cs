using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyIdleState : EnemyState
{
    public override void _PhysicsProcess(double delta)
    {
        CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
        CharacterNode.ChaseArea3dNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        CharacterNode.ChaseArea3dNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
}