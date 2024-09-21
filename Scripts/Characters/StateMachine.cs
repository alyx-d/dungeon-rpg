using System.Linq;
using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters;

public partial class StateMachine : Node
{
    [Export] private Node _currentState;
    [Export] private Node[] _states;

    public override void _Ready()
    {
        _currentState.Notification(GameConstants.SignalEnterState);
    }

    public void SwitchState<T>()
    {
        var newState = _states.FirstOrDefault(state => state is T);
        if (newState == null)
        {
            GD.PrintErr($"Could find this state {typeof(T)}");
            return;
        }

        if (_currentState is T)
        {
            return;
        }

        _currentState.Notification(GameConstants.SignalExitState);
        _currentState = newState;
        _currentState.Notification(GameConstants.SignalEnterState);
    }
}