using System.Collections.Generic;
using UnityEngine;

public class AnimalDataScript : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private AnimalAnimations animations;
    private AnimatorOverrideController overrideController;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animator = GetComponent<Animator>();

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        overrideController["Running"] = animations.Running;
        overrideController["Jumping"] = animations.Jumping;
        overrideController["Flying"] = animations.Flying;
        overrideController["Falling"] = animations.Falling;
        overrideController["Landing"] = animations.Landing;

    }

    void OnValidate()
    {

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (animations.Sprite != null && spriteRenderer != null)
            spriteRenderer.sprite = animations.Sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
