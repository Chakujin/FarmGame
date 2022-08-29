using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject OptionsCanvas;
    //
    public void OnOptions()
    {
        OptionsCanvas.SetActive(true);
    }
}
