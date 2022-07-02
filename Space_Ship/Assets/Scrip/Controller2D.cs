using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public Transform Player;
    
    public float speed = 6f;
    public float JumpHeight;
    public float GravityValue;
    public float SphereRadius;
    public float JumpLimit = 2;
    public LayerMask layerMask;

    //public Rigidbody rb;
    public Vector3 Vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //Character Move(Left,Right)
        direction = Player.position;
        direction.y = direction.y - 1f;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero)
        {
            transform.right = move;
        }

        /*float horizontal = Input.GetAxis("Horizontal");
        direction.x = horizontal * speed;

        controller.Move(direction * Time.deltaTime);*/

        //Jump
        Vec.y += GravityValue * Time.deltaTime;
        controller.Move(Vec * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && JumpLimit > 1)
        {
            Vec.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
            JumpLimit -= 1;
            Debug.Log("Jump");
        }

        //CheckGround
        if (Physics.CheckSphere(direction, SphereRadius, layerMask))
        {
            JumpLimit = 2;
            Debug.Log("Yo");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(direction, SphereRadius);
    }

    /*void JumpMovement()
    {
        isGrounded = (Physics.CheckSphere(transform.position, SphereRadius));
        if(isGrounded && Vec.y < 0)
        {
            Vec.y = 0;
        }

        Vec.y += GravityValue * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vec.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
            Debug.Log("Jump");
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
