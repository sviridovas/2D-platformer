using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 deathKick = new Vector2(0f, 50f);
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private CapsuleCollider2D _bodyCollider2D;
    private BoxCollider2D _feetCollider2D;
    private float gravityScale;

    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        // _bodyCollider2D = GetComponent<CapsuleCollider2D>();
        _feetCollider2D = GetComponent<BoxCollider2D>();
        gravityScale = _rigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        
        Run();
        Jump();
        Climb();
        Die();
    }

    void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        _rigidbody.velocity = new Vector2(horizontal * runSpeed, _rigidbody.velocity.y);

        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody.velocity.x), 1f);
            _animator.SetBool("Run", true);
        }
        else
            _animator.SetBool("Run", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && _feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Climb()
    {
        float vertical = Input.GetAxis("Vertical");
        
        if(_feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            _rigidbody.gravityScale = 0;
            
            if (Mathf.Abs(vertical) > Mathf.Epsilon )
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, vertical * climbSpeed);
            
                _animator.SetBool("Climb", true);
            }
            else
            {
                _animator.SetBool("Climb", false);
            }
        }
        else
        {
            _rigidbody.gravityScale = gravityScale;
        }
    }

    void Die()
    {
        if(_bodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isDead = true;
            _animator.SetTrigger("Die");
            _rigidbody.velocity = deathKick;
            // FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
