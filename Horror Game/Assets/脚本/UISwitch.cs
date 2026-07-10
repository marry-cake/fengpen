using UnityEngine;
using UnityEngine.UI;

public class UISwitch : MonoBehaviour
{
    public GameObject CloseImg;
    public GameObject OpenImg;

    private bool alreadySwitch = false;
    private Button btnSelf;

    void Awake()
    {
        btnSelf = GetComponent<Button>();
    }

    public void ChangeImage()
    {
        if (alreadySwitch) return;

        CloseImg.SetActive(false);
        OpenImg.SetActive(true);
        alreadySwitch = true;
        btnSelf.interactable = false;
    }
}