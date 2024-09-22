namespace DungeonRpg.Scripts.Abilities;

public partial class Lightning : Ability
{
    public override void _Ready()
    {
        AnimPlayerNode.AnimationFinished += _ => QueueFree();
    }
}