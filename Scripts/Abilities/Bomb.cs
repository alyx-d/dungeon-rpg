using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Abilities;

public partial class Bomb : Ability
{
    public override void _Ready()
    {
        AnimPlayerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName)
    {
        if (animName == GameConstants.AnimExpand)
        {
            AnimPlayerNode.Play(GameConstants.AnimExplosion);
        }
        else
        {
            QueueFree();
        }
    }
}