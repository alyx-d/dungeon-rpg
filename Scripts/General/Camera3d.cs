using Godot;

namespace DungeonRpg.Scripts.General;

public partial class Camera3d : Camera3D
{
    [Export] private Node _targetNode;
    [Export] private Vector3 _positionFromTarget;

    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.OnEndGame += HandleEndGame;
    }

    private void HandleStartGame()
    {
        Reparent(_targetNode);
        Position = _positionFromTarget;
    }

    private void HandleEndGame()
    {
        Reparent(GetTree().CurrentScene);
    }
}