using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayerScene"); // Change to your actual single player scene name
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerScene"); // Change to your actual multiplayer scene name
    }
}
