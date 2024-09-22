using System;
using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters;

public abstract partial class CharacterState : Node
{
    protected Character CharacterNode;
    public Func<bool> CanTransition = () => true;

    public override void _Ready()
    {
        CharacterNode = GetOwner<Character>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        switch (what)
        {
            case GameConstants.SignalEnterState:
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;
            case GameConstants.SignalExitState:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                ExitState();
                break;
        }
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void ExitState()
    {
    }
}