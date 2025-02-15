using UnityEngine;


namespace Hydra.UI
{
    public class DeathManager : MonoBehaviour
    {
        public static DeathManager Instance;
        public int SceneLastDeath;

        void Start ()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}


