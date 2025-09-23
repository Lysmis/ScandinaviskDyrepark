using UnityEngine;
using System.Collections;


public class CollectibleBehavior : MonoBehaviour
{
    [SerializeField]private CollectibleDataSO collectibleData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            collectibleData.AddCollectible();
            Destroy(gameObject);
        }
    }
  

    
}
