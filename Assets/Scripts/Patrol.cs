using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float speed;
    private Vector3 target;
    bool reachedEnd = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reachedEnd = false;
        target = endPosition;
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == target)
        {
            if(!reachedEnd)
            {
                target = startPosition;
                reachedEnd = true;
            }
            else
            {
                target = endPosition;
                reachedEnd = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
