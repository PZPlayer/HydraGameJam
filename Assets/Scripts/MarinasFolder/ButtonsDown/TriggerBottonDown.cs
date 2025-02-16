using UnityEngine;

public class TriggerBottonDown : MonoBehaviour
{
    private bool isDropping = false;
    [SerializeField] private Material _pressed;
    [SerializeField] private Material _normal;
    [SerializeField] private MeshRenderer _changeColor;
    [SerializeField] private AudioClip _clip;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxActive") || other.CompareTag("Player"))
        {
            _source.PlayOneShot(_clip);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BoxActive") || other.CompareTag("Player"))
        {
            isDropping = true;
            _changeColor.material = _pressed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDropping = false;
            _source.PlayOneShot(_clip);
            _changeColor.material = _normal;
        }
    }
    public bool GetBoolBoxDown()
    {
        return isDropping;
    }
}
