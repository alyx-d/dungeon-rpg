using DungeonRpg.Scripts.General;
using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.InputLeft,
            GameConstants.InputRight,
            GameConstants.InputForward,
            GameConstants.InputBackward
        );
    }

    public override void _Ready()
    {
        base._Ready();

        GameEvents.OnReward += HandleReward;
    }

    private void HandleReward(RewardResource reward)
    {
        GetStatResource(reward.TargetStat).StatValue += reward.Amount;
    }
}