using System.Collections;
using UnityEngine;

namespace Hydra.Potions
{
    [RequireComponent(typeof(Rigidbody))]

    public class PotionBase : MonoBehaviour, ITakeable, IThrowable
    {
        [SerializeField] private GameObject _potion;
        [SerializeField] private float speed;

        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (_potion == null)
            {
                _potion = transform.gameObject;
            }
        }

        public virtual void Throw(Vector3 direction)
        {
            transform.parent = null;
            StartCoroutine(FlyToDestination(direction));
        }

        public IEnumerator FlyToDestination(Vector3 destination)
        {
            while (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return null; 
            }
        }

        public virtual void Take(Transform transform)
        {
            rb.isKinematic = true;
            _potion.transform.position = transform.position;
            _potion.transform.parent = transform;
        }

        public virtual void Drop()
        {
            Destroy(_potion);
        }
    }
}