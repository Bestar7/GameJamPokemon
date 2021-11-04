using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private GroundCheckBase raycastGroundCheck;

    private bool isGroundBelow;
    [SerializeField] private float jumpForce;
    [SerializeField]  private float speed;
    private Rigidbody2D rb;
    private bool flashEnable;
    [SerializeField] private Inventary inventary;
    [SerializeField] private GameObject flashLight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flashEnable = false;
        

    }

    void Update() // TODO synchro movement (input) et annimation
    {
        if (Input.GetButtonDown("Jump") && isGroundBelow)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGroundBelow = false;
        }
        
        if (Input.GetButtonDown("Fire1") && inventary.CanStartFlashLight())
        {
            inventary.isFlashLightOn = !inventary.isFlashLightOn;
            flashEnable = inventary.isFlashLightOn;

        }
    }

    void FixedUpdate()
    {

       flashLight?.SetActive(inventary.isFlashLightOn);     
        
         

        isGroundBelow = raycastGroundCheck.isGrounded();
        float x = Input.GetAxis("Horizontal");
        
        if(x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (x>0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;
    }
}

