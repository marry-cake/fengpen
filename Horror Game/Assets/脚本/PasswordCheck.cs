using UnityEngine;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{
    public PasswordDial dial1;
    public PasswordDial dial2;
    public PasswordDial dial3;
    public PasswordDial dial4;

    public int pass1 = 1;
    public int pass2 = 2;
    public int pass3 = 3;
    public int pass4 = 4;

    public Text tipText;
    public CabinetInteract cabinet;

    public void CheckPassword()
    {
        int n1 = dial1.GetCurrentNum();
        int n2 = dial2.GetCurrentNum();
        int n3 = dial3.GetCurrentNum();
        int n4 = dial4.GetCurrentNum();

        if (n1 == pass1 && n2 == pass2 && n3 == pass3 && n4 == pass4)
        {
            tipText.text = "Ω‚À¯≥…π¶£°";
            cabinet.UnlockDrawer();
        }
        else
        {
            tipText.text = "√‹¬Î¥ÌŒÛ";
        }
        Invoke(nameof(ClearTip), 1.5f);
    }

    void ClearTip()
    {
        tipText.text = "";
    }
}