using UnityEngine;


namespace Hydra.Player
{

    public enum TypeOfPlayer
    {
        Human = 0,
        Vampire
    }

    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Movement _otherPlayer;
        [SerializeField] private float _speed, _jumpForce;
        [SerializeField] private GameObject _feet;
        [SerializeField] private GameObject _cameraPoint;
        [SerializeField] private LayerMask _standLayers;
        [SerializeField] private TypeOfPlayer _playerType;

        public TypeOfPlayer _selectedType;

        private Rigidbody rb;
        private Vector3 trajectory;

        void Start ()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();

            if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
               Jump();
            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                _otherPlayer.enabled = true;
                _cameraPoint.transform.position = _otherPlayer.transform.position;
                _cameraPoint.transform.parent = _otherPlayer.transform;
                transform.GetComponent<Movement>().enabled = false;
            }
            
        }

        void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            trajectory = new Vector3(horizontal, 0, vertical).normalized;
            transform.position += trajectory * Time.deltaTime * _speed;
        }

        private bool isGrounded()
        {
            return Physics.CheckSphere(_feet.transform.position, 0.1f, _standLayers);
        }

        void Jump()
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}