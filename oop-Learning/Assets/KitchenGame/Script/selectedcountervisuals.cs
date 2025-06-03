using kitchen_Project;
using UnityEngine;

public class selectedcountervisuals : MonoBehaviour
{

    [SerializeField] private clearcounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
