using DungeonRpg.Scripts.General;
using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Reward;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D _area3dNode;
    [Export] private Sprite3D _sprite3dNode;
    [Export] private RewardResource _rewardResource;

    public override void _Ready()
    {
        _area3dNode.BodyEntered += _ => _sprite3dNode.Visible = true;
        _area3dNode.BodyExited += _ => _sprite3dNode.Visible = false;
    }

    public override void _Input(InputEvent @event)
    {
        if (!_area3dNode.Monitoring ||
            !_area3dNode.HasOverlappingBodies() ||
            !Input.IsActionJustPressed(GameConstants.InputInteract)
           )
        {
            return;
        }

        _area3dNode.Monitoring = false;
        GameEvents.RaiseReward(_rewardResource);
    }
}