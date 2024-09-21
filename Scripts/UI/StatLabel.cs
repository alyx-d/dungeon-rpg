using System.Globalization;
using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class StatLabel : Label
{
    [Export] private StatResource _statResource;

    public override void _Ready()
    {
        _statResource.OnUpdate += HandleUpdate;
        Text = _statResource.StatValue.ToString(CultureInfo.InvariantCulture);
    }

    private void HandleUpdate()
    {
        Text = _statResource.StatValue.ToString(CultureInfo.InvariantCulture);
    }
}