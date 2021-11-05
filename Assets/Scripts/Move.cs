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
    [SerializeField] private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flashEnable = false;
        

    }

    void Update() // TODO synchro movement (input) et annimation
    {
        if (Input.GetButtonDown("Jump") && isGroundBelow)
        {
			animator.ResetTrigger("isJumping");
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGroundBelow = false;
            animator.SetTrigger("isJumping");
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
		animator.SetBool("isGrounded", isGroundBelow);
        float xAxis = Input.GetAxis("Horizontal");

		animator.SetBool("isRunning", (xAxis != 0) );

        if (xAxis < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        Vector3 move = new Vector3(xAxis * speed, rb.velocity.y, 0f);
        rb.velocity = move;
    }
}

