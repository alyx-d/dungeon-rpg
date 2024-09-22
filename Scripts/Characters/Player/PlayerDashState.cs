using DungeonRpg.Scripts.General;
using Godot;

namespace DungeonRpg.Scripts.Characters.Player;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer _durationTimerNode;
    [Export] private Timer _cooldownTimerNode;

    [Export(PropertyHint.Range, "0,20,0.1")]
    private float _dashSpeed = 10f;

    [Export] private PackedScene _bombScene;

    public override void _Ready()
    {
        base._Ready();
        _durationTimerNode.Timeout += HandleDurationTimeout;
        CanTransition = () => _cooldownTimerNode.IsStopped();
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
        _durationTimerNode.Start();

        var bomb = _bombScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(bomb);
        bomb.GlobalPosition = CharacterNode.GlobalPosition;
    }

    private void HandleDurationTimeout()
    {
        _cooldownTimerNode.Start();
        
        CharacterNode.Velocity = Vector3.Zero;
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}