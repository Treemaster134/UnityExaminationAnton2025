using UnityEngine;
using UnityEngine.Events;

public class VictoryZone : MonoBehaviour
{
    public UnityEvent GameWon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameWon?.Invoke();
    }
}
