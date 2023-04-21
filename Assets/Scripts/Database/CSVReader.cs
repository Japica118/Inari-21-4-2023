using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{

    public TextAsset textAssetData;

    [System.Serializable]
    public class Personaje
    {
        public string nombre;
        public int nivel;
        public string vinculo;
        public string arma;
        public int exp;
        public int pv;
        public int pe;
        public int ataque;
        public int ataqueEspiritual;
        public int defensa;
        public int defensaEspiritual;
        public int vel;
        public int eva;
    }

     [System.Serializable]
    public class PersonajeList{
        public Personaje[] personaje;
    }

    public PersonajeList myPersonajeList = new PersonajeList();

    // Start is called before the first frame update
    void Start()
    {
       
        ReadCSV();
        
    }

    void ReadCSV(){
        string[] data = textAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None);
        
        //13 = Columnas del excel:
        int tableSize = data.Length / 13 - 1; // Borramos la primera columna
        myPersonajeList.personaje = new Personaje[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myPersonajeList.personaje[i] = new Personaje();
            myPersonajeList.personaje[i].nombre = data[13 * (i + 1)];
            myPersonajeList.personaje[i].nivel = int.Parse(data[13 * (i + 1) + 1]);
            myPersonajeList.personaje[i].vinculo = data[13 * (i + 1) + 2];
            myPersonajeList.personaje[i].arma = data[13 * (i + 1) + 3];
            myPersonajeList.personaje[i].exp = int.Parse(data[13 * (i + 1) + 4]);
            myPersonajeList.personaje[i].pv = int.Parse(data[13 * (i + 1) + 5]);
            myPersonajeList.personaje[i].pe = int.Parse(data[13 * (i + 1) + 6]);
            myPersonajeList.personaje[i].ataque = int.Parse(data[13 * (i + 1) + 7]);
            myPersonajeList.personaje[i].ataqueEspiritual = int.Parse(data[13 * (i + 1) + 8]);
            myPersonajeList.personaje[i].defensa = int.Parse(data[13 * (i + 1) + 9]);
            myPersonajeList.personaje[i].defensaEspiritual = int.Parse(data[13 * (i + 1) + 10]);
            myPersonajeList.personaje[i].vel = int.Parse(data[13 * (i + 1) + 11]);
            myPersonajeList.personaje[i].eva = int.Parse(data[13 * (i + 1) + 12]);

        }

    }

}
