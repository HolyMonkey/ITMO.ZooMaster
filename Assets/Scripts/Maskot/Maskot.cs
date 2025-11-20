using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class Maskot : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private AudioClip selectedClip;
    [SerializeField] private AudioClip badClip;
    [SerializeField] private AudioClip animalsMovedClip;
    [SerializeField] private string selectedTrigger = "bounce";
    [SerializeField] private string badTrigger = "munch";
    [SerializeField] private string movedTrigger = "spin";
    [SerializeField] private Net eventProvider;


    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (eventProvider)
        {
            eventProvider.Selected += OnAnimalsSelected;
            eventProvider.BadTry += OnBadMovement;
            eventProvider.AnimalsMoving += OnAnimalsMoved;
        }
        else
        {
            Debug.LogError("No event provider assigned!");
        }
    }

    private void OnDisable()
    {
        if (eventProvider)
        {
            eventProvider.Selected -= OnAnimalsSelected;
            eventProvider.BadTry -= OnBadMovement;
            eventProvider.AnimalsMoving -= OnAnimalsMoved;
        }
        else
        {
            Debug.LogError("No event provider assigned!");
        }
    }

    public void OnAnimalsSelected()
    {
        _animator.SetTrigger(selectedTrigger);
        _audioSource.PlayOneShot(selectedClip);
    }

    public void OnBadMovement()
    {
        _animator.SetTrigger(badTrigger);
        _audioSource.PlayOneShot(badClip);
    }

    public void OnAnimalsMoved()
    {
        _animator.SetTrigger(movedTrigger);
        _audioSource.PlayOneShot(animalsMovedClip);
    }
}