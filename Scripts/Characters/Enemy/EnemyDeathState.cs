using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimDeath);

        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        CharacterNode.Path3DNode.QueueFree();
    }
}