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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float v)
    {
        //Explanation: https://discussions.unity.com/t/changing-audio-mixer-group-volume-with-ui-slider/567394/12
        //convert the linear value of the slider to a logarithmic one for the mixer 
        mixer.SetFloat("Volume", Mathf.Log(v) * 20);

    }

    public void EnterScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
