using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    //private float startPos;
    //[SerializeField] private GameObject cam;
    //[SerializeField] private float parallaxSpeed;


    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    startPos = transform.position.x;
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    float distance = cam.transform.position.x * parallaxSpeed;

    //    transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    //}

    private BoxCollider2D collider;
    private Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -2f;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = collider.size.x;
        collider.enabled = false;

        rb.linearVelocity = new Vector2(scrollSpeed, 0);
    }

    private void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
