using System.Collections.Generic;
using System.Linq;
using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.UI;

public partial class UiController : Control
{
    private Dictionary<ContainerType, UiContainer> _uiContainers;
    private bool _canPause;

    public override void _Ready()
    {
        _uiContainers = GetChildren().Where(it => it is UiContainer)
            .Cast<UiContainer>()
            .ToDictionary(it => it.ContainerType);

        _uiContainers[ContainerType.Start].Visible = true;

        _uiContainers[ContainerType.Start].ButtonNode.Pressed += HandleStartButtonPressed;
        _uiContainers[ContainerType.Pause].ButtonNode.Pressed += HandlePauseButtonPressed;

        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.OnGameVictory += HandleGameVictory;
    }

    public override void _Input(InputEvent @event)
    {
        if (!_canPause)
        {
            return;
        }

        if (!Input.IsActionJustPressed(GameConstants.InputPause))
        {
            return;
        }

        _uiContainers[ContainerType.Stats].Visible = GetTree().Paused;
        GetTree().Paused = !GetTree().Paused;
        _uiContainers[ContainerType.Pause].Visible = GetTree().Paused;
    }

    private void HandleStartButtonPressed()
    {
        _canPause = true;
        GetTree().Paused = false;

        _uiContainers[ContainerType.Start].Visible = false;
        _uiContainers[ContainerType.Stats].Visible = true;

        GameEvents.RaiseStartGame();
    }

    private void HandleEndGame()
    {
        _canPause = false;
        
        _uiContainers[ContainerType.Stats].Visible = false;
        _uiContainers[ContainerType.Defeat].Visible = true;
    }

    private void HandleGameVictory()
    {
        _canPause = false;
        
        _uiContainers[ContainerType.Stats].Visible = false;
        _uiContainers[ContainerType.Victory].Visible = true;

        GetTree().Paused = true;
    }

    private void HandlePauseButtonPressed()
    {
        GetTree().Paused = false;

        _uiContainers[ContainerType.Pause].Visible = false;
        _uiContainers[ContainerType.Stats].Visible = true;
    }
}