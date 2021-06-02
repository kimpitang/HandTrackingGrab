using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }

    void BuildDatabase()
    {
        items = new List<Item>
        {
            new Item(0, "Key", "you can go next stage.", 1),
            new Item(1, "Stage 1 Badge", "you finished Stage 1", 1)
        };

    }
}