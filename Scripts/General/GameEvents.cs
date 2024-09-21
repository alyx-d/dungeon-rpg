using System;

namespace DungeonRpg.Scripts.General;

public abstract class GameEvents
{
    public static event Action OnStartGame;
    public static event Action OnEndGame;
    public static void RaiseStartGame() => OnStartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
}