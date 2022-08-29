using UnityEngine;

public class MainMenuBack : MonoBehaviour
{
    public GameObject OptionsCanvas;

    // Start is called before the first frame update
    public void BackPress()
    {
        OptionsCanvas.SetActive(false);
    }   
}
