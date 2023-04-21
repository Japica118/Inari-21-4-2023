using UnityEngine;

[CreateAssetMenu(fileName = "New Equipable", menuName = "Assets/Database/Equipable")]
public class Equipable : ScriptableObject
{
    public string ID;
    public string nombre;
    public string type;
    public string efecto;
    public int valorCompra;
    public int valorVenta;
    [TextArea]
    public string descripcion;


}