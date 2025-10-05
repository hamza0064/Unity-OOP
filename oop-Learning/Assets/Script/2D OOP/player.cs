using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class player : character_Class
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public override void Move()
    {
        Vector2 dir = centeralHub.Instance.MoveInput;
        Vector3 moveDir = new Vector3(dir.x, 0, dir.y);
        transform.position += moveDir * speed * Time.deltaTime;


        float rotSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);
    }

}
