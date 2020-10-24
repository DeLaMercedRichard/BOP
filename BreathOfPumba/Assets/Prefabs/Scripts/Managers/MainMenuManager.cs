using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HoverOnPlay(bool isHovering)
    {
        animator.SetBool("HoveringOverPlay", isHovering);
    }

    public void HoverOnControls(bool isHovering)
    {
        animator.SetBool("HoveringOverControls", isHovering);
    }

    public void HoverOnCredits(bool isHovering)
    {
        animator.SetBool("HoveringOverCredits", isHovering);
    }

    public void HoverOnExit(bool isHovering)
    {
        animator.SetBool("HoveringOverExit", isHovering);
    }
}
