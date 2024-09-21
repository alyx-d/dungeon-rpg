using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0,50,1")]
    private float _playerMoveSpeed = 5f;

    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction == Vector2.Zero)
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        }
        
        CharacterNode.Velocity = new Vector3(
            CharacterNode.Direction.X, 0, CharacterNode.Direction.Y
        );
        CharacterNode.Velocity *= _playerMoveSpeed;
        
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        CheckForAttackInput();
        
        if (Input.IsActionJustPressed(GameConstants.InputDash))
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
    }
}