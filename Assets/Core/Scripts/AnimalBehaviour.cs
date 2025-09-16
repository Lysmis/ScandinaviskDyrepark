using UnityEngine;
using UnityEngine.InputSystem;

public class AnimalBehaviour : MonoBehaviour
{
    #region Field
    //The jumping heigth - is public so it can bechanged in Unity
    public float jumpHeigth = 5f;

    //Input System Asset
    public InputActionAsset inputActions;

    //Animal rigidbody
    private Rigidbody2D rb;

    //Jump values
    private InputAction jumpInput;

    //Bool to tjek if the Player is jumping
    private bool isJumping = false;

    //The Player can dobbel jump, to make sure it is max 2 times
    protected int dobbelJump = 0;
    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        //Rigidbody
        rb = GetComponent<Rigidbody2D>();

        //Jumping input under the action "Player/Jump"
        //Tap on touch screen and "Space" on keyboard
        jumpInput = inputActions.FindActionMap("Player").FindAction("Jump");

    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();

        //Jump action
        jumpInput.Enable();

        //Staring jump
        jumpInput.performed += ctx => isJumping = true;
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();

        jumpInput.Disable();

        //Ending jump
        jumpInput.performed -= ctx => isJumping = false;
    }

    private void Jumping()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);

        rb.AddForce(Vector2.up * jumpHeigth, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (isJumping == true && dobbelJump < 2)
        {
            Jumping();

            isJumping = false;

            dobbelJump++;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resetting to 0 so the player can start dobbel jumping again
        dobbelJump = 0;
    }
}

