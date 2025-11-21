using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        SetRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            SetRandom();
        }
    }

    private void SetRandom()
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }
}
