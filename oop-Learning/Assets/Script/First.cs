using System.Collections.Generic;
using UnityEngine;

namespace learning_data
{
    public class First : MonoBehaviour
    {
        void Update()
        {
            if (virualinputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
                // Debug.Log("");
            }
            else if (virualinputManager.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(-Vector3.forward * 10f * Time.deltaTime);
            }
        }


    }
}
