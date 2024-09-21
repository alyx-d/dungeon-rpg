using DungeonRpg.General;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
    }
}