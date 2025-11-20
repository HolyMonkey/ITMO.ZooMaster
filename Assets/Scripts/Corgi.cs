using UnityEngine;
using static CW.Common.CwInputManager;

public class Corgi : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] Net _net;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        _net.Selected += AnimalsSelected;
        _net.AnimalsMoving += GoodClick;
        _net.BadTry += BadTry;
    }

    private void BadTry()
    {
        _animator.SetTrigger("fear");
    }

    private void GoodClick()
    {
        _animator.SetTrigger("spin");
    }

    private void AnimalsSelected()
    {
        _animator.SetTrigger("bounce");
    }

    private void OnDisable()
    {
        _net.Selected -= AnimalsSelected;
        _net.GoodClick -= GoodClick;
        _net.BadClick -= BadTry;
    }
}