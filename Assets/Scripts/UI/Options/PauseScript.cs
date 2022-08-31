using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public delegate void onPauseCall();
    public static event onPauseCall onPauseCallBack;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPauseCallBack != null)
            {
                onPauseCallBack.Invoke();
            }
        }
    }
}
