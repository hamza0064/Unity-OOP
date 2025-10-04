using UnityEngine;

public class withNormalization : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    void Update()
    {
        // Player tak ka direct vector
        Vector3 dir = player.position - transform.position;

        // Normalize kar do ? sirf direction bacha, length = 1
        dir.Normalize();
        Debug.Log(dir);
        // Ab speed constant hai
        transform.position += dir * speed * Time.deltaTime;
    }
}
