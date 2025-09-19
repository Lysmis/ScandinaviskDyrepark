using UnityEngine;

public class FlyingAnimalScript : AnimalBehaviour
{

    [SerializeField, Tooltip("How much tilt per unit of upwards velocity, default = 10")] private float tiltAmount = 10f;
    [SerializeField, Tooltip("Smoothing effect on tilt, default = 5")] private float smooth = 5f;
    [SerializeField, Tooltip("Animation speed while increasing altitude, default = 1")] private float fullAnimationSpeed = 1f;
    [SerializeField, Tooltip("Animation speed while decreasing altitude, default = 0.25, set equal to Full Animation Speed to disable")] private float slowedAnimationSpeed = 0.25f;
    [SerializeField, Tooltip("Upwards velocity at which to decrease animation speed, default = 0")] private float decreaseAnimationThreshold = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();

        //Set dobbelJump to always 0
        dobbelJump = 0;

        if (rb != null)
        {

            if (animator != null)
                animator.speed = rb.linearVelocityY > decreaseAnimationThreshold ? fullAnimationSpeed : slowedAnimationSpeed;

            // Convert velocity into a target rotation (around Z axis for 2D)
            float targetZRotation = rb.linearVelocityY * tiltAmount;

            // Smoothly rotate toward target
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);

        }

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

}
