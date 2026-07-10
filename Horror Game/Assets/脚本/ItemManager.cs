using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [Header("???ß÷????ß“?")]
    public List<ItemData> allItems = new List<ItemData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // ????”Œ???????????????????????
            GameObject canvasObj = transform.parent.gameObject;
            canvasObj.transform.SetParent(null);

            // ???????????????????ß‘?????????
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvasObj);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ????????????
    public void CollectItem(string targetName)
    {
        foreach (var item in allItems)
        {
            if (item.itemName == targetName)
            {
                item.isCollected = true;
                // ????????UI
                ItemScrollUI.Instance.RefreshInventory();
                break;
            }
        }
    }
}