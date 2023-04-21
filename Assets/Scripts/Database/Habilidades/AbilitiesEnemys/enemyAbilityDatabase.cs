using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbilityEnemyDatabase", menuName = "Assets/Database/AbilityEnemyDatabase")]
public class enemyAbilityDatabase : ScriptableObject
{
    public List<enemyAbility> allEnemyAbilities;
}
