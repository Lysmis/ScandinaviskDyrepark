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
        jumpInput.performed += ctx => Jumping();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();

        jumpInput.Disable();

        //Ending jump
        jumpInput.performed -= ctx => Jumping();
    }

    private void Jumping()
    {
        Debug.Log("Hi");

        Vector2 moveJump = transform.up * jumpHeigth * Time.deltaTime;

        //Jump to new position
        rb.MovePosition(rb.position + moveJump);
    }

    //private void FixedUpdate()
    //{
    //    Jumping();
    //}
}
