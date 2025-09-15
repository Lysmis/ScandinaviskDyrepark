using UnityEngine;

[CreateAssetMenu(fileName = "AnimalAnimations", menuName = "Scriptable Objects/AnimalAnimations")]
public class AnimalAnimations : ScriptableObject
{

    public AnimationClip Running;
    public AnimationClip Jumping;
    public AnimationClip Flying;
    public AnimationClip Falling;
    public AnimationClip Landing;
    public Sprite Sprite;

}
