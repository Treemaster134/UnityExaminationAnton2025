using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicManScript : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        text.gameObject.SetActive(true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        text.gameObject.SetActive(false);
    }
}
