using UnityEngine;

public class eventlisner : MonoBehaviour
{
    public eventplayer player; 

    private void Start()
    {
       
        player.OnInteractAction += HandlePlayerInteraction;
    }

   
    private void HandlePlayerInteraction(object sender, System.EventArgs e)
    {
        Debug.Log("Player ne interact kiya!");
    }
}
