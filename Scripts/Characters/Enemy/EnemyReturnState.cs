using DungeonRpg.Scripts.General;

namespace DungeonRpg.Scripts.Characters.Enemy;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        Destination = GetPointGlobalPosition(0);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.NavigationAgent3DNode.IsNavigationFinished())
        {
            CharacterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
            return;
        }

        Move();
    }

    protected override void EnterState()
    {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.NavigationAgent3DNode.TargetPosition = Destination;

        CharacterNode.ChaseArea3dNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        CharacterNode.ChaseArea3dNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
}