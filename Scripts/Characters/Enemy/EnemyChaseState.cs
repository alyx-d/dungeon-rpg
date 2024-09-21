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
        _target = CharacterNode.ChaseArea3DNode.GetOverlappingBodies()
            .First() as CharacterBody3D;

        _chaseTimer.Timeout += HandleTimeout;
    }

    protected override void ExitState()
    {
        _chaseTimer.Timeout -= HandleTimeout;
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
}