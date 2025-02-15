using UnityEngine;
using UnityEngine.UI;

namespace Hydra.Player
{
    public class Take : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Transform _holdPoint;
        [SerializeField] private float _takeRadius;
        [SerializeField] private Text _takeText;
        [SerializeField] private LayerMask _layerMask;
        public GameObject HoldingObject;

        private void Update()
        {
            if (AnyObjectsNear() != null)
            {
                _takeText.transform.gameObject.SetActive(true);
            }
            else
            {
                _takeText.transform.gameObject.SetActive(false);
            }
        }

        public void TakeObject(GameObject obj)
        {
            if (HoldingObject != null)
            {
                HoldingObject.GetComponent<ITakeable>().Drop(obj);
            }

            if (obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().isKinematic = true;
            }

            obj.transform.position = _holdPoint.position;
            obj.transform.parent = _holdPoint.parent;
        }

        private GameObject AnyObjectsNear()
        {
            Collider[] hittedColiders = Physics.OverlapSphere(_player.transform.position, _takeRadius, _layerMask);
            foreach (Collider colider in hittedColiders)
            {
                if (colider.gameObject.GetComponent<ITakeable>() != null)
                {
                    return colider.gameObject;
                }
            }
            return null;
        }
    }
}