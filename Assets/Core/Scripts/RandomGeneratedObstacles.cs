using UnityEngine;
using System.Collections.Generic;

public class RandomGeneratedObstacles : MonoBehaviour
{
    #region Field
    //Obstacle GameObject
    public GameObject obstacle;

    //Player GameObject
    public GameObject player;
    public bool isPlayerFlying = false;

    //Camera
    private Camera mainCamera;
    private float leftBound;
    private float topBound;

    //Sprite size
    private SpriteRenderer srObstacles;
    private float spriteHeight = 0f;
    private float spriteWidth = 0f;

    //Ground coordinat Y
    public float groundYAxis;
    //public float endOfMapXAxis; // I dont think so

    //List and stack for obstacles
    private List<GameObject> obstaclesList = new List<GameObject>();
    private Stack<GameObject> obstaclesStack = new Stack<GameObject>();

    private float respawnTimer1 = 10f;
    private float respawnTimer2 = 10f;

    private float playerPositionX = 0f;

    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer1 = respawnTimer1 + Time.deltaTime;
        respawnTimer2 = respawnTimer2 + Time.deltaTime;


        //Removing obstacles when they are out of the frame
        playerPositionX = player.transform.position.x;

        if (respawnTimer1 > 3f)
        {
            AddTiles(0);
            AddTiles(1);

            respawnTimer1 = 0f;
        }
        //else if (respawnTimer2 > 2f )
        //{
        //    AddTiles(0);

        //    respawnTimer2 = 0f;
        //}

        for (int i = 0; i < obstaclesList.Count; i++)
        {
            GameObject go = obstaclesList[i];

            if (go.transform.position.x - (leftBound) < playerPositionX)
            {
                obstaclesList.Remove(go);
                obstaclesStack.Push(go);
            }
        }

    }


    private void Awake()
    {
        //Obstacle sprite size
        getSpriteSize(obstacle);

        CameraBounds();
    }

    private void getSpriteSize(GameObject go)
    {
        //Getting go Sprite Rencerer
        srObstacles = go.GetComponent<SpriteRenderer>();

        //If go has a sprite renderer it will calculate the sprite size 
        if (srObstacles != null)
        {
            spriteHeight = srObstacles.bounds.size.y;
            spriteWidth = srObstacles.bounds.size.x;
        }

    }

    private void CameraBounds()
    {
        //Findung the camera scrren bounds
        mainCamera = Camera.main;

        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //The bound 
        leftBound = -screenBounds.x;
        topBound = screenBounds.y;
    }

    private void AddTiles(int onTop)
    {
        //Of setting the position so the obstacles sits on the ground
        Vector2 ofSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);


        //Spawn position 
        Vector2 spawnPosition = new Vector2(playerPositionX - (leftBound * 2), 0);
        //If the obstacles needs to stand on top of eachother
        if (isPlayerFlying == true)
        {
            spawnPosition.y = topBound - groundYAxis - (spriteHeight * 3 / 2);
        }
        else
        {
            spawnPosition.y = spriteHeight * onTop;
        }

        //New position where there taken into account the of set position
        Vector2 newPosition = spawnPosition + ofSetPosition;

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
            newObstacle = Instantiate(obstacle, newPosition, Quaternion.identity);
        }

        obstaclesList.Add(newObstacle);

    }

}
