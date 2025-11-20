using UnityEngine;
using System.Collections.Generic;


enum ANIM_STATE{
    IDLE = 1
};

enum SOUND_STAT
{
    PADDOCK_OPEN = 0,
    ANIMALS_RUN = 1,
    SAD = 2
};

[RequireComponent(typeof(AudioSource))]
public class PlayerWolf : MonoBehaviour
{
    [SerializeField] private Net _net;

    private AudioSource audioSource;

    [Header("Настройки звука")]
    [SerializeField] private List<AudioClip> soundClip;
    [SerializeField][Range(0f, 1f)] private float volume = 1f;

    private Animator animator;

    [Header("Настройки анимации")]
 //   [SerializeField] private string animationTriggerName = "Play";
    [SerializeField] private AnimationClip barkClip;
    [SerializeField] private AnimationClip happyClip;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioSource.playOnAwake = false;
        audioSource.clip = soundClip[0];
        audioSource.volume = volume;

        _net.Selected += PlayPaddockOpenSound;
        _net.Selected += PlayBarkAnim;
        _net.AnimalsMoving += PlayAnimalsRunSound;
        _net.AnimalsMoving += PlayBarkAnim;
        _net.BadTry += BadClickSound;
        _net.BadTry += PlayBarkAnim;
    }

    void PlayBarkAnim()
    {
        PlayAnim(barkClip);
    }

    void PlayGoodAttempAnim()
    {
        PlayAnim(happyClip);
    }

    void PlayPaddockOpenSound()
    {
        PlaySound(0);
    }

    void PlayAnimalsRunSound()
    {
        PlaySound(1);
    }

    void BadClickSound()
    {
        PlaySound(2);
    }

    void PlaySound(int stat)
    {
        if (soundClip[stat] != null)
        {
            audioSource.PlayOneShot(soundClip[stat], volume);
        }
        else
        {
            Debug.LogWarning("AudioClip не назначен в инспекторе!");
        }
    }

    void PlayAnim(AnimationClip clip)
    {
        animator.CrossFade(clip.name, 2.0f);
    }

//    void PlayAnim(ANIM_STATE state)
   // {
      //  if (animator != null && !string.IsNullOrEmpty(animationTriggerName))
      //  {
     //       animator.SetTrigger(animationTriggerName);
    //    }
     //   else
     //   {
      //      Debug.LogWarning("Animator не найден или не задано имя триггера!");
     //   }
   // }

    void Destroy()
    {
        _net.Selected += PlayPaddockOpenSound;
        _net.AnimalsMoving += PlayAnimalsRunSound;
        _net.BadTry += BadClickSound;
    }
}
