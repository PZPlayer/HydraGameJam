using Hydra.UI;
using UnityEngine;

namespace Hydra.Player
{
    public enum Sound
    {
        Walk = 0,
        ChangePlayer = 1,
        Jump = 2
    }

    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _walk;
        [SerializeField] private AudioClip _changePlayers;
        [SerializeField] private AudioClip _jump;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(Sound sound)
        {
            if(Settings.Setting.MainVolume != 0)
            {
                audioSource.volume = Random.Range(0.1f, Settings.Setting.MainVolume);
            }
            else
            {
                audioSource.volume = 0;
            }
            switch (sound)
            {
                case Sound.Walk:
                    audioSource.clip = _walk;
                    if(!audioSource.isPlaying) audioSource.Play();
                    break;
                case Sound.ChangePlayer:
                    audioSource.PlayOneShot(_changePlayers);
                    break;
                case Sound.Jump: 
                    audioSource.PlayOneShot(_jump);
                    break;
                default:
                    Debug.LogError("Error: No sound found");
                    break;
            }
        }
    }
}
