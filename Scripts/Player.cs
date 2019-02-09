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

    public bool isSolo = false;

    public Player()
    {
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("carpisma adi: " + collision.collider.name);
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
        if (isSolo)
        {
            transform.Rotate(0, 0, 90);
        } else
        {
            transform.Rotate(0, 0, -90);
        }
    }

    /*
    private void LaunchOnMouseClick()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (!hasStarted)
            {
                float fRotation = rb.rotation * Mathf.Deg2Rad;
                float fX = Mathf.Sin(fRotation);
                float fY = Mathf.Cos(fRotation);
                Vector2 v2 = new Vector2(fY*moveSpeed, fX*moveSpeed);
                rb.velocity = v2;
                arrow.SetActive(false);
                hasStarted = true;
            } else
            {
                rb.velocity = new Vector2(0, 0);
                arrow.SetActive(true);
                hasStarted = false;
            }
          
        }
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled))
        {
            if (!hasStarted)
            {
                if (!isMoved)
                {
                    float fRotation = rb.rotation * Mathf.Deg2Rad;
                    float fX = Mathf.Sin(fRotation);
                    float fY = Mathf.Cos(fRotation);
                    Vector2 v2 = new Vector2(fY * moveSpeed, fX * moveSpeed);
                    rb.velocity = v2;
                    arrow.SetActive(false);
                    hasStarted = true;
                } else
                {
                    isMoved = false;
                }
              
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                arrow.SetActive(true);
                hasStarted = false;
            }
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        rb.velocity += velocityTweak;

    }
    */
    private void TouchSlide()
    {
        /*
     for (int i = 0; i < Input.touchCount; i++)
     {
         Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
             if (LockedFingerID == null)
             {
                 if (Input.GetTouch(i).phase == TouchPhase.Began
                     && PlayerCollider.OverlapPoint(touchWorldPos))
                 {
                     LockedFingerID = Input.GetTouch(i).fingerId;
                 }
             }
             else if (LockedFingerID == Input.GetTouch(i).fingerId)
             {
                 MoveToPosition(touchWorldPos);
                 if (Input.GetTouch(i).phase == TouchPhase.Ended ||
                     Input.GetTouch(i).phase == TouchPhase.Canceled)
                 {
                     LockedFingerID = null;
                 }
             }

     }
     if (Input.GetKeyDown(KeyCode.Escape))
     {
        // SceneManager.LoadScene("Menu");
     }
     */
    }
    
}
