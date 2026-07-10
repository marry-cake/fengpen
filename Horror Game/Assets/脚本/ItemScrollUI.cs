using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ItemScrollUI : MonoBehaviour
{
    public static ItemScrollUI Instance;
    [Header("ScrollView里的Content")]
    public Transform content;
    [Header("物品格子预制体")]
    public GameObject itemSlotPrefab;
    private List<GameObject> spawnedSlots = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        foreach (var slot in spawnedSlots) Destroy(slot);
        spawnedSlots.Clear();
        foreach (var item in ItemManager.Instance.allItems)
        {
            if (item.isCollected)
            {
                GameObject newSlot = Instantiate(itemSlotPrefab, content);
                Image iconImg = newSlot.transform.Find("Icon").GetComponent<Image>();
                iconImg.sprite = item.itemIcon;
                spawnedSlots.Add(newSlot);
            }
        }
    }
}