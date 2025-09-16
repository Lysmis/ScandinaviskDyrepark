using UnityEngine;

public class FlyingAnimalScript : AnimalBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set dobbelJump to always 0
        dobbelJump = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
