using UnityEngine;

[CreateAssetMenu(fileName = "New Drop Item", menuName = "Assets/Database/DropItem")]
public class ItemDropeable : ScriptableObject
{
    public Item item;
    public int probabilidad;

}