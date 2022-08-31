using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitPress()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
