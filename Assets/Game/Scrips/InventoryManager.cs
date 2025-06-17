using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] protected GameObject slotHolder;
    [SerializeField] protected ItemClass ItemToAdd;
    [SerializeField] protected ItemClass ItemToRemove;
    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;
    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        Add(ItemToAdd);
        Remove(ItemToRemove);
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

        }
    }
    public void Add(ItemClass item)
    {
        items.Add(item);
        RefreshUI();
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
        RefreshUI();
    }
}
