﻿using System;
using DungeonRpg.Scripts.Resources;

namespace DungeonRpg.Scripts.General;

public abstract class GameEvents
{
    public static event Action OnStartGame;
    public static event Action OnEndGame;
    public static event Action<int> OnNewEnemyCount;
    public static event Action OnGameVictory;
    public static event Action<RewardResource> OnReward;
    public static void RaiseStartGame() => OnStartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
    public static void RaiseNewEnemyCount(int count) => OnNewEnemyCount?.Invoke(count);
    public static void RaiseGameVictory() => OnGameVictory?.Invoke();
    public static void RaiseReward(RewardResource reward) => OnReward?.Invoke(reward);
}