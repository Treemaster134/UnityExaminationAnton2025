using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;


    // Update is called once per frame
    void LateUpdate()
    {
        if(playerTransform != null)
        {
            transform.position = Vector3.Slerp(transform.position, playerTransform.position + offset, speed * Time.deltaTime);
        }
    }
}
