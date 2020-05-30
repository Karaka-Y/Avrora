using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource FxAudioSource2;
    [SerializeField]
    private AudioClip[] FxAudioClips;
    public static AudioSource StaticFxAudioSource2;
    public static AudioClip[] StaticFxAudioClips;


    private void Start()
    {
        StaticFxAudioClips = FxAudioClips;
        StaticFxAudioSource2 = FxAudioSource2;
    }
}
