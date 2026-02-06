using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput = 0;
    private float forwardInput = 0;
    public float XRange = 10;   
    [SerializeField] float currentSpeed;
    InputAction moveAction;
    InputAction shootAction;
    float waitTime = 0;
    float reloadTime = 0.5f;
    public GameObject Pizza;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>(); //or Vector2 hInput = moveAction.ReadValue<Vector2>().x directly instead of declaring horizontalInput
        horizontalInput = input.x;
        forwardInput = input.y;

        if (transform.position.x < -XRange)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z); //doesnt allow players x position to go below -10 and above 10
        }
        if (transform.position.x > XRange)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        }

        transform.Translate(currentSpeed * Time.deltaTime * horizontalInput * Vector3.right);
        transform.Translate(currentSpeed * Time.deltaTime * forwardInput * Vector3.forward);

        if (shootAction.IsPressed())
        {
            waitTime += Time.deltaTime;

            if (waitTime >= reloadTime)
            {
                Instantiate(Pizza, transform.position, Quaternion.identity);
                
                waitTime = 0;
            }
        }
        else
        {
            waitTime = reloadTime;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red ;
        //Gizmos.DrawWireSphere(transform.position, XRange);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);

        Gizmos.DrawLine(new Vector3(XRange, transform.position.y , transform.position.z), 
            new Vector3(-XRange, transform.position.y, transform.position.z)); //defining the beginning and the end of where to draw the line
    }
}
