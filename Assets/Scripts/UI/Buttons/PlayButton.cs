using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
