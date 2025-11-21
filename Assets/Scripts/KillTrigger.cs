using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        IKillable script = col.gameObject.GetComponent<IKillable>();

        if(script != null)
        {
            script.Kill();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
