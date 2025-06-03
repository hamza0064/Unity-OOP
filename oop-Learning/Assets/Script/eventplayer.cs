using UnityEngine;
using System;
public class eventplayer : MonoBehaviour
{
    // Event define کیا
    public event EventHandler OnInteractAction;

    private void Update()
    {
        // جب "E" دبے تو interaction perform کرو
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact_performed();
        }
    }

    private void Interact_performed()
    {
        // اگر کوئی اس event کو listen کر رہا ہو تو اسے notify کرو
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
}
