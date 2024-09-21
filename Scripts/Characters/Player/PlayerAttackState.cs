using DungeonRpg.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerAttackState : PlayerState
{
    private int _comboCounter = 1;
    private int _maxComboCount = 2;

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack + _comboCounter);

        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        _comboCounter++;
        _comboCounter = Mathf.Wrap(_comboCounter, 1, _maxComboCount + 1);
        
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}