using UnityEngine;

public class AnimalDataScript : MonoBehaviour
{

    private Animator animator;
    [SerializeField, Tooltip("Object containing standard sprite and animations")] private AnimalAnimations animations;
    private AnimatorOverrideController overrideController;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    /// <summary>
    /// Overrides standard animations with those from scriptable object
    /// </summary>
    void Start()
    {

        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (animations == null)
            return;
        else if (animator != null)
        {

            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController;

        }

        if (overrideController != null)
        {
            if (animations.Running != null && animations.Running != null)
                overrideController["Running"] = animations.Running;
            if (animations.Jumping != null && animations.Jumping != null)
                overrideController["Jumping"] = animations.Jumping;
            if (animations.Flying != null && animations.Flying != null)
                overrideController["Flying"] = animations.Flying;
            if (animations.Falling != null && animations.Falling != null)
                overrideController["Falling"] = animations.Falling;
            if (animations.Landing != null && animations.Landing != null)
                overrideController["Landing"] = animations.Landing;
        }

    }

    /// <summary>
    /// Updates sprite from scriptable object
    /// </summary>
    void OnValidate()
    {

        if (animations == null)
            return;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (animations.Sprite != null && spriteRenderer != null)
            spriteRenderer.sprite = animations.Sprite;

        if (boxCollider != null && animations.Sprite != null)
        {

            boxCollider.size = animations.Sprite.bounds.size;
            boxCollider.offset = animations.Sprite.bounds.center;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
