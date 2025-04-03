using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isOn = false;
    [SerializeField] private Animator animator;


    public void Interact()
    {
        Debug.Log("aaaaaaaaaaaaaaaaa");
        if (!isOn)
        {
            On();
            isOn = true;
        }

        if (isOn)
        {
            Off();
            isOn = false;
        }
    }

    private void On()
    {
        animator.SetTrigger("HasBeenInteracted");

    }

    private void Off()
    {
        animator.SetTrigger("HasBeenInteracted");
    }
}
