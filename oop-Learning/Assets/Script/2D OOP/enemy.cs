using UnityEngine;

public class enemy : character_Class
{


    public Transform target;

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (target == null) return;
        speed = 2f;
        Vector3 dir = (target.position - transform.position).normalized;
        dir.y = 0;
        //Debug.Log(dir);
        transform.position += dir * speed * Time.deltaTime;

    }
}
