using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager insance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        insance = this;
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
