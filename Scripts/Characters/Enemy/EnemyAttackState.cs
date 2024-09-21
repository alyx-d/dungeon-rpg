using System.Linq;
using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 _targetPosition;

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);

        var target = CharacterNode.AttackArea3dNode
            .GetOverlappingBodies()
            .First();
        _targetPosition = target.GlobalPosition;

        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void PerformHit()
    {
        CharacterNode.ToggleHitBox(false);
        CharacterNode.HitboxNode.GlobalPosition = _targetPosition;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        CharacterNode.ToggleHitBox(true);

        var target = CharacterNode.AttackArea3dNode
            .GetOverlappingBodies()
            .FirstOrDefault();
        if (target == null)
        {
            var chaseTarget = CharacterNode.ChaseArea3dNode
                .GetOverlappingBodies()
                .FirstOrDefault();
            if (chaseTarget == null)
            {
                CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
                return;
            }
            
            CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            return;
        }

        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
        _targetPosition = target.GlobalPosition;

        var direction = CharacterNode.GlobalPosition.DirectionTo(_targetPosition);
        CharacterNode.Sprite3dNode.FlipH = direction.X < 0;
    }
}