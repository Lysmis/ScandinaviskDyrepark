using UnityEngine;

public class FlyingAnimalScript : AnimalBehaviour
{

    public float tiltAmount = 10f;   // how much tilt per unit of velocity
    public float smooth = 5f;
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

        // Convert velocity into a target rotation (around Z axis for 2D)
        float targetZRotation = rb.linearVelocityY * tiltAmount;

        // Smoothly rotate toward target
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

}
