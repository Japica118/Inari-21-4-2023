using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Assets/Database/Enemy")]
public class Enemy : ScriptableObject
{
    public string ID;
    public string nombre;
    public int Nivel;
    public string tipo;
    public string elemento;
    public string localización;
    public int experiencia;
    public int pA;
    public List<ItemDropeable> itemDropeable;
    public int monedas;
    public int vida;
    public int ataqueFisico;
    public int ataqueEspiritual;
    public int defensa;
    public int defensaEspiritual;
    public int velocidad;

}

