using UnityEngine;

//Singleton Define
namespace learning_data
{
    public class virualinputManager : MonoBehaviour
    {
        public static virualinputManager Instance = null;

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

        public bool MoveRight;
        public bool MoveLeft;
    }
}
