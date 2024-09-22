namespace DungeonRpg.Scripts.General;

public abstract class GameConstants
{
    // Animation
    public const string AnimIdle = "Idle";
    public const string AnimMove = "Move";
    public const string AnimDash = "Dash";
    public const string AnimAttack = "Attack";
    public const string AnimDeath = "Death";
    public const string AnimStun = "Stun";

    public const string AnimExpand = "Expand";
    public const string AnimExplosion = "Explosion";
    
    // Input
    public const string InputLeft = "MoveLeft";
    public const string InputRight = "MoveRight";
    public const string InputForward = "MoveForward";
    public const string InputBackward = "MoveBackward";
    
    public const string InputDash = "Dash";
    public const string InputAttack = "Attack";
    
    public const string InputPause = "Pause";
    public const string InputInteract = "Interact";
    
    //Signal
    public const int SignalEnterState = 5001;
    public const int SignalExitState = 5002;
}