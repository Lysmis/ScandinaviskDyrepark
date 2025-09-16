using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundBehavior : MonoBehaviour
{
    private new BoxCollider2D collider;
    private Rigidbody2D rb;
    private float startPosX;

    private float width;
    [Tooltip("Backgroundlayer speed, 0 = stopped, -5 = pretty fast")]
    [SerializeField]private float scrollSpeed = -2f;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        //width = collider.size.x;

        startPosX = transform.position.x;
        collider.enabled = false;

        rb.linearVelocity = new Vector2(scrollSpeed, 0);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * scrollSpeed * Time.deltaTime);

        if (rb.position.x <= startPosX - width)
        {
            rb.position = rb.position + new Vector2(width, 0f);
        }
    }





}
