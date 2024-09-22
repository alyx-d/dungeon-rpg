using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyStunState : EnemyState
{
    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimStun);
        
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        if (CharacterNode.AttackArea3dNode.HasOverlappingBodies())
        {
            CharacterNode.StateMachineNode.SwitchState<EnemyAttackState>();
        }
        else if (CharacterNode.ChaseArea3dNode.HasOverlappingBodies())
        {
            CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
        }
        else
        {
            CharacterNode.StateMachineNode.SwitchState<EnemyIdleState>();
        }
    }
}