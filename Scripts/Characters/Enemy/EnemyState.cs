using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyState : CharacterState
{
    protected Vector3 Destination;

    public override void _Ready()
    {
        base._Ready();

        CharacterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    protected Vector3 GetPointGlobalPosition(int idx)
    {
        var localPos = CharacterNode.Path3DNode.Curve.GetPointPosition(idx);
        return localPos + CharacterNode.Path3DNode.GlobalPosition;
    }

    protected void Move()
    {
        CharacterNode.NavigationAgent3DNode.GetNextPathPosition();
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(Destination);
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    protected void HandleChaseAreaBodyEntered(Node3D bodyNode)
    {
        CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }

    private void HandleZeroHealth()
    {
        CharacterNode.StateMachineNode.SwitchState<EnemyDeathState>();
    }
}