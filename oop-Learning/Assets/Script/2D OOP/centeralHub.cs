using UnityEngine;

public class centeralHub : MonoBehaviour
{
    public static centeralHub Instance = null;

    //Input Controller
    public Vector2 MoveInput { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }
}
