using UnityEngine;

public class TriggerLever : MonoBehaviour
{
    private bool enter = false;
    private bool isActiv = false;

    [SerializeField] private GameObject _activatedTrigger, _oldTrigger;
    [SerializeField] private KeyCode buttonName;
    [SerializeField] private AudioClip _sound;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (enter && Input.GetKeyDown(buttonName))
        {
            isActiv = !isActiv;
            _source.PlayOneShot(_sound);
            _activatedTrigger.SetActive(true);
            _oldTrigger.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
    public bool GetBoolLever()
    {
        return isActiv;
    }
}
