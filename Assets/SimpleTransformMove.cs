using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransformMove : MonoBehaviour
{
    public float MaxSpeed = 20;    
    public float Acceleration = 1;
    public float SecondsToStop= 1;

    public float Speed = 0;
    public event System.Action OnGroundTouch;
    public event System.Action OnJump;
    public event System.Action OnAttack;

    public List<Collider> feetColliders;

    private float directionY = 0;
    private float directionX = 0;
    private Rigidbody rb;
    private Transform cameraTransform;

    private bool holdJump = false;
    private float jumpTime = 1;
    private float curJumpTime = 0;
    private float deceleration = 0;

    private void Start()
    {
        this.cameraTransform = Camera.main.transform;
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        checkVerticalDirection();
        checkHozontalDirection();
        inputCheck();
    }

    void FixedUpdate()
    {
        checkAcceleration();
        if (holdJump && jumpTime > curJumpTime)
        {
            curJumpTime += Time.deltaTime * jumpTime;
            rb.velocity += Vector3.up;
        } else
        {
            curJumpTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach( Collider collider in feetColliders)
        {
            Debug.Log("collider -> " + collider);
            if (other.bounds.Intersects(collider.bounds))
            {
                Debug.Log("invoke");
                OnGroundTouch.Invoke();
                return;
            }
        }
    }

    private void inputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdJump = true;
            OnJump.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            holdJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnAttack.Invoke();
        }
    }

    private void checkAcceleration()
    {
        checkMovimentacao();
    }

    private void checkMovimentacao()
    {

        float y = Input.GetAxis("Vertical");
        Vector3 forwardMovement = getAccelerationVector(y, cameraTransform.forward) * directionY;

        float x = Input.GetAxis("Horizontal");
        Vector3 rightMovement = getAccelerationVector(x, cameraTransform.right) * directionX;

        this.rb.velocity += forwardMovement + rightMovement;
        this.rb.velocity = Vector3.ClampMagnitude(this.rb.velocity, MaxSpeed);
    }

    private Vector3 getAccelerationVector(float inputValue, Vector3 inputDirection)
    {
        if (Mathf.Abs(inputValue) > 0)
        {
            deceleration = 0;
            Speed += Acceleration * Time.deltaTime;
        }
        else if (deceleration == 0)
        {
            deceleration = Speed * (1 / SecondsToStop);
        }
        if (deceleration > 0)
        {
            Speed -= deceleration * Time.deltaTime;
        }

        Speed = Mathf.Clamp(Speed, 0, MaxSpeed);

        return removeY(inputDirection) * Speed;
    }

    private void checkMovimentoHorizontal()
    {
        float x = Input.GetAxis("Horizontal");
        if (Mathf.Abs(x) > 0)
        {
            deceleration = 0;
            Speed += Acceleration * Time.deltaTime;
        }
        else if (deceleration == 0)
        {
            deceleration = Speed * (1 / SecondsToStop);
        }
        if (deceleration > 0)
        {
            Speed -= deceleration * Time.deltaTime;
        }

        Speed = Mathf.Clamp(Speed, 0, MaxSpeed);

        rb.velocity = removeY(cameraTransform.right) * Speed;
    }

    private Vector3 removeY(Vector3 vector) {
        return new Vector3(vector.x, 0, vector.z);
    }

    void checkHozontalDirection()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            directionX = 1;
        }
        else if (x < 0)
        {
            directionX = -1;
        }
    }

    void checkVerticalDirection()
    {
        float y = Input.GetAxis("Vertical");
        if (y > 0)
        {
            directionY = 1;
        }
        else if (y < 0)
        {
            directionY = -1;
        }
    }
}
