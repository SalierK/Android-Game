using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
    public void Start()
    {
         mixer.GetFloat("volume",out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
