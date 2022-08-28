using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject OptionsCanvas;
    private bool b_pressed = false;
    //
    public void OnOptions()
    {
        if(b_pressed == false)
        {
            OptionsCanvas.SetActive(true);
        }
        else
        {
            OptionsCanvas.SetActive(false);
        }
    }
}
