using UnityEngine;


namespace Hydra.Player
{
    public interface IThrowable
    {
        void Throw(Vector3 direction);
    }

    public interface ITakeable
    {
        void Take(GameObject item);
        void Drop(GameObject item);
    }


    public enum TypeOfPlayer
    {
        Human = 0,
        Vampire
    }

    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Movement _otherPlayer;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private GameObject _feet;
        [SerializeField] private GameObject _model;
        [SerializeField] private GameObject _cameraPoint;
        [SerializeField] private LayerMask _standLayers;
        [SerializeField] private TypeOfPlayer _playerType;

        public TypeOfPlayer SelectedType { get; private set; }

        private Rigidbody rb;
        private PotionChoose potionChoose;
        private Vector3 trajectory;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            potionChoose = GetComponent<PotionChoose>();
        }

        private void Update()
        {
            HandleMovementInput();
            HandleJumpInput();
            HandleSwitchPlayerInput();
        }

        private void HandleMovementInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            trajectory = new Vector3(horizontal, 0, vertical).normalized;

            if (trajectory.magnitude > 0)
            {
                MoveCharacter(trajectory);
                RotatePlayer();
            }
        }

        void RotatePlayer()
        {
            Quaternion targetRotation = Quaternion.LookRotation(trajectory);

            float targetYRotation = targetRotation.eulerAngles.y;

            Quaternion finalRotation = Quaternion.Euler(0, targetYRotation, 0);

            _model.transform.rotation = Quaternion.Slerp(_model.transform.rotation, finalRotation, 3 * Time.deltaTime);
        }

        private void MoveCharacter(Vector3 direction)
        {
            rb.MovePosition(rb.position + direction * _speed * Time.deltaTime);
        }

        private void HandleJumpInput()
        {
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(_feet.transform.position, 0.1f, _standLayers);
        }

        private void Jump()
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void HandleSwitchPlayerInput()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            _otherPlayer.enabled = true;

            PotionChoose otherPotionChoose = _otherPlayer.GetComponent<PotionChoose>();
            if (otherPotionChoose != null)
            {
                otherPotionChoose.enabled = true;
            }

            _cameraPoint.transform.position = _otherPlayer.transform.position;
            _cameraPoint.transform.parent = _otherPlayer.transform;


            enabled = false;
            if (potionChoose != null)
            {
                potionChoose.enabled = false;
            }
        }

        public void HandleTake(GameObject item)
        {
            ITakeable takeable = item.GetComponent<ITakeable>();
            if (takeable != null)
            {
                takeable.Take(gameObject);
            }
        }

        public void HandleDrop(GameObject item)
        {
            ITakeable takeable = item.GetComponent<ITakeable>();
            if (takeable != null)
            {
                takeable.Drop(item);
            }
        }
    }
}