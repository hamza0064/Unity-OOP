using UnityEngine;

public abstract class character_Class : MonoBehaviour
{
    
    public float speed = 5f;

    public abstract void Move();
    public abstract void Attack();
}
