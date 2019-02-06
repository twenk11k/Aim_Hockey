using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startingPosition;
    Boundary playerBoundary;
    public Collider2D PlayerCollider { get; private set; }
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    public float maxSpeed;

    // nullable int
    public int? LockedFingerID { get; set; }


    public GameObject arrow;
    public GameObject player;

    private bool hasStarted = false;
    public float moveSpeed = 2.0f;
    public float turnSpeed = -200f;
    public float turnSpeedTouch = -1000f;

    int totalSizePucks;

 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();
        //InstantiatePlayers();
    }

    void Update()
    {
        // LaunchOnMouseClick();
        /*
    if (Input.touches.Length > 0)
    {
        var t = Input.GetTouch(0);

        if (t.phase == TouchPhase.Moved)
        {
               var delta = t.deltaPosition * turnSpeed * Time.deltaTime;

               transform.Rotate(0,0,Mathf.Clamp(Mathf.Atan2(delta.y, delta.x), -1,1));

            //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg));

        }
    }
    */
       

    }

    private void InstantiatePlayers()
    {
        totalSizePucks = Random.Range(4, 7);
        Debug.Log("transform position x is : " + transform.position.x);
        for (int i = 0; i < totalSizePucks; i++)
        {
            Vector3 vector3 = new Vector3(transform.position.x + Random.Range(-2.21f, 2.21f), transform.position.y + Random.Range(-1.7f, -0.7f), transform.position.z);

            GameObject player1 = Instantiate(player, vector3, transform.rotation) as GameObject;
        }
    }

   
    void FixedUpdate()
    {
         TouchControl();
        
    }

    private void TouchControl()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Debug.Log(Mathf.Clamp(touchDeltaPosition.x, -1, 1));
            //   transform.Translate(-touchDeltaPosition.x * Time.deltaTime * moveSpeed,
            //            -touchDeltaPosition.y * Time.deltaTime * moveSpeed, 0);
            //  var xpos = Mathf.Clamp(transform.position.x + ((touchDeltaPosition.x * Time.deltaTime * moveSpeed) / 10), xMin, xMax);
            //  var ypos = Mathf.Clamp(transform.position.y + ((touchDeltaPosition.y * Time.deltaTime * moveSpeed) / 10), yMin, yMax);
            //  transform.position = new Vector2(xpos, ypos);
            Debug.Log(Mathf.Clamp(touchDeltaPosition.x, -1, 1));
            transform.Rotate(0, 0, Mathf.Clamp(touchDeltaPosition.x, -1, 1) * turnSpeed * Time.deltaTime);
        }
       //   Debug.Log(Input.GetAxis("Horizontal"));

       // transform.Rotate(0, 0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);




        // rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        //  transform.Rotate(Vector3.forward,0,Input.GetAxis("Horizontal")*speed*Time.deltaTime);

    }

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
                float fRotation = rb.rotation * Mathf.Deg2Rad;
                float fX = Mathf.Sin(fRotation);
                float fY = Mathf.Cos(fRotation);
                Vector2 v2 = new Vector2(fY * moveSpeed, fX * moveSpeed);
                rb.velocity = v2;
                arrow.SetActive(false);
                hasStarted = true;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                arrow.SetActive(true);
                hasStarted = false;
            }
        }

    }
    /*private void OnCollisionEnter2D(Collision2D collision)
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
