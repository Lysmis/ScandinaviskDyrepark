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

    //Lister
    private List<GameObject> obstacles = new List<GameObject>();


    int kage = 0;
    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AddTiles();



        //Removing obstacles when they are out of the frame
        float playerPositionX = player.transform.position.x;

        foreach (GameObject obj in obstacles)
        {
            if (obj.transform.position.x + (leftBound * 2) < playerPositionX)
            {
                Destroy(obj);
            }
        }
    }

    private void Awake()
    {
        //go sprite size
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

    private void AddTiles()
    {
        if (kage < 1)
        {
            //Of setting the position so the obstacles sits on the ground
            Vector2 ofSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);

            //Spawn position 
            Vector2 spawnPosition = new Vector2(20,0);

            //New position where there taken into account the of set position
            Vector2 newPosition = spawnPosition + ofSetPosition;

            //Instantiating the new obstacles
            GameObject newObstacle = Instantiate(obstacle, newPosition, Quaternion.identity);

            obstacles.Add(newObstacle);

            kage++;

        }



    }

}
