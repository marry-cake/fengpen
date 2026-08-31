using UnityEngine;

public class AllGameGlobal : MonoBehaviour
{
    public static AllGameGlobal Global;
    public bool lockUnlocked = false;

    void Awake()
    {
        if (Global == null)
        {
            Global = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLock()
    {
        PlayerPrefs.SetInt("DrawerLockState", lockUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }

    void Start()
    {
        lockUnlocked = PlayerPrefs.GetInt("DrawerLockState", 0) == 1;
    }
}