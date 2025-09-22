using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    Label timeLabel, pickUpLabel;
    [SerializeField] private CollectibleDataSO collectibleData;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        timeLabel = root.Q<Label>("TimeLabel");
        pickUpLabel = root.Q<Label>("PickUpLabel");
    }
    /// <summary>
    /// Sets the Time value in the HUD
    /// </summary>
    /// <param name="seconds">Number of seconds the remaining time should be set to</param>
    public void SetTime(float seconds)
    {
        if (timeLabel != null)
        {
            timeLabel.text = $"{(int)seconds}s";
        }
    }
    /// <summary>
    /// Sets the PickUp value in the HUD
    /// </summary>
    /// <param name="value">Number of items picked up by the player</param>
    public void SetPickUp(int value)
    {
        if (pickUpLabel != null)
        {
            pickUpLabel.text = $"{collectibleData.CollectibleCount}"; //Henter data fra CollectibleDataSO
        }
    }

}
