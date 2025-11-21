using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicManScript : MonoBehaviour
{
    private InputAction interactAction;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject[] dialogGameObjects;
    private bool touchingPlayer = false;
    private int dialogIndex = 0;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (touchingPlayer && interactAction.IsPressed())
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
}
