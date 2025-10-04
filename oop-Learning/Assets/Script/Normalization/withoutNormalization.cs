using UnityEngine;

public class withoutNormalization : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    void Update()
    {
        // Player tak ka direct vector
        Vector3 dir = player.position - transform.position;

        // Enemy ko move karo (lekin distance bhi include ho rahi hai)
        transform.position += dir * speed * Time.deltaTime;
    }
}
