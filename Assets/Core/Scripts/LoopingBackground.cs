


//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxLayer : MonoBehaviour
//{
//    [Tooltip("0 = bev�ger sig helt med kameraet, 1 = st�r stille. Typisk 0.2-0.8.")]
//    [Range(0f, 1f)]
//    public float parallaxFactor = 0.5f;

//    [Tooltip("Skal dette lag loopes? (kr�ver to kopier side om side)")]
//    public bool loop = true;

//    private Camera cam;
//    private float length;
//    private Vector3 startPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;

//        // Pr�v at finde bredde via SpriteRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            length = sr.bounds.size.x;
//            return;
//        }

//        // Hvis ikke, pr�v TilemapRenderer
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
//        if (cam == null || length <= 0) return;

//        // Parallax-bev�gelse
//        float distance = cam.transform.position.x * parallaxFactor;
//        transform.position = new Vector3(startPos.x + distance, startPos.y, startPos.z);

//        if (loop)
//        {
//            // Kameraets fulde bev�gelse (uden faktor)
//            float cameraMovement = cam.transform.position.x;

//            // N�r kameraet har bev�get sig l�ngere end l�ngden, flyttes startpos
//            float offset = (cameraMovement * (1 - parallaxFactor)) % length;
//            transform.position = new Vector3(startPos.x + distance - offset, startPos.y, startPos.z);
//        }
//    }
//}

//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxLayer : MonoBehaviour
//{
//    [Tooltip("0 = bev�ger sig helt med kameraet, 1 = st�r stille. Typisk 0.2-0.8.")]
//    [Range(0f, 1f)]
//    public float parallaxFactor = 0.5f;

//    [Tooltip("Skal dette lag loopes? (kr�ver to kopier side om side)")]
//    public bool loop = true;

//    private Camera cam;
//    private float length;
//    private Vector3 startPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;

//        // Pr�v at finde bredde via SpriteRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            length = sr.bounds.size.x;
//            return;
//        }

//        // Hvis ikke, pr�v TilemapRenderer
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

//        // Loop hvis n�dvendigt
//        if (loop && length > 0)
//        {
//            if (temp > startPos.x + length) startPos.x += length;
//            else if (temp < startPos.x - length) startPos.x -= length;
//        }
//    }
//}



using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundLooper : MonoBehaviour
{
    [Tooltip("Skal baggrunden loopes?")]
    public bool loop = true;

    private float length;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // Tjek for SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            length = sr.bounds.size.x;
            return;
        }

        // Tjek for TilemapRenderer
        TilemapRenderer tr = GetComponent<TilemapRenderer>();
        if (tr != null)
        {
            length = tr.bounds.size.x;
            return;
        }

        Debug.LogWarning($"{name} har ingen SpriteRenderer eller TilemapRenderer!");
    }

    void Update()
    {
        if (!loop || length <= 0) return;

        // Flytter baggrunden n�r kameraet g�r forbi
        if (Camera.main.transform.position.x > startPos.x + length)
        {
            startPos.x += length;
            transform.position = startPos;
        }
        else if (Camera.main.transform.position.x < startPos.x - length)
        {
            startPos.x -= length;
            transform.position = startPos;
        }
    }
}




//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxLayer : MonoBehaviour
//{
//    [Tooltip("0 = bev�ger sig helt med kameraet, 1 = st�r stille. Typisk 0.2-0.8.")]
//    [Range(0f, 1f)]
//    public float parallaxFactor = 0.5f;

//    [Tooltip("Skal dette lag loopes? (kr�ver to kopier side om side)")]
//    public bool loop = true;

//    private Camera cam;
//    private float length;
//    private Vector3 startPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;

//        // Pr�v at finde bredde via SpriteRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            length = sr.bounds.size.x;
//            return;
//        }

//        // Hvis ikke, pr�v TilemapRenderer
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

//        // Loop hvis n�dvendigt
//        if (loop && length > 0)
//        {
//            if (temp > startPos.x + length) startPos.x += length;
//            else if (temp < startPos.x - length) startPos.x -= length;
//        }
//    }
//}
