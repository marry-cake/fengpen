using UnityEngine;
public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public bool lockUnlocked = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 跨场景保留本体，状态不重置
            lockUnlocked = PlayerPrefs.GetInt("LockUnlocked", 0) == 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLockState()
    {
        PlayerPrefs.SetInt("LockUnlocked", lockUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }
}