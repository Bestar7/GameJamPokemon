using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private GroundCheckBase raycastGroundCheck;

    public bool isGroundBelow;
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;
    public bool flashEnable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGroundBelow)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGroundBelow = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            flashEnable = !flashEnable;
        }
    }

    void FixedUpdate()
    {
        isGroundBelow = raycastGroundCheck.isGrounded();
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;
    }
}
