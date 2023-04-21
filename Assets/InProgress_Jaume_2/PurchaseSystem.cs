using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseSystem : MonoBehaviour
{
    public int healthPotionPrice = 10;
    public int manaPotionPrice = 10;

    private AvrosManager avrosManager;
    public InventoryManager inventoryManager;

    void Start()
    {
        avrosManager = FindObjectOfType<AvrosManager>();
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void BuyHealthPotion()
    {
        if (avrosManager.GetAvros() >= healthPotionPrice)
        {
            avrosManager.SubtractAvros(healthPotionPrice);
            inventoryManager.AddHealthPotion();
            Debug.Log("Health potion purchased!");
        }
        else
        {
            Debug.Log("Not enough Avros to buy health potion!");
        }
    }

    public void BuyManaPotion()
    {
        if (avrosManager.GetAvros() >= manaPotionPrice)
        {
            avrosManager.SubtractAvros(manaPotionPrice);
            inventoryManager.AddManaPotion();
            Debug.Log("Mana potion purchased!");
        }
        else
        {
            Debug.Log("Not enough Avros to buy mana potion!");
        }
    }
}
