using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Database/Item")]
public class Item : ScriptableObject
{
    public string ID;
    public string nombre;
    public int recuperacion;
    public string efecto;
    public string rango;
    public int valorCompra;
    public int valorVenta;
    [TextArea]
    public string descripcion;


}