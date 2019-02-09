using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 startingPosition;
    Boundary playerBoundary;
    public Collider2D PlayerCollider { get; private set; }
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    public float maxSpeed;

    // nullable int
    public int? LockedFingerID { get; set; }
    public GameObject arrow;


    int totalSizePucks;

    [SerializeField] AudioClip puckClip;

    public bool isBelow = true;

    public Player()
    {
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("carpisma adi: " + collision.collider.name);
        if (puckClip != null)
        {
           // AudioSource.PlayClipAtPoint(puckClip, Camera.main.transform.position, 0.2f);

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();
        if (isBelow)
        {
            transform.Rotate(0, 0, 90);
        } else
        {
            transform.Rotate(0, 0, -90);
        }
    }

    
}
