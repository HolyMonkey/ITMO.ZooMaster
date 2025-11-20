using UnityEngine;

public class Corgi : MonoBehaviour
{
    [SerializeField] Net netPrefab;
    [SerializeField] Animator animator;

    void Start()
    {
        if (netPrefab)
        {
            netPrefab.Selected += OnSelected;
            netPrefab.Deselected += OnDeselected;
            netPrefab.AnimalsMoving += OnAnimalsMoving;
            netPrefab.BadTry += OnBadTry;
        }

        if (!animator)
            animator = GetComponent<Animator>();
    }

    void OnDisable()
    {
        if (netPrefab)
        {
            netPrefab.Selected -= OnSelected;
            netPrefab.Deselected -= OnDeselected;
            netPrefab.AnimalsMoving -= OnAnimalsMoving;
            netPrefab.BadTry -= OnBadTry;
        }
    }

    void OnSelected()
    {
        Debug.Log("Selected");
        animator.SetTrigger("bounce");
    }

    void OnDeselected()
    {
        Debug.Log("Deselected");
        animator.SetTrigger("spin");
    }

    void OnAnimalsMoving()
    {
        Debug.Log("Animals Moving");
        animator.SetTrigger("jump");
    }

    void OnBadTry()
    {
        Debug.Log("Bad try");
        animator.SetTrigger("fear");
    }
}
