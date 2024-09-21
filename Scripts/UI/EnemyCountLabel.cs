using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += HandleNewEnemyCount;
    }

    private void HandleNewEnemyCount(int count)
    {
        Text = count.ToString();
    }
}