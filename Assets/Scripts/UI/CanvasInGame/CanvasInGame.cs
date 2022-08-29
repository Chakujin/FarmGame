using UnityEngine;

public class CanvasInGame : MonoBehaviour
{
    public GameObject _ingameCanvas;
    [SerializeField]private bool _paused = false;

    private void OnEnable()
    {
        PauseScript.onPauseCallBack += IsPaused;
    }

    private void OnDisable()
    {
        PauseScript.onPauseCallBack -= IsPaused;
    }

    private void IsPaused()
    {
        if(_paused == false)
        {
            _paused = true;
            _ingameCanvas.SetActive(true);
        }
        else
        {
            _paused = false;
            _ingameCanvas.SetActive(false);
        }
    }
}
