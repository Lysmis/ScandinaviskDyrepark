//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxScript : MonoBehaviour
//{
//    private Vector2 startPos;  // Initial position of the tilemap
//    private float length;  // Length of the tilemap in the X-axis
//    private Camera cam;  // Reference to the main camera

//    [Tooltip("0 = move with camera, 1 = no movement")]
//    public float ParallaxAmountX;  // Controls parallax movement on the X-axis
//    public float ParallaxAmountY;  // Controls parallax movement on the Y-axis
//    public bool loop = true;

//    private TilemapRenderer tilemapRenderer;  // Reference to the TilemapRenderer
//    private Bounds tilemapBounds;  // Bounds of the tilemap
//    public Vector2 camStartPos;  // Initial position of the camera

//    void Start()
//    {
//        cam = Camera.main;
//        tilemapRenderer = GetComponent<TilemapRenderer>();
//        tilemapBounds = tilemapRenderer.localBounds;

//        startPos = transform.position;  // Store the initial position of the tilemap
//        camStartPos = cam.transform.position;  // Store the initial position of the camera
//        length = tilemapBounds.size.x;  // Get the length of the tilemap
//    }

//    void FixedUpdate()
//    {
//        //Sørger for camera
//        if (cam == null)
//        {
//            cam = Camera.main; // prøv at finde et nyt main camera
//            if (cam == null) return; // stadig intet kamera, så spring over
//        }

//        // Calculate the distance the camera has moved since the start position
//        float distanceX = (cam.transform.position.x - camStartPos.x) * ParallaxAmountX;
//        float distanceY = (cam.transform.position.y - camStartPos.y) * ParallaxAmountY;

//        // Apply the parallax effect on both X and Y axes, relative to the starting position
//        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

//        // Infinite scrolling logic for the X-axis
//        float movementX = (cam.transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);

//        if (loop)
//        {
//            if (movementX > startPos.x + length)
//            {
//                startPos.x += length;
//            }
//            else if (movementX < startPos.x - length)
//            {
//                startPos.x -= length;
//            }
//        }
//    }

//    //https://www.youtube.com/watch?v=QAmcDlsdCK0 about parallaxing and tilemaps
//}

//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxScript : MonoBehaviour
//{
//    private Vector2 startPos;  // Initial position
//    private float length;      // Width of sprite/tilemap in world units
//    private Camera cam;        // Reference to the main camera

//    [Tooltip("0 = følger kameraet helt, 1 = står stille. Typisk 0.2-0.8")]
//    [Range(0f, 1f)]
//    public float parallaxFactorX = 0.5f;

//    [Tooltip("0 = følger kameraet helt, 1 = står stille på Y-aksen")]
//    [Range(0f, 1f)]
//    public float parallaxFactorY = 1f;

//    [Tooltip("Skal baggrunden loope?")]
//    public bool loop = true;

//    private Bounds bounds; // generelle bounds (fra SpriteRenderer eller TilemapRenderer)
//    private Vector2 camStartPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;
//        camStartPos = cam.transform.position;

//        // Tjek om vi har SpriteRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            bounds = sr.bounds;
//            length = bounds.size.x;
//            return;
//        }

//        // Ellers tjek TilemapRenderer
//        TilemapRenderer tr = GetComponent<TilemapRenderer>();
//        if (tr != null)
//        {
//            bounds = tr.localBounds;
//            length = bounds.size.x;
//            return;
//        }

//        Debug.LogWarning($"{name} har hverken SpriteRenderer eller TilemapRenderer – parallax virker ikke.");
//    }

//    void FixedUpdate()
//    {
//        if (cam == null)
//        {
//            cam = Camera.main;
//            if (cam == null) return;
//        }

//        // Kameraets forskydning
//        float distanceX = (cam.transform.position.x - camStartPos.x) * (1 - parallaxFactorX);
//        float distanceY = (cam.transform.position.y - camStartPos.y) * (1 - parallaxFactorY);

//        // Flyt baggrund i forhold til kamera
//        transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, transform.position.z);

//        // Loop kun på X-aksen
//        if (loop && length > 0)
//        {
//            if (distanceX > startPos.x + length)
//            {
//                startPos.x += length;
//            }
//            else if (distanceX < startPos.x - length)
//            {
//                startPos.x -= length;
//            }
//        }
//    }
//}

//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxScript : MonoBehaviour
//{
//    [Tooltip("0 = bevæger sig helt med kameraet, 1 = står stille. Typisk 0.2-0.8.")]
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

//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxScript : MonoBehaviour
//{
//    [Range(0f, 1f)]
//    [Tooltip("0 = bevæger sig helt med kameraet, 1 = står stille")]
//    public float parallaxFactor = 0.5f;

//    [Tooltip("Skal dette lag loope? Kræver to kopier side om side")]
//    public bool loop = true;

//    private Camera cam;
//    private float length;
//    private Vector3 startPos;

//    void Start()
//    {
//        cam = Camera.main;
//        startPos = transform.position;

//        // Find bredde fra SpriteRenderer eller TilemapRenderer
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            length = sr.bounds.size.x;
//        }
//        else
//        {
//            TilemapRenderer tr = GetComponent<TilemapRenderer>();
//            if (tr != null)
//            {
//                length = tr.bounds.size.x;
//            }
//            else
//            {
//                Debug.LogWarning($"{name} har hverken SpriteRenderer eller TilemapRenderer!");
//            }
//        }
//    }

//    void Update()
//    {
//        if (cam == null) return;

//        float distance = cam.transform.position.x * (1 - parallaxFactor);

//        // Parallax bevægelse
//        transform.position = new Vector3(startPos.x + distance, startPos.y, startPos.z);

//        // Loop
//        if (loop && length > 0)
//        {
//            float camDistance = cam.transform.position.x - transform.position.x;

//            if (Mathf.Abs(camDistance) >= length)
//            {
//                float offset = (camDistance > 0) ? length : -length;
//                startPos.x += offset;
//            }
//        }
//    }
//}


//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxScript : MonoBehaviour
//{
//    private Vector2 startPos;  // Initial position of the tilemap
//    private float length;  // Length of the tilemap in the X-axis
//    private Camera cam;  // Reference to the main camera

//    [Tooltip("0 = move with camera, 1 = no movement")]
//    public float ParallaxAmountX;  // Controls parallax movement on the X-axis
//    public float ParallaxAmountY;  // Controls parallax movement on the Y-axis
//    public bool loop = true;

//    private TilemapRenderer tilemapRenderer;  // Reference to the TilemapRenderer
//    private Bounds tilemapBounds;  // Bounds of the tilemap
//    public Vector2 camStartPos;  // Initial position of the camera

//    void Start()
//    {
//        cam = Camera.main;
//        tilemapRenderer = GetComponent<TilemapRenderer>();
//        tilemapBounds = tilemapRenderer.localBounds;

//        startPos = transform.position;  // Store the initial position of the tilemap
//        camStartPos = cam.transform.position;  // Store the initial position of the camera
//        length = tilemapBounds.size.x;  // Get the length of the tilemap
//    }

//    void FixedUpdate()
//    {
//        // Calculate the distance the camera has moved since the start position
//        float distanceX = (cam.transform.position.x - camStartPos.x) * ParallaxAmountX;
//        float distanceY = (cam.transform.position.y - camStartPos.y) * ParallaxAmountY;

//        // Apply the parallax effect on both X and Y axes, relative to the starting position
//        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

//        // Infinite scrolling logic for the X-axis
//        float movementX = (cam.transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);

//        if (loop)
//        {
//            if (movementX > startPos.x + length)
//            {
//                startPos.x += length;
//            }
//            else if (movementX < startPos.x - length)
//            {
//                startPos.x -= length;
//            }
//        }
//    }
//}


//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class ParallaxTilemap : MonoBehaviour
//{
//    private Vector2 startPos;
//    private float length;
//    private Camera cam;

//    [Tooltip("0 = move with camera, 1 = no movement")]
//    public float ParallaxAmountX = 0.5f;
//    public float ParallaxAmountY = 0f;
//    public bool loop = true;

//    private Tilemap tilemap;
//    private Bounds tilemapBounds;
//    private Vector2 camStartPos;

//    void Start()
//    {
//        cam = Camera.main;
//        tilemap = GetComponent<Tilemap>();

//        // Hent korrekte bounds
//        tilemap.CompressBounds(); // fjerner tomme felter
//        tilemapBounds = tilemap.localBounds;

//        startPos = transform.position;
//        camStartPos = cam.transform.position;

//        length = tilemapBounds.size.x; // nu passer det til hele tilemappet
//    }

//    void FixedUpdate()
//    {
//        if (cam == null) return;

//        float distanceX = (cam.transform.position.x - camStartPos.x) * ParallaxAmountX;
//        float distanceY = (cam.transform.position.y - camStartPos.y) * ParallaxAmountY;

//        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

//        float movementX = (cam.transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);

//        if (loop && length > 0)
//        {
//            if (movementX > startPos.x + length)
//                startPos.x += length;
//            else if (movementX < startPos.x - length)
//                startPos.x -= length;
//        }
//    }
//}


using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Renderer))]
public class ParallaxScript : MonoBehaviour
{
    private Vector2 startPos;       // Initial position
    private float length;           // Width of sprite/tilemap
    private Camera cam;             // Main camera reference

    [Tooltip("0 = move fully with camera, 1 = fixed (no parallax). Typical range 0.2 - 0.8")]
    [Range(0f, 1f)] public float ParallaxAmountX = 0.5f;
    [Range(0f, 1f)] public float ParallaxAmountY = 0f;
    [Tooltip("Should this background loop infinitely on the X-axis?")]
    public bool loop = true;

    private Bounds bounds;          // Calculated bounds (sprite or tilemap)
    private Vector2 camStartPos;    // Camera's start position

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("ParallaxUniversal: No MainCamera found!");
            return;
        }

        // Try to detect renderer type
        TilemapRenderer tr = GetComponent<TilemapRenderer>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (tr != null)
        {
            bounds = tr.bounds;
        }
        else if (sr != null)
        {
            bounds = sr.bounds;
        }
        else
        {
            Debug.LogWarning($"{name} has no SpriteRenderer or TilemapRenderer!");
            return;
        }

        startPos = transform.position;
        camStartPos = cam.transform.position;
        length = bounds.size.x;
    }

    void Update()
    {
        if (cam == null) return;

        // Calculate parallax offset
        float distanceX = (cam.transform.position.x - camStartPos.x) * ParallaxAmountX;
        float distanceY = (cam.transform.position.y - camStartPos.y) * ParallaxAmountY;

        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

        // Loop logic (X-axis only for now)
        if (loop && length > 0f)
        {
            float movementX = (cam.transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);

            if (movementX > startPos.x + length)
            {
                startPos.x += length;
            }
            else if (movementX < startPos.x - length)
            {
                startPos.x -= length;
            }
        }
    }
}
