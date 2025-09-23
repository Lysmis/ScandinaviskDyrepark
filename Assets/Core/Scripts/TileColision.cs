using UnityEngine;

public class TileColision : MonoBehaviour
{
    #region Fields
    private Rigidbody2D rb;
    private CompositeCollider2D compositeCollider;
    private SpriteTileMode tileMode;
    #endregion
    #region Properties

    #endregion
    #region Methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        compositeCollider = GetComponent<CompositeCollider2D>();
        tileMode = GetComponent<SpriteTileMode>();

        //CompositeCollider2D.CompositeOperation.Merge;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
