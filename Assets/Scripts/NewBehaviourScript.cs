using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Net _net;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip selected;
    [SerializeField] private AudioClip badClip;
    [SerializeField] private AudioClip goodClip;
    [SerializeField] private string selectedTrigger = "bounce";
    [SerializeField] private string badTrigger = "munch";
    [SerializeField] private string goodTrigger = "spin";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        if (_net)
        {
            _net.BadClick += OnBadClick;
            _net.AnimalsMoving += OnAnimalsMoving;
            _net.Selected += OnSelected;
        }

        if (!_animator)
        {
            Debug.LogError("_animator is nullref");
        }

    }
    private void OnDisable()
    {
        _net.BadClick -= OnBadClick;
        _net.AnimalsMoving -= OnAnimalsMoving;
        _net.Selected -= OnSelected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSelected()
    {
        _animator.SetTrigger(selectedTrigger);
    }
    private void OnBadClick() 
    {
        _animator.SetTrigger(badTrigger);
    }
    private void OnAnimalsMoving()
    {
        _animator.SetTrigger(goodTrigger);
    }
}
