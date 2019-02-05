using System.Collections.Generic;
using UnityEngine;

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

    private float speed = -50f;

    public GameObject arrow;
    private bool hasStarted = false;


    void FixedUpdate()
    {
        //  transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        rb.transform.Rotate(0,0,Input.GetAxis("Horizontal")*speed*Time.deltaTime);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();
       
    }
   
    
    void Update()
    {
            LaunchOnMouseClick();
        
        // transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (!hasStarted)
            {
                rb.velocity = new Vector2(0, yPush);
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
