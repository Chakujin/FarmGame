using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject OptionsCanvas;
    //
    public void OnOptions()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        OptionsCanvas.SetActive(true);
    }
}
