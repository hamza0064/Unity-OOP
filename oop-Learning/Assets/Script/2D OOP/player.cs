using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class player : character_Class
{
    public Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
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
        float currentSpeed = moveDir.magnitude;
        if (anim != null)
        {
            // “Speed” float parameter in Animator (0 = idle, 1 = running)
            
            anim.SetFloat("Run", currentSpeed);
        }

        foreach (Transform child in transform)
        {
            if (currentSpeed <= 0.01f)
                child.localRotation = Quaternion.Euler(0f, 45f, 0f);   // Idle
            else
                child.localRotation = Quaternion.Euler(0f, 20f, 0f);   // Run
        }
    }

}
