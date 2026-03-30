using UnityEngine;

public class cart : MonoBehaviour
{
    public Transform cartObj;
    public float acceleration = 1;
    public float rotateSpeed = 10;
    public bool isPlayer2;
    private float speed;
    private Rigidbody rb;
    [Tooltip("minimum speed is 0")]
    public float maxSpeed = 10;
    [UnityEngine.Serialization.FormerlySerializedAs("backwardSpeedMultiplyer")]
    public float backwardSpeedMultiplier = 0.5f;

    private Player playerComponent;
    
    //minimum speed is 0

    void Start()    
    {
        rb = GetComponent<Rigidbody>();
        playerComponent = GetComponent<Player>();
        speed = 0;
    }

    public void resetSpeed()
    {
        speed = 0;
    }
    void FixedUpdate()
    {
        float horizontal = 0;
        float vertical = 0;

        //always move player forward
        if (isPlayer2)
        {
            //horizontal = Input.GetAxisRaw("Horizontal1");
            //vertical = Input.GetAxisRaw("Vertical1");
            //Debug.Log(horizontal);
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            //Debug.Log(horizontal + "-" + vertical);
        }

        //check if player is trying to move forward or backwards
        if (vertical != 0)
        {
            speed += acceleration * vertical;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            } else if (speed < -maxSpeed * backwardSpeedMultiplier)
            {
                speed = -maxSpeed * backwardSpeedMultiplier;
            }
            
        }
        else
        {
            //check player direction
            if (speed > 0) 
            {

                if (speed - acceleration < 0)
                {
                    speed = 0;
                }
                else {
                    speed -= acceleration;
                }

            }   
            else if (speed < 0) 
            {

                if (speed + acceleration > 0)
                {
                    speed = 0;
                } else
                {
                    speed += acceleration;
                }
                

            }
        }
        //Debug.Log(speed);



        // transform.Translate(Vector3.left * horizontal * speed * Time.deltaTime);
        transform.RotateAround(Vector3.up, horizontal * rotateSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + transform.TransformDirection(Vector3.back) * speed * Time.deltaTime);
        if (cartObj)
        {
            if (Vector3.Dot(Vector3.up, transform.up) < 0)
            {
                playerComponent.resetToCheckpoint();
            }
                
        }
    }
}
