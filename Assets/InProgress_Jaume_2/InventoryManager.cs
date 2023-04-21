using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxHealthPotions = 10;
    public int maxManaPotions = 10;

    private int currentHealthPotions = 0;
    private int currentManaPotions = 0;

    void Start()
    {

    }
    
    public void AddHealthPotion()
    {
        if (currentHealthPotions < maxHealthPotions)
        {
            currentHealthPotions++;
            Debug.Log("Health potion added to inventory");
        }
        else
        {
            Debug.Log("Inventory full: cannot add health potion");
        }
    }

    public void AddManaPotion()
    {
        if (currentManaPotions < maxManaPotions)
        {
            currentManaPotions++;
            Debug.Log("Mana potion added to inventory");
        }
        else
        {
            Debug.Log("Inventory full: cannot add mana potion");
        }
    }

    public int GetCurrentHealthPotions()
    {
        return currentHealthPotions;
    }

    public int GetCurrentManaPotions()
    {
        return currentManaPotions;
    }
}