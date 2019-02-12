using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.0025f;
    private Vector3 offset;
    public float xValPositive = 0.2f;
    public float xValNegative = -0.2f;

    bool isCurrentPositive = true;

    void FixedUpdate()
    {
        if(target.transform.position.x>= 5.09)
        {
            offset = new Vector3(xValNegative, 0, 0);
            isCurrentPositive = false;

        } else if (target.transform.position.x <= -5.09)
        {
            offset = new Vector3(xValPositive, 0, 0);
            isCurrentPositive = true;

        }
        else
        {
            if(isCurrentPositive)
            {
                offset = new Vector3(xValPositive, 0, 0);
            } else
            {
                offset = new Vector3(xValNegative, 0, 0);

            }
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
