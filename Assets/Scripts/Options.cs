using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            print(PlayerPrefs.GetFloat("Volume"));
            SetVolume(PlayerPrefs.GetFloat("Volume"));
        }
    }

    public void SetVolume(float v)
    {
        //Explanation: https://discussions.unity.com/t/changing-audio-mixer-group-volume-with-ui-slider/567394/12
        //convert the linear value of the slider to a logarithmic one for the mixer 
        mixer.SetFloat("Volume", Mathf.Log(v) * 20);
        PlayerPrefs.SetFloat("Volume", v);
    }

    public void EnterScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
