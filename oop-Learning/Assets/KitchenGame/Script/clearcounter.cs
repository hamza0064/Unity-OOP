using UnityEngine;

public class clearcounter : MonoBehaviour
{
    [SerializeField] private kitchenObjectSO KitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;
    [SerializeField] private clearcounter secondClearCounter;
    [SerializeField] private bool testing;

    private kitchenObject KitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (KitchenObject != null)
            {
                KitchenObject.setClearCounter(secondClearCounter);
                // Debug.Log(KitchenObject.getClearCounter());
            }
        }

    }
    public void Interact()
    {
        if (KitchenObject == null)
        {
            // Debug.Log("Interaction");
            // Debug.Log("Player interacted with the counter: " + gameObject.name);
            Transform kitchenObjectTransform = Instantiate(KitchenObjectSO.prefabs, CounterTopPoint);
            kitchenObjectTransform.GetComponent<kitchenObject>().setClearCounter(this);
            // kitchenObjectTransform.localPosition = Vector3.zero;
            // Debug.Log(kitchenObjectTransform.GetComponent<kitchenObject>().GetKitchenObjectSO().objectName);
            // KitchenObject = kitchenObjectTransform.GetComponent<kitchenObject>();
            // KitchenObject.setClearCounter(this);
        }
        else
        {
            Debug.Log(KitchenObject.getClearCounter());
        }



    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return CounterTopPoint;
    }


    public void SetKitchenObject(kitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }

    public kitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }

    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return KitchenObject != null; 
    }
    
}
