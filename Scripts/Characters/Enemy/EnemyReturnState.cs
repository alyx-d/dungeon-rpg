using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyReturnState : CharacterState
{
    private Vector3 _destination;
    public override void _Ready()
    {
        base._Ready();

        var localPos = CharacterNode.Path3DNode.Curve.GetPointPosition(0);
        _destination = localPos + CharacterNode.Path3DNode.GlobalPosition;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.NavigationAgent3DNode.IsNavigationFinished())
        {
            GD.Print("Reached the destination");
            return;
        }
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(_destination);
        CharacterNode.MoveAndSlide();
    }

    protected override void EnterState()
    {
        GD.Print("Entered return state");
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.NavigationAgent3DNode.TargetPosition = _destination;
    }
}