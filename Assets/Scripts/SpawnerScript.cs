using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private float timer = 0.0f;
    [SerializeField] private GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        timer = 5.0f;
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
