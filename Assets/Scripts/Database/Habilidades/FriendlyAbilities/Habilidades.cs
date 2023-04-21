using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Assets/Database/Skill")]
public class Habilidades : ScriptableObject
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
    public bool overclock;
    [TextArea]
    public string description;
    public string ability;
    public int variance;
    public int statusEffect;

}
