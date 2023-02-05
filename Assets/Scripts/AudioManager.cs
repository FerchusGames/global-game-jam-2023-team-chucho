using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioClip human;
    [SerializeField] private AudioClip monkey;
    [SerializeField] private AudioClip bgmusic;
    [SerializeField] private AudioClip inlevelmusic;
    [SerializeField] private AudioClip congratulations;
    [SerializeField] private AudioClip move;
    [SerializeField] private AudioClip winlevel;
    [SerializeField] private AudioClip grabspear;
    [SerializeField] private AudioClip grabchip;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void PlayBackgroundMusic(AudioClip levelMusic)
    {
        audioSourceMusic.PlayOneShot(levelMusic);
    }

    public void BackgroundMusic()
    {
        PlayBackgroundMusic(bgmusic);
    }
    public void PlayHumanSound(AudioClip Humanclip)
    {
        audioSourceSFX.PlayOneShot(Humanclip);
    }

    public void HumanJump()
    {
        PlayHumanSound(human);
    }
    public void PlayMonkeySound(AudioClip monkeyClip)
    {
        audioSourceSFX.PlayOneShot(monkeyClip);
    }

    public void MonkeyJump()
    {
        PlayMonkeySound(monkey);
    }

    public void PlayMoveSound(AudioClip moveClip)
    {
        audioSourceSFX.PlayOneShot(moveClip);
    }

    public void MoveSound()
    {
        PlayMoveSound(move);
    }

    public void PlayInLevelMusic(AudioClip inlevelclip)
    {
        audioSourceMusic.PlayOneShot(inlevelclip);
    }

    public void InlevelMusic()
    {
        PlayInLevelMusic(inlevelmusic);
    }

    public void PlayWinGameSong(AudioClip WinGameclip)
    {
        audioSourceMusic.PlayOneShot(WinGameclip);
    }

    public void WinGameSong()
    {
        PlayWinGameSong(congratulations);
    }

    public void PlayWinLevelSound(AudioClip WinLevelClip)
    {
        audioSourceSFX.PlayOneShot(WinLevelClip);
    }

    public void WinLevelSound()
    {
        PlayWinLevelSound(winlevel);
    }

    public void PlayGrabSpearSound(AudioClip grabSpearClip)
    {
        audioSourceSFX.PlayOneShot(grabSpearClip);
    }

    public void GrabSpearSound()
    {
        PlayGrabSpearSound(grabspear);
    }

    public void PlayGrabChipSound(AudioClip grabChipClip)
    {
        audioSourceSFX.PlayOneShot(grabChipClip);
    }

    public void GrabChipSound()
    {
        PlayGrabChipSound(grabchip);
    }
}
