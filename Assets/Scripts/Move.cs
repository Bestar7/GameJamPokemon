using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Move : MonoBehaviour
{

    [SerializeField] private GroundCheckBase raycastGroundCheck;

    private bool isGroundBelow;
    [SerializeField] private float jumpForce;
    [SerializeField]  private float speed;
    private Rigidbody2D rb;
    private bool flashEnable;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject flashLight;
	[SerializeField] private GameObject playerHalo;
	[SerializeField] private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flashEnable = false;
        

    }

    void Update() // TODO synchro movement (input) et annimation
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Up")) && isGroundBelow)
        {
			animator.ResetTrigger("isJumping");
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGroundBelow = false;
            animator.SetTrigger("isJumping");
		}
        
        if (Input.GetButtonDown("Fire1") && inventory.CanStartFlashLight())
        {
            inventory.isFlashLightOn = !inventory.isFlashLightOn;
			flashEnable = inventory.isFlashLightOn;
        }
       
    }

	private void ChangeHalo(bool isLightOn)
	{
		if (isLightOn)
			playerHalo.GetComponent<Light2D>().intensity = 0.8f;
		else
			playerHalo.GetComponent<Light2D>().intensity = 0.3f;
	}

    void FixedUpdate()
    {

		flashLight?.SetActive(inventory.isFlashLightOn);  
		ChangeHalo(inventory.isFlashLightOn);


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

