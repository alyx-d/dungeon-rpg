using System.Collections.Generic;
using System.Linq;
using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class UiController : Control
{
    private Dictionary<ContainerType, UiContainer> _uiContainers;

    public override void _Ready()
    {
        _uiContainers = GetChildren().Where(it => it is UiContainer)
            .Cast<UiContainer>()
            .ToDictionary(it => it.ContainerType);

        _uiContainers[ContainerType.Start].Visible = true;

        _uiContainers[ContainerType.Start].ButtonNode.Pressed += HandleStartButtonPressed;
    }


    private void HandleStartButtonPressed()
    {
        GetTree().Paused = false;
        _uiContainers[ContainerType.Start].Visible = false;
        GameEvents.RaiseStartGame();
    }
}