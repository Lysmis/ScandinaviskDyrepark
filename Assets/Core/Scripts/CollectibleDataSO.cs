using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleDataSO", menuName = "Scriptable Objects/CollectibleDataSO")]
public class CollectibleDataSO : ScriptableObject
{
    private int collectibleCount;

    public int CollectibleCount { get => collectibleCount; set => collectibleCount = value; }

    public event Action<int> OnCollectibleCountChanged;


    //Resetter t�ller
    void Reset()
    {
        CollectibleCount = 0;
        OnCollectibleCountChanged?.Invoke(collectibleCount);
    }

    //Tilf�jer 1 til vores t�ller collectibleCount
    public void AddCollectible()
    {
        CollectibleCount++;
        OnCollectibleCountChanged?.Invoke(collectibleCount);
    }
}
