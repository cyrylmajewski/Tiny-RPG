using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public int facingDirection = 1;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    public Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        anim.SetFloat("horizontal", Mathf.Abs(moveInput.x));
        anim.SetFloat("vertical", Mathf.Abs(moveInput.y));

        if (moveInput.x > 0 && transform.localScale.x < 0 || moveInput.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        //float speed = moveInput.magnitude;
        //anim.SetFloat("speed", speed);
    }

    private void FixedUpdate()
    {
        
        rb.linearVelocity = moveInput * moveSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
