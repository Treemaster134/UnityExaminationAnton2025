using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicManScript : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject[] dialogGameObjects;
    private bool touchingPlayer = false;
    private int dialogIndex = 0;
    private bool pressedInteract = false;
    private void Update()
    {
        if (touchingPlayer && pressedInteract)
        {
            dialogGameObjects[dialogIndex].SetActive(true);
            dialogGameObjects[dialogIndex].GetComponent<Dialog>().StartDialog();

            if (dialogIndex < (dialogGameObjects.Length - 1))
            {
                dialogIndex++;
            }
            
            text.gameObject.SetActive(false);
            touchingPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        text.gameObject.SetActive(true);
        touchingPlayer = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        text.gameObject.SetActive(false);
        touchingPlayer = false;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started) pressedInteract = true;
        if(context.canceled) pressedInteract = false;
    }
}
