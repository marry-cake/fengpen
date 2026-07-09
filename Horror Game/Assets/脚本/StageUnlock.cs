using UnityEngine;
using UnityEngine.UI;

public class StageUnlock : MonoBehaviour
{
    [Header("需要解锁的第二按钮secbtn")]
    public Button nextBtn;
    private UISwitch switchComp;

    void Awake()
    {
        switchComp = GetComponent<UISwitch>();
    }
    public void UnlockNextButton()
    {
        nextBtn.interactable = true;
    }
}