using UnityEngine;
using System.Collections.Generic;

public class RandomGeneratedObstacles : MonoBehaviour
{
    #region Field
    //Obstacle GameObject
    public GameObject go;

    //Sprite size
    private SpriteRenderer srGO;
    private float spriteHeight = 0f;
    private float spriteWidth = 0f;

    //Ground coordinat Y
    public float groundYAxis;

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
    }

    private void Awake()
    {
        //go sprite size
        getSpriteSize(go);
    }

    private void getSpriteSize(GameObject go)
    {
        //Getting go Sprite Rencerer
        srGO = go.GetComponent<SpriteRenderer>();

        //If go has a sprite renderer it will calculate the sprite size 
        if (srGO != null)
        {
            spriteHeight = srGO.bounds.size.y;
            spriteWidth = srGO.bounds.size.x;
        }

    }

    private void AddTiles()
    {
        if (kage < 1)
        {
            Vector2 offSetPosition = new Vector2(0, groundYAxis) + new Vector2(0, spriteHeight / 2);

            Vector2 newPosition = Vector2.zero + offSetPosition;

            GameObject tempObstacles = Instantiate(go, newPosition, Quaternion.identity);



            kage++;
        }

    }
}
