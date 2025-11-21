using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour, IKillable
{
    private bool holdingJump = false;
	private bool facingRight = true;
    private bool frozen = false;
    
	private Rigidbody2D rigidbody;
    private Transform spriteTransform;
    private Animator animator;

    [SerializeField] private int lives = 5;
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;

    private Vector2 moveInput;
    private bool jumped;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteTransform = transform.GetChild(0);
        livesText.SetText($"Lives: {lives}");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen)
        {

            Vector2 deltaPos = new Vector2(
                moveInput.x * speed,
                rigidbody.linearVelocity.y
            );

            if (jumped && 
               
                Physics2D.OverlapBox(groundChecker.position, groundChecker.localScale / 2.0f,0, groundMask)
               )
            {
                if (!holdingJump)
                {
                    deltaPos.y = 10.0f;
                    holdingJump = true;
                }
            }
            else
            {
                holdingJump = false;
            }

            animator.SetBool("Walking", Mathf.Abs(deltaPos.x) > 0.0f);
            Flip(deltaPos.x);
        
            rigidbody.linearVelocity = deltaPos;
        }

        //Die if player falls off
        if (transform.position.y < -35.0f)
        {
            Kill();
        }
    }

	void Flip(float m)
    {
		//m is the movement direction
        //Get current direction and compare it to movement direction
        if((facingRight && m < 0) || (!facingRight && m > 0))
        {
            //if they are not the same, then flip and change facingRight
            spriteTransform.Rotate(new Vector3(0,180,0));
            facingRight = !facingRight;
        }
    }

    public void ShouldFreeze(bool shouldFreeze)
    {
        frozen = shouldFreeze;

        if (shouldFreeze)
        {
            rigidbody.linearVelocity = Vector2.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started) jumped = true;
        if(context.canceled) jumped = false;
    }

    public void Kill()
    {
        livesText.SetText($"Lives: {--lives}");
        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
        
        transform.position = Vector2.zero;
        rigidbody.linearVelocity = Vector2.zero;
    }
}
