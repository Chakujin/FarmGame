using UnityEngine;

public class FullScreenScript : MonoBehaviour
{
    [SerializeField]private Animator _Anim;
    // Start is called before the first frame update
    void Start()
    {
        _Anim = GetComponent<Animator>();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        //FindObjectOfType<AudioSource>().Play();
        Screen.fullScreen = isFullscreen;
        _Anim.SetBool("Press", isFullscreen);
    }
}
