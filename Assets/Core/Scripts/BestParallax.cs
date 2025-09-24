//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class BestParallax : MonoBehaviour
//{
//    [Tooltip("0 = bevæger sig helt med kameraet, 1 = står stille.")]
//    [Range(0f, 1f)]
//    public float parallaxFactor = 0.5f;

//    [Tooltip("Skal dette lag loopes? (kræver to kopier side om side)")]
//    public bool loop = true;

//    private Camera cam;
//    private float length;
//    private Vector3 startPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;

//        // Prøv at finde bredde via SpriteRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            length = sr.bounds.size.x;
//            return;
//        }

//        // Hvis ikke, prøv TilemapRenderer
//        TilemapRenderer tr = GetComponent<TilemapRenderer>();
//        if (tr != null)
//        {
//            length = tr.bounds.size.x;
//            return;
//        }

//        Debug.LogWarning($"{name} har hverken SpriteRenderer eller TilemapRenderer!");
//    }

//    void Update()
//    {
//        if (cam == null) return;

//        float distance = cam.transform.position.x * (1 - parallaxFactor);
//        float temp = cam.transform.position.x * (1 - parallaxFactor);

//        // Flyt baggrund relativt til kamera
//        transform.position = new Vector3(startPos.x + distance, startPos.y, startPos.z);

//        // Loop hvis nødvendigt
//        if (loop && length > 0)
//        {
//            if (temp > startPos.x + length) startPos.x += length;
//            else if (temp < startPos.x - length) startPos.x -= length;
//        }
//    }
//}

using UnityEngine;
using UnityEngine.Tilemaps;

public class BestParallax : MonoBehaviour
{
    [Tooltip("0 = bevæger sig helt med kameraet, 1 = står stille. Typisk 0.2-0.8.")]
    [Range(0f, 1f)]
    public float parallaxFactor = 0.5f;

    [Tooltip("Skal dette lag loopes? (kræver to kopier side om side)")]
    public bool loop = true;

    private Camera cam;
    private float length;
    private Vector3 startPos;

    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;

        // Prøv at finde bredde via SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            length = sr.bounds.size.x;
            return;
        }

        // Hvis ikke, prøv TilemapRenderer
        TilemapRenderer tr = GetComponent<TilemapRenderer>();
        if (tr != null)
        {
            length = tr.bounds.size.x;
            return;
        }

        Debug.LogWarning($"{name} har hverken SpriteRenderer eller TilemapRenderer!");
    }

    void Update()
    {
        if (cam == null) return;

        // Hvor langt kameraet har flyttet sig fra start
        float camMove = cam.transform.position.x;

        // Parallax forskydning
        float distance = camMove * parallaxFactor;

        // Brug startPos som reference
        transform.position = new Vector3(startPos.x + distance, startPos.y, startPos.z);

        // Loop hvis nødvendigt
        if (loop && length > 0)
        {
            float offset = camMove * (1 - parallaxFactor);

            if (offset > startPos.x + length) startPos.x += length;
            else if (offset < startPos.x - length) startPos.x -= length;
        }
    }
}
