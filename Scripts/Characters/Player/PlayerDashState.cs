using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer _dashTimer;

    [Export(PropertyHint.Range, "0,20,0.1")]
    private float _dashSpeed = 10f;

    public override void _Ready()
    {
        base._Ready();
        _dashTimer.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }


    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimDash);
        CharacterNode.Velocity = new Vector3(
            CharacterNode.Direction.X,
            0,
            CharacterNode.Direction.Y
        );
        if (CharacterNode.Velocity == Vector3.Zero)
        {
            CharacterNode.Velocity = CharacterNode.Sprite3dNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        CharacterNode.Velocity *= _dashSpeed;
        _dashTimer.Start();
    }

    private void HandleDashTimeout()
    {
        CharacterNode.Velocity = Vector3.Zero;
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}