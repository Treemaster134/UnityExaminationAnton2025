using UnityEngine;

public class MoodChanger : MonoBehaviour
{
    private int mood = 0;
    [SerializeField] private int moodCount;
    [SerializeField] private Color[] colors;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        mood = 0;
        
        SetMood();
    }
    
    public void NextMood()
    {
        mood = (mood + 1) % moodCount;

        SetMood();
    }

    private void SetMood()
    {
        audioSource.clip = clips[mood];
        audioSource.Play();
        cam.backgroundColor = colors[mood];
    }
}
