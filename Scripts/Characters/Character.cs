using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public Sprite3D Sprite3dNode { get; private set; }

    [Export] public AnimationPlayer AnimPlayerNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }

    [ExportGroup("AI Nodes")] [Export] public Path3D Path3DNode { get; private set; }
    [Export] public NavigationAgent3D NavigationAgent3DNode { get; private set; }

    public Vector2 Direction = Vector2.Zero;


    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        Sprite3dNode.FlipH = isMovingLeft;
    }
}