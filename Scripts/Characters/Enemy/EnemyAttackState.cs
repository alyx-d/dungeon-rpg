using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyAttackState : EnemyState
{
    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
        GD.Print("Enemy Attack state entered");
    }
}