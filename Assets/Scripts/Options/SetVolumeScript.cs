using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolumeScript : MonoBehaviour
{
    //Audio
    public Slider mainVolumeSlider;
    public AudioMixer audioMixer;

    //Sound Voids
    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);

        if (sliderValue == 0)
        {
            audioMixer.SetFloat("Master", -60);
        }
    }
}
