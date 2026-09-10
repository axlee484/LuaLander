
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource sfxAudioSource;
    private AudioSource musicAudioSource;
    private void Awake()
    {
        Instance = this;
        
        var sfxNode = new GameObject("sfx");
        var musicNode = new GameObject("music");

        sfxAudioSource = sfxNode.AddComponent<AudioSource>();
        musicAudioSource = musicNode.AddComponent<AudioSource>();

        sfxNode.transform.SetParent(gameObject.transform);
        musicNode.transform.SetParent(gameObject.transform);

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
