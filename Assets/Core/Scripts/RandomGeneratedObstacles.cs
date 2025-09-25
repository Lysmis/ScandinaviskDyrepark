using UnityEngine;
using System.Collections.Generic;

public class RandomGeneratedObstacles : MonoBehaviour
{
    #region Field
    //Obstacle GameObject
    [SerializeField, Tooltip("Obstacle/collectibel prefab")]
    public GameObject prefab;
    [SerializeField, Tooltip("Is it a collectibel")]
    public bool isCollectibel = false;
    [SerializeField, Tooltip("The obstacles is placed at the top of the screen")]
    public bool inTheAir = false;

    //Player GameObject
    [SerializeField, Tooltip("Player prefab seen in the hierarchy")]
    public GameObject player;
    private float playerPositionX;


    //Camera
    private Camera mainCamera;
    private float leftBound;
    private float topBound;

    //Sprite size for the obstacles
    private SpriteRenderer srObstacles;
    private float spriteHeight = 0f;

    //Ground coordinat Y
    [SerializeField, Tooltip("The ground coordinat on the Y axis")]
    public float groundYAxis;
    [SerializeField, Tooltip("The end coordinat of the X axis")]
    public float endOfMapXAxis;

    //List and stack for obstacles to use for object pool
    private List<GameObject> obstaclesList = new List<GameObject>();
    private Stack<GameObject> obstaclesStack = new Stack<GameObject>();

    //Timer for spawning the obstacles
    private float respawnTimer;
    [SerializeField, Tooltip("The time betwin spawning an obstacle")]
    public float spawnTimer;

    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Respawn timer is calculated by deltaTime
        respawnTimer = respawnTimer + Time.deltaTime;


        if (respawnTimer > spawnTimer)
        {
            int tileCase = Random.Range(0, 3);

            if (isCollectibel == false)
            {
                switch (tileCase)
                {
                    case 0: //Two tiles on top of each other
                        AddTiles(0);
                        AddTiles(1);
                        break;
                    case 1: //Hovering
                        AddTiles(1);
                        break;
                    default: //One tile
                        AddTiles(0);
                        break;
                }
            }
            else
            {
                switch (tileCase)
                {
                    case 0:
                        AddTiles(1);
                        break;
                    case 1:
                        AddTiles(2);
                        break;
                    default:
                        AddTiles(0);
                        break;
                }
            }

            //Resetting the respawnTimer
            respawnTimer = 0;
        }

        //Removing obstacles from the list and push to the stack when they are out of the frame
        playerPositionX = player.transform.position.x;

        for (int i = 0; i < obstaclesList.Count; i++)
        {
            GameObject go = obstaclesList[i];

            if (go.transform.position.x - (leftBound * 1.4f) < playerPositionX || playerPositionX > endOfMapXAxis * 0.95f)
            {
                obstaclesList.Remove(go);
                obstaclesStack.Push(go);

                go.SetActive(false);
            }
        }

    }


    private void Awake()
    {
        //Obstacle sprite size
        getSpriteSize(prefab);

        //Camera bounds
        CameraBounds();

    }

    /// <summary>
    /// Getting the GameObjects sprite size by getting it's sprite renderer
    /// </summary>
    /// <param name="go"></param>
    private void getSpriteSize(GameObject go)
    {
        //Getting go Sprite Rencerer
        srObstacles = go.GetComponent<SpriteRenderer>();

        //If go has a sprite renderer it will calculate the sprite size 
        if (srObstacles != null)
        {
            spriteHeight = srObstacles.bounds.size.y;
        }
    }

    /// <summary>
    /// Getting the camera bounds
    /// </summary>
    private void CameraBounds()
    {
        //Findung the camera scrren bounds
        mainCamera = Camera.main;

        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //The bound 
        leftBound = -screenBounds.x;
        topBound = screenBounds.y;

    }

    /// <summary>
    /// Adding a tile by object pool
    /// </summary>
    /// <param name="placeOn">The place the tile sits on where 0 on the surface</param>
    private void AddTiles(int placeOn)
    {
        Debug.Log(topBound);
        //Of setting the position so the obstacles sits on the ground
        Vector2 ofSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);


        //Spawn position 
        Vector2 spawnPosition = new Vector2(playerPositionX - (leftBound * 2), 0);
        //If the obstacles needs to stand on top of eachother
        if (inTheAir == true)
        {
            spawnPosition.y = topBound - groundYAxis - (spriteHeight / 2) - (spriteHeight * (placeOn + 1));
        }
        else
        {
            spawnPosition.y = spriteHeight * placeOn;
        }

        //New position where there taken into account the of set position
        Vector2 newPosition = spawnPosition + ofSetPosition;

        //The position is outside of the map it will chance the position to spawn at the beginning of the map 
        if (newPosition.x > endOfMapXAxis)
        {
            float tempPositionX = newPosition.x;

            newPosition.x = tempPositionX - endOfMapXAxis;
        }

        //The new obstacle
        GameObject newObstacle;

        if (obstaclesStack.Count > 0)
        {
            //Popping an obstacle from the stack
            newObstacle = obstaclesStack.Pop();
            newObstacle.transform.position = newPosition;
        }
        else
        {
            //Instantiating the new obstacles
            newObstacle = Instantiate(prefab, newPosition, Quaternion.identity);
        }

        newObstacle.SetActive(true);

        obstaclesList.Add(newObstacle);

    }

    

}
