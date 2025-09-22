using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleDataSO", menuName = "Scriptable Objects/CollectibleDataSO")]
public class CollectibleDataSO : ScriptableObject
{
    private int collectibleCount;

    public int CollectibleCount { get => collectibleCount; set => collectibleCount = value; }


    //Ressetter tæller
    void Reset()
    {
        CollectibleCount = 0;
    }

    //+1 collectible
    public void AddCollectible(int amount = 1)
    {
        CollectibleCount += amount;
    }
}
