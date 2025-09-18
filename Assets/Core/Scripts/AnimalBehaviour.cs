using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimalBehaviour : MonoBehaviour
{
    #region Field
    //The jumping heigth - is public so it can bechanged in Unity
    public float jumpHeigth = 5f;

    //Moving speed
    public float movingSpeed = 5f;

    //Player loop around the background
    public bool loopBackground = false;

    //End of background if the Player needs to respawn at the start position again
    public float backgroundEndX = 5f;

    //Input System Asset
    public InputActionAsset inputActions;

    //Animal rigidbody
    protected Rigidbody2D rb;

    //Animal animator
    protected Animator animator;

    //Jump values
    private InputAction jumpInput;

    //Bool to tjek if the Player is jumping
    private bool isJumping = false;

    //The Player can dobbel jump, to make sure it is max 2 times
    protected int dobbelJump = 0;

    //Player needs to be with in the camera wiewpoint
    private Camera mainCamera;
    private float topBound;

    //Player sprite heigth
    private float playerHeight;

    //Player start position
    private Vector2 startPos;

    //The HUDManager object, that shows the HUD in the HUD scene. 
    public HUDManager hud;

    //The time lift before the gme stops
    [SerializeField, Tooltip("The default time remaining when the player starts a level")]
    protected float timeRemaining = 60;

    //A counter to use ofr things happening every second
    protected float secondsCounter = 0;

    //The number of items picked up by the player in the current level
    [SerializeField, Tooltip("The default starting number of items picked up")]
    protected int pickUps;

    //Bool to show wether a HUDManager has ben sucesfully added/defined
    private bool hudAdded = false;
    #endregion


    #region Properties

    #endregion

    #region Method
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!hudAdded)
        {
            AddHUD();
        }

        secondsCounter += Time.deltaTime;
        if (secondsCounter > 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= 1;
                if (hud != null)
                {
                    hud.SetTime(timeRemaining);
                }
            }
            else
            {
                //Quiz method should be called here
            }
            secondsCounter = 0;
        }
    }

    protected virtual void Awake()
    {
        //Rigidbody
        rb = GetComponent<Rigidbody2D>();

        //Animator
        animator = GetComponent<Animator>();

        //Start position
        startPos = rb.position;

        //Jumping input under the action "Player/Jump"
        //Tap on touch screen and "Space" on keyboard
        jumpInput = inputActions.FindActionMap("Player").FindAction("Jump");

        CameraBounds();
    }

    protected virtual void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();

        //Jump action
        jumpInput.Enable();

        //Staring jump
        jumpInput.performed += ctx => isJumping = true;

    }

    protected virtual void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();

        //Ending jump
        jumpInput.performed -= ctx => isJumping = false;

        jumpInput.Disable();
    }

    private void Jumping()
    {
        //The Rigidbodys velocity
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);

        //Transitions to "Jumping" animation
        animator.SetTrigger("Jump");
        animator.SetBool("canJump", false);

        //Adding force to make the jump
        rb.AddForce(Vector2.up * jumpHeigth, ForceMode2D.Impulse);

    }

    protected virtual void FixedUpdate()
    {

        //Tells animator if animal is moving up or down
        animator.SetFloat("velocityY", rb.linearVelocityY);

        //The player can only jump if the isJumping is true and haven't jet dobbeljumped
        if (isJumping == true && dobbelJump < 2)
        {
            Jumping();

            //Resetting isJumping to false
            isJumping = false;

            //Adding a jump to dobbelJump
            dobbelJump++;
        }

        //The players temporary position
        Vector2 pos = rb.position;

        //The player can't move out of the top of the screen
        //The players position-Y is rigth under the top of the screen (minus the player heigth) it will limets the position-Y
        if (rb.position.y > (topBound - playerHeight))
        {
            pos.y = topBound - playerHeight;
            rb.position = new Vector2(pos.x, pos.y);
        }

        //Moving horizontal with fixed speed
        Vector2 movePos = Vector2.right * movingSpeed * Time.fixedDeltaTime;

        //To respawn back to start position 
        if (rb.position.x > backgroundEndX && loopBackground == true)
        {
            pos.x = startPos.x;
        }

        //Players new position 
        rb.position = pos + movePos;
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Resetting to 0 so the player can start dobbel jumping again
        dobbelJump = 0;
        //Enables jumping animation precondition
        animator.SetBool("canJump", true);
        animator.ResetTrigger("Jump");

    }

    /// <summary>
    /// Getting the screenBounds and SpriteRenderer size
    /// </summary>
    private void CameraBounds()
    {
        //Findung the camera scrren bounds
        mainCamera = Camera.main;

        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //The top bound 
        topBound = screenBounds.y;

        //Getting the player heigth with the SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            playerHeight = sr.bounds.extents.y;
        }
    }

    #endregion

    /// <summary>
    /// Tries to find a gameobject from the hierarchy with the HUD tag, and set the Animals hud field to the GameObject's HUDManager component. 
    /// </summary>
    private void AddHUD()
    {
        if (!hudAdded)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("HUD");
            if (gameObject != null)
            {
                hud = gameObject.GetComponent<HUDManager>();
                if (hud != null)
                {
                    hudAdded = true;
                }
            }
        }
    }

    /// <summary>
    /// Method to load Quiz
    /// </summary>
    /// <returns>Quiz Scene loaded additive</returns>
    public IEnumerator LoadQuiz()
    {

        yield return SceneManager.LoadSceneAsync("QuizScene", LoadSceneMode.Additive);

    }


}

