using UnityEngine;

[CreateAssetMenu(fileName = "New EnemySkill", menuName = "Assets/Database/EnemySkill")]
public class enemyAbility : ScriptableObject
{
    public string ID;
    public string name;
    public string element;
    public int baseDamage;
    public int costSpiritual;
    public int pA;
    public string status;
    public string target;
    public string type;
    [TextArea]
    public string description;
    public string ability;

}
