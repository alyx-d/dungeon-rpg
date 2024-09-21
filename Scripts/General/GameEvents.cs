using System;

namespace DungeonRpg.General;

public abstract class GameEvents
{
    public static event Action OnStartGame;
    public static void RaiseStartGame() => OnStartGame?.Invoke();
}