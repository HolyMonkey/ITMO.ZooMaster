using UnityEngine;

public class DonkeyController : MonoBehaviour
{
    Animator anim;
    Net net;
    Aviaries aviaries;

    static readonly int selectedHash = Animator.StringToHash("lookRight");
    static readonly int spinHash = Animator.StringToHash("spin");
    static readonly int badHash = Animator.StringToHash("fear");

    void Awake()
    {
        anim = GetComponent<Animator>();
        net = FindFirstObjectByType<Net>();
        aviaries = FindFirstObjectByType<Aviaries>();
    }
    void OnEnable()
    {
        net.Selected += OnAnimalsSelected;

        aviaries.GoodAction += OnGoodAction;
        aviaries.BadAction += OnBadAction;

    }

    void OnDisable()
    {
        net.Selected -= OnAnimalsSelected;

        aviaries.GoodAction -= OnGoodAction;
        aviaries.BadAction -= OnBadAction;
    }

    void OnAnimalsSelected()
    {
        anim.SetTrigger(selectedHash);
    }

    void OnGoodAction()
    {
        anim.SetTrigger(spinHash);
    }

    void OnBadAction()
    {
        anim.SetTrigger(badHash);
    }

}