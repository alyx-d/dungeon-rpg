using DungeonRpg.Scripts.Interfaces;
using Godot;

namespace DungeonRpg.Scripts.Abilities;

public partial class AbilityHitbox : Area3D, IHitbox
{
    public float GetDamage() => GetOwner<Ability>().Damage;
}