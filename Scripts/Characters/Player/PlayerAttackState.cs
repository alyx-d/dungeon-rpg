using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer _attackTimer;
    private int _comboCounter = 1;
    private int _maxComboCount = 2;
    private float _attackDistanceMultiplier = 0.75f;

    public override void _Ready()
    {
        base._Ready();

        _attackTimer.Timeout += HandleTimeout;
    }

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(
            GameConstants.AnimAttack + _comboCounter,
            -1,
            1.5f
        );

        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;

        _attackTimer.Start();
    }

    private void HandleAnimationFinished(StringName animName)
    {
        _comboCounter++;
        _comboCounter = Mathf.Wrap(_comboCounter, 1, _maxComboCount + 1);
        
        CharacterNode.ToggleHitBox(true);
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    private void HandleTimeout()
    {
        _comboCounter = 1;
    }

    private void PerformHit()
    {
        var newPosition = CharacterNode.Sprite3dNode.FlipH ? Vector3.Left : Vector3.Right;
        newPosition *= _attackDistanceMultiplier;
        CharacterNode.HitboxNode.Position = newPosition;
        
        CharacterNode.ToggleHitBox(false);
    }
}