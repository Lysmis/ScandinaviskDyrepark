using UnityEngine;

[CreateAssetMenu(fileName = "AnimalAnimations", menuName = "Scriptable Objects/AnimalAnimations")]
public class AnimalAnimations : ScriptableObject
{

    [Tooltip("Animation to simulate running - default state")] public AnimationClip Running;
    [Tooltip("Animation for initiating jump")] public AnimationClip Jumping;
    [Tooltip("Animation for almost not gaining or losing altitude")] public AnimationClip Flying;
    [Tooltip("Animation when losing altitude")] public AnimationClip Falling;
    [Tooltip("Animation for ending jump")] public AnimationClip Landing;
    [Tooltip("Default sprite for object, set from object")] public Sprite Sprite;

}
