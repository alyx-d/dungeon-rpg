using System.Linq;
using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer _chaseTimer;
    private CharacterBody3D _target;

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        _target = CharacterNode.ChaseArea3dNode.GetOverlappingBodies()
            .First() as CharacterBody3D;

        _chaseTimer.Timeout += HandleTimeout;
        CharacterNode.ChaseArea3dNode.BodyExited += HandleChaseAreaBodyExited;
        CharacterNode.AttackArea3dNode.BodyEntered += HandleAttackAreaBodyEntered;
    }

    protected override void ExitState()
    {
        _chaseTimer.Timeout -= HandleTimeout;
        CharacterNode.ChaseArea3dNode.BodyExited -= HandleChaseAreaBodyExited;
        CharacterNode.AttackArea3dNode.BodyEntered -= HandleAttackAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleTimeout()
    {
        Destination = _target.GlobalPosition;
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;
    }

    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        CharacterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }

    private void HandleChaseAreaBodyExited(Node3D body)
    {
        CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}