using UnityEngine;
using UnityEngine.SceneManagement;

public class ShredPuzzleManager : MonoBehaviour
{
    public UIPuzzleShredPiece[] allPieces;

    public void CheckFinish()
    {
        foreach (var p in allPieces)
        {
            if (!p.IsCorrect())
                return;
        }
        Debug.Log("ËºËéÕÕÆ¬Æ´Í¼Íê³É£¬Ìø×ªb1");
        SceneManager.LoadScene("b1");
    }
}