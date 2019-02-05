using System.Collections.Generic;
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
    public float moveSpeed = 10f;
    public float turnSpeed = -100f;

    int totalSizePucks;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();
        totalSizePucks = Random.Range(5,8);
        Debug.Log("transform position x is : "+ transform.position.x);
        for(int i=0; i<totalSizePucks; i++)
        {
               Vector3 vector3 = new Vector3(transform.position.x + Random.Range(-2.21f, 2.21f), transform.position.y + Random.Range(-1.7f, -0.7f), transform.position.z);

            GameObject player1 = Instantiate(player, vector3, transform.rotation);
        }
    }



    void Update()
    {
        LaunchOnMouseClick();
    }
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //   transform.Translate(-touchDeltaPosition.x * Time.deltaTime * moveSpeed,
            //            -touchDeltaPosition.y * Time.deltaTime * moveSpeed, 0);
            //  var xpos = Mathf.Clamp(transform.position.x + ((touchDeltaPosition.x * Time.deltaTime * moveSpeed) / 10), xMin, xMax);
            //  var ypos = Mathf.Clamp(transform.position.y + ((touchDeltaPosition.y * Time.deltaTime * moveSpeed) / 10), yMin, yMax);
            //  transform.position = new Vector2(xpos, ypos);
           // Debug.Log(Mathf.Clamp(transform.position.x + ((touchDeltaPosition.x * Time.deltaTime * moveSpeed),-1,1)));
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);
        }
        else
        {
            

        }
        Debug.Log(Input.GetAxis("Horizontal"));

        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);

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
