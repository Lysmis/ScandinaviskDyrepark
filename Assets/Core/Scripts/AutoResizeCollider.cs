using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class AutoResizeCollider : MonoBehaviour
{
    private void OnValidate()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        BoxCollider2D bc = GetComponent<BoxCollider2D>();

        if (sr != null && sr.sprite != null)
        {
            bc.size = sr.sprite.bounds.size;
            bc.offset = sr.sprite.bounds.center;
        }
    }
}
