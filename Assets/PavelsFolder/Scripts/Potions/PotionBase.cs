using Hydra.Player;
using UnityEngine;

namespace Hydra.Potions
{
    [RequireComponent(typeof(Rigidbody))]
    public class PotionBase : MonoBehaviour, ITakeable, IThrowable
    {
        [SerializeField] private GameObject _potion;
        [SerializeField][Range(0.1f, 100f)] private float speed = 10f;

        [SerializeField] private Rigidbody rb;

        private void Awake()
        {
           // rb = GetComponent<Rigidbody>();

            if (_potion == null)
            {
                _potion = gameObject; 
            }
        }

        public virtual void Throw(Vector3 direction)
        {
            transform.parent = null;
            rb.isKinematic = false;

            Debug.DrawRay(transform.position, direction.normalized * 5, Color.red, 2.0f);
            
            direction -= transform.position;
            rb.AddForce(direction.normalized * speed, ForceMode.VelocityChange);
        }

        public virtual void Take(GameObject newParent)
        {
            rb.isKinematic = true; 
            _potion.transform.position = newParent.transform.position;
            _potion.transform.parent = newParent.transform; 
        }

        public virtual void OnCollisionEnter(Collision other)
        {
            CastEffect();
        }

        public virtual void CastEffect()
        {
            Destroy(gameObject);
        }

        public virtual void Drop(GameObject item)
        {
            if (_potion != null)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}