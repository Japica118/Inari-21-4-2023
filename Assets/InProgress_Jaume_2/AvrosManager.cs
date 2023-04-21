using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvrosManager : MonoBehaviour
{
    public int avros;

    [SerializeField] private Text avrosText;

    private void Start()
    {
        UpdateUI();
    }

    public void AddAvrosFromChest(int amount)
    {
        avros += amount;
        UpdateUI();
        Debug.Log("Avros added: " + amount);
    }

    public void SubtractAvros(int amount)
    {
        avros -= amount;
        UpdateUI();
        Debug.Log("Avros subtracted: " + amount);
    }

    public int GetAvros()
    {
        return avros;
    }

    private void UpdateUI()
    {
        avrosText.text = "Avros: " + avros.ToString();
    }
}