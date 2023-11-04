using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private PlayerInformation playerInformation;
    private int playerAgility;

    private Vector3 moveDirection;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxSpeed = 3;

    private bool isDash = false;
    private bool isDashPossible = true;
    private float dashCool = 5f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerInformation = GetComponent<PlayerInformation>();
        playerAgility = playerInformation.GetPlayerAgility();
        movementSpeed = playerAgility;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isDash)
        {
            Move();
        }
    }

    private void Move()
    {
        rigid.AddForce(moveDirection * movementSpeed, ForceMode2D.Impulse);

        // x축 최대 속도
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // y축 최대 속도
        if (rigid.velocity.y > maxSpeed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
        }
        else if (rigid.velocity.y < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if(input != null)
        {
            moveDirection = new Vector3(input.x, input.y, 0f);
            if(input.x != 0 && input.y != 0)
            {
                moveDirection = new Vector3(input.x * (1f / Mathf.Sqrt(2)), input.y * (1f / Mathf.Sqrt(2)), 0f);
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!isDashPossible || isDash || moveDirection == Vector3.zero)
        {
            return;
        }

        isDash = true;
        isDashPossible = false;
        rigid.AddForce(moveDirection * movementSpeed * 50f, ForceMode2D.Impulse);

        StartCoroutine(duringDash());
        StartCoroutine(dashCoolDown());
    }

    IEnumerator duringDash()
    {
        yield return new WaitForSeconds(0.5f);
        isDash = false;
    }

    IEnumerator dashCoolDown()
    {
        yield return new WaitForSeconds(dashCool);
        isDashPossible = true;
    }
}
