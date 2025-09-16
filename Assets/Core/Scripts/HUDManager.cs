using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    Label timeLabel, pickUpLabel;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        timeLabel = root.Q<Label>("TimeLabel");
        pickUpLabel = root.Q<Label>("PickUpLabel");
    }
    /// <summary>
    /// Sets the Time value in the HUD
    /// </summary>
    /// <param name="seconds">Number of seconds remaining</param>
    public void SetTime(int seconds)
    {
        if (timeLabel != null)
        {
            timeLabel.text = $"{seconds}s";
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
            pickUpLabel.text = $"{value}";
        }
    }

}
