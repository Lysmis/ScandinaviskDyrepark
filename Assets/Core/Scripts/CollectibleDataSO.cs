using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleDataSO", menuName = "Scriptable Objects/CollectibleDataSO")]
public class CollectibleDataSO : ScriptableObject
{
    private int collectibleCount;

    public int CollectibleCount { get => collectibleCount; set => collectibleCount = value; }

    public event Action<int> OnCollectibleCountChanged;


    //Resetter tæller
    void Reset()
    {
        CollectibleCount = 0;
        OnCollectibleCountChanged?.Invoke(collectibleCount);
    }

    //Tilføjer 1 til vores tæller collectibleCount
    public void AddCollectible()
    {
        CollectibleCount++;
        OnCollectibleCountChanged?.Invoke(collectibleCount);
    }
}
