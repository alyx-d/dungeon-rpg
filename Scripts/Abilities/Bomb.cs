using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Abilities;

public partial class Bomb : Node3D
{
    [Export] public float Damage { get; private set; } = 10;
    [Export] private AnimationPlayer _animPlayerNode;

    public override void _Ready()
    {
        _animPlayerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName)
    {
        if (animName == GameConstants.AnimExpand)
        {
            _animPlayerNode.Play(GameConstants.AnimExplosion);
        }
        else
        {
            QueueFree();
        }
    }
}