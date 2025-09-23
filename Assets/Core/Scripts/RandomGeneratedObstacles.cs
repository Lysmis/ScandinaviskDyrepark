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
    public float endOfMapXAxis;

    //List and stack for obstacles
    private List<GameObject> obstaclesList = new List<GameObject>();
    private Stack<GameObject> obstaclesStack = new Stack<GameObject>();

    private float respawnTimer = 10f;
    private bool kage = true;

    private float playerPositionX = 0f;

    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer = respawnTimer + Time.deltaTime;


        //Removing obstacles when they are out of the frame
        playerPositionX = player.transform.position.x;

        if (respawnTimer > 3f)
        {
            AddTiles(0);
            AddTiles(1);

            respawnTimer = 0f;
            kage = true;
        }
        else if (respawnTimer > 2.5f && kage == true)
        {
            AddTiles(0);
            kage = false;
        }

        for (int i = 0; i < obstaclesList.Count; i++)
        {
            GameObject go = obstaclesList[i];

            if (go.transform.position.x - (leftBound) < playerPositionX || go.transform.position.x > endOfMapXAxis)
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
        Debug.Log(topBound);
        //Of setting the position so the obstacles sits on the ground
        Vector2 ofSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);


        //Spawn position 
        Vector2 spawnPosition = new Vector2(playerPositionX - (leftBound * 2), 0);
        //If the obstacles needs to stand on top of eachother
        if (isPlayerFlying == true)
        {
            spawnPosition.y = topBound - groundYAxis - (spriteHeight / 2) -(spriteHeight * (onTop + 1));
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
