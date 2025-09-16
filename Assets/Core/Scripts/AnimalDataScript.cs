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

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        overrideController["Running"] = animations.Running;
        overrideController["Jumping"] = animations.Jumping;
        overrideController["Flying"] = animations.Flying;
        overrideController["Falling"] = animations.Falling;
        overrideController["Landing"] = animations.Landing;

    }

    /// <summary>
    /// Updates sprite from scriptable object
    /// </summary>
    void OnValidate()
    {

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
