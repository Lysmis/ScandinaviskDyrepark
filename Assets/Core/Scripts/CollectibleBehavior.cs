using UnityEngine;
using System.Collections;


public class CollectibleBehavior : MonoBehaviour
{
    [SerializeField]private CollectibleDataSO collectibleData;

    private AudioSource coinSound;

    private void Start()
    {

        coinSound = GetComponent<AudioSource>();   

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            collectibleData.AddCollectible();
            coinSound.PlayOneShot(coinSound.clip);
        }
    }

    [ContextMenu("Force Update")]
    void OnValidate()
    {
        //Getting SpriteRenderer
        SpriteRenderer srObstacles = GetComponent<SpriteRenderer>();

        //Getting BoxCollision2D
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        //Resizing the CollisionBox
        if (boxCollider != null && srObstacles.sprite != null)
        {
            boxCollider.size = srObstacles.sprite.bounds.size;
            boxCollider.offset = srObstacles.sprite.bounds.center;

        }

    }

}
