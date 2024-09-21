using System;
using System.Linq;
using DungeonRpg.General;
using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Characters;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] _stats;

    [ExportGroup("Required Nodes")]
    [Export]
    public Sprite3D Sprite3dNode { get; private set; }

    [Export] public AnimationPlayer AnimPlayerNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    [Export] public Area3D HurtboxNode { get; private set; }

    [ExportGroup("AI Nodes")] [Export] public Path3D Path3DNode { get; private set; }
    [Export] public NavigationAgent3D NavigationAgent3DNode { get; private set; }
    [Export] public Area3D ChaseArea3dNode { get; private set; }
    [Export] public Area3D AttackArea3dNode { get; private set; }

    public Vector2 Direction = Vector2.Zero;

    public override void _Ready()
    {
        HurtboxNode.AreaEntered += HandleHurtboxEntered;
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        var health = GetStatResource(Stat.Health);
        var character = area.GetOwner<Character>();
        health.StatValue -= character.GetStatResource(Stat.Strength).StatValue;
        GD.Print($"{character.Name} Health: " + health.StatValue);
    }

    public StatResource GetStatResource(Stat stat)
    {
        var resource = _stats.FirstOrDefault(it => it.StatType == stat);
        if (resource == null)
        {
            GD.Print($"No stat resource found for {stat}");
            throw new ArgumentException($"No stat resource found for {stat}");
        }
        return resource;
    }

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