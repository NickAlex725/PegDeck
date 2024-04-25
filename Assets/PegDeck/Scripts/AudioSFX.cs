using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSFX : MonoBehaviour
{
    public static AudioSFX Instance;

    [Header("Audio Settings")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float sfxVolume;

    [Header("Card SFX")]
    [SerializeField] private AudioClip cDrawCard;
    [SerializeField] private AudioClip cPlayCard;
    [SerializeField] private AudioClip cDiscardCard;

    [Header("Ball SFX")]
    [SerializeField] private AudioClip cBallLaunch;
    [SerializeField] private AudioClip cBallDeath;
    [SerializeField] private AudioClip cBallBounce;

    [Header("Peg SFX")]
    [SerializeField] private AudioClip cPegHit;

    [Header("Player Enemy SFX")]
    [SerializeField] private AudioClip cEnemyHit;
    [SerializeField] private AudioClip cPlayerHit;

    [Header("Misc SFX")]
    [SerializeField] private AudioClip cButtonPress;
    [SerializeField] private AudioClip cEnterCardState;
    [SerializeField] private AudioClip cEnterEnemyState;
    [SerializeField] private AudioClip cEnterPeggleState;

    private AudioSource audioSource;

    private void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
        #endregion

        audioSource = GetComponent<AudioSource>();
        
        if(audioSource != null) audioSource.volume = sfxVolume;
    }
    private void Start()
    {
        PlaySoundEffect(SFXType.PlayCard);
    }
    public void PlaySoundEffect(SFXType sfx)
    {
        if(audioSource == null)
        {
            Debug.LogError("No audio source.");
            return;
        }

        AudioClip useClip = cDrawCard;

        switch(sfx)
        {
            case SFXType.DrawCard:
                //
                useClip = cDrawCard;
                break;
            case SFXType.PlayCard:
                //
                useClip = cPlayCard;
                break;
            case SFXType.DiscardCard:
                //
                useClip = cDiscardCard;
                break;
            case SFXType.BallLaunch:
                //
                useClip = cBallLaunch;
                break;
            case SFXType.BallDeath:
                //
                useClip = cBallDeath;
                break;
            case SFXType.BallBounce:
                //
                useClip = cBallBounce;
                break;
            case SFXType.PegHit:
                //
                useClip = cPegHit;
                break;
            case SFXType.EnemyHit:
                //
                useClip = cEnemyHit;
                break;
            case SFXType.PlayerHit:
                //
                useClip = cPlayerHit;
                break;
            case SFXType.ButtonPress:
                //
                useClip = cButtonPress;
                break;
            case SFXType.EnterCardState:
                //
                useClip = cEnterCardState;
                break;
            case SFXType.EnterEnemyState:
                //
                useClip = cEnterEnemyState;
                break;
            case SFXType.EnterPeggleState:
                //
                useClip = cEnterPeggleState;
                break;
        }

        audioSource.PlayOneShot(useClip, sfxVolume);
    }
    public void PlaySoundEffect(SFXType sfx, float volume)
    {
        if (audioSource == null)
        {
            Debug.LogError("No audio source.");
            return;
        }

        AudioClip useClip = cDrawCard;

        switch (sfx)
        {
            case SFXType.DrawCard:
                //
                useClip = cDrawCard;
                break;
            case SFXType.PlayCard:
                //
                useClip = cPlayCard;
                break;
            case SFXType.DiscardCard:
                //
                useClip = cDiscardCard;
                break;
            case SFXType.BallLaunch:
                //
                useClip = cBallLaunch;
                break;
            case SFXType.BallDeath:
                //
                useClip = cBallDeath;
                break;
            case SFXType.BallBounce:
                //
                useClip = cBallBounce;
                break;
            case SFXType.PegHit:
                //
                useClip = cPegHit;
                break;
            case SFXType.EnemyHit:
                //
                useClip = cEnemyHit;
                break;
            case SFXType.PlayerHit:
                //
                useClip = cPlayerHit;
                break;
            case SFXType.ButtonPress:
                //
                useClip = cButtonPress;
                break;
            case SFXType.EnterCardState:
                //
                useClip = cEnterCardState;
                break;
            case SFXType.EnterEnemyState:
                //
                useClip = cEnterEnemyState;
                break;
            case SFXType.EnterPeggleState:
                //
                useClip = cEnterPeggleState;
                break;
        }

        if(volume < 0.0) volume = 0.0f;
        if (volume > 1.0) volume = 1.0f;

        audioSource.PlayOneShot(useClip, volume);
    }
}

public enum SFXType { DrawCard, PlayCard, DiscardCard, BallLaunch, BallDeath, BallBounce, PegHit, EnemyHit, PlayerHit, ButtonPress, EnterCardState, EnterEnemyState, EnterPeggleState}
