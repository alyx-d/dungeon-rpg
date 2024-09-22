using Godot;

namespace DungeonRpg.Scripts.Resources;

[GlobalClass]
public partial class RewardResource : Resource
{
    [Export] public Texture2D Texture2DNode { get; private set; }
    [Export] public string Description { get; private set; }
    [Export] public Stat TargetStat { get; private set; }
    [Export(PropertyHint.Range, "1,100,1")] public float Amount { get; private set; }
}