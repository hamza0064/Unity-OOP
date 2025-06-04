using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class kitchenObject : MonoBehaviour
{
    [SerializeField] private kitchenObjectSO KitchenObjectSO;

    private clearcounter Clearcounter;

    public kitchenObjectSO GetKitchenObjectSO()
    {
        return KitchenObjectSO;
    }

    public void setClearCounter(clearcounter clearcounter)
    {
        if (this.Clearcounter != null)
        {
            this.Clearcounter.ClearKitchenObject();
        }

        this.Clearcounter = clearcounter;

        if (clearcounter.HasKitchenObject())
        {
            Debug.LogError("Already object hy yha");
        }

        clearcounter.SetKitchenObject(this); 


        transform.parent = clearcounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public clearcounter getClearCounter()
    {
        return Clearcounter;
    }
}
