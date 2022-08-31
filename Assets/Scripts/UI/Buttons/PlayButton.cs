using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlay()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("MainLevel");
    }
}
