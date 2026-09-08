using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfx(AudioClip clip, float volume = 1f)
    {
        sfxAudioSource.PlayOneShot(clip, volume);
    }
    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.Play();
    }
    
}
