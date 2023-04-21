using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyDatabase", menuName = "Assets/Database/EnemyDatabase")]
public class EnemyDatabase : ScriptableObject
{
    public List<Enemy> allEnemies;
}
