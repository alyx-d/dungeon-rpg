using DungeonRpg.Scripts.Resources;
using Godot;

namespace DungeonRpg.Scripts.Characters;

public partial class AttackHitbox : Area3D
{
    public float GetDamage()
    {
        return GetOwner<Character>().GetStatResource(Stat.Strength).StatValue;
    }
}