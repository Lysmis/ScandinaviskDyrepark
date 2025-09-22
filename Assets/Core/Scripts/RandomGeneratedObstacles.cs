using UnityEngine;
using System.Collections.Generic;

public class RandomGeneratedObstacles : MonoBehaviour
{
    #region Field
    //Obstacle GameObject
    public GameObject obstacle;

    //Player GameObject
    public GameObject player;

    //Camera
    private Camera mainCamera;
    private float leftBound;

    //Sprite size
    private SpriteRenderer srObstacles;
    private float spriteHeight = 0f;
    private float spriteWidth = 0f;

    //Ground coordinat Y
    public float groundYAxis;
    public float endOfMapXAxis; // I dont think so

    //Lister
    private List<GameObject> obstacles = new List<GameObject>();

    private float respawnTimer = 10f;
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

            foreach (GameObject obj in obstacles)
            {
                if (obj.transform.position.x + (leftBound) < playerPositionX)
                {
                    Destroy(obj);

                }
            }
        }




        //for (int i = 0; i < obstacles.Count; i++)
        //{
        //    Debug.Log(leftBound);
        //}
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

        //The top bound 
        leftBound = screenBounds.x;

    }

    private void AddTiles(int prutfims)
    {
        //Of setting the position so the obstacles sits on the ground
        Vector2 ofSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);


        Vector2 spawnPosition = new Vector2(leftBound + playerPositionX, 0);
        //Spawn position 
        if(prutfims == 1)
            {
            spawnPosition.y = spriteHeight;
        }

        //New position where there taken into account the of set position
        Vector2 newPosition = spawnPosition + ofSetPosition;

        //Instantiating the new obstacles
        GameObject newObstacle = Instantiate(obstacle, newPosition, Quaternion.identity);

        obstacles.Add(newObstacle);
    }

}
