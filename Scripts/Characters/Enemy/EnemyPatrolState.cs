using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer _idleTimerNode;

    [Export(PropertyHint.Range, "0,10,0.1")]
    private float _maxIdleTime = 4;

    private int _pointIdx;

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        _pointIdx = 1;
        Destination = GetPointGlobalPosition(_pointIdx);
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;

        CharacterNode.NavigationAgent3DNode.NavigationFinished += HandleNavigationFinished;
        _idleTimerNode.Timeout += HandleTimeout;
        CharacterNode.ChaseArea3dNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        CharacterNode.NavigationAgent3DNode.NavigationFinished -= HandleNavigationFinished;
        _idleTimerNode.Timeout -= HandleTimeout;
        CharacterNode.ChaseArea3dNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!_idleTimerNode.IsStopped())
        {
            return;
        }

        Move();
    }

    private void HandleNavigationFinished()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
        var rng = new RandomNumberGenerator();
        _idleTimerNode.WaitTime = rng.RandfRange(0, _maxIdleTime);
        _idleTimerNode.Start();
    }

    private void HandleTimeout()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);

        _pointIdx = Mathf.Wrap(_pointIdx + 1, 0, CharacterNode.Path3DNode.Curve.PointCount);
        Destination = GetPointGlobalPosition(_pointIdx);
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;
    }
}