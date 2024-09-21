using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyPatrolState : EnemyState
{
    private int _pointIdx = 0;

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        _pointIdx = 1;
        Destination = GetPointGlobalPosition(_pointIdx);
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;

        CharacterNode.NavigationAgent3DNode.NavigationFinished += HandleNavigationFinished;
    }

    protected override void ExitState()
    {
        CharacterNode.NavigationAgent3DNode.NavigationFinished -= HandleNavigationFinished;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleNavigationFinished()
    {
        _pointIdx = Mathf.Wrap(_pointIdx + 1, 0, CharacterNode.Path3DNode.Curve.PointCount);
        Destination = GetPointGlobalPosition(_pointIdx);
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;
    }
}