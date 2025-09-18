//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform target; // dyret
//    public Vector3 offset = new Vector3(0, 0, -10);

//    void LateUpdate()
//    {
//        if (target != null)
//        {
//            transform.position = target.position + offset;
//        }
//    }
//}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target;

    [Header("Camera offset")]
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Lock axes")]
    public bool lockY = true;   // Skal vi låse kameraet på Y-aksen?

    private float fixedY;       // Gemmer den låste Y-værdi

    void Start()
    {
        if (lockY && target != null)
        {
            fixedY = target.position.y + offset.y;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        float newX = target.position.x + offset.x;
        float newY = lockY ? fixedY : target.position.y + offset.y;
        float newZ = target.position.z + offset.z;

        transform.position = new Vector3(newX, newY, newZ);
    }
}

