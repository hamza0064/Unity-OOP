using UnityEngine;

public class gamemanager : MonoBehaviour
{
    PlayerController player = new PlayerController();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        // player.Movement();
        // player.rb
    }

    // Update is called once per frame
    void Update()
    {
        player.Movement();
    }
}
