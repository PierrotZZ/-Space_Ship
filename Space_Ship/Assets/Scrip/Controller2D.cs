using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public Transform Player;
    //public Rigidbody rbPlayer;
    
    public float speed = 6f;
    public float rotationSpeed;
    public float JumpHeight;
    public float KnokUp;
    public float GravityValue;
    public float SphereRadius;
    public float JumpLimit = 2;

    public float Health = 3;

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
            //transform.right = move;
            Quaternion toRotation = Quaternion.LookRotation(-move, Vector3.right);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
            //Debug.Log("Jump");
        }

        //CheckGround
        if (Physics.CheckSphere(direction, SphereRadius, layerMask))
        {
            JumpLimit = 2;
            //Debug.Log("Yo");
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
        Vector3 knokback = new Vector3(-600, 500, 0);
        if( collision.collider.tag == "LoseHP")
        {
            Health = Health - 1;
            //Vec.y = Mathf.Sqrt(KnokUp * -3f * GravityValue);
            Debug.Log(Health);
        }
    }

    /*public IEnumerator knokback(float knokDur, float knokbackPwr, Vector3 knokbackDir)
    {
        float timer = 1;
        while (knokDur > timer)
        {
            timer += Time.deltaTime;
            rbPlayer.AddForce(new Vector3(knokbackDir.x * -100, knokbackDir.y * knokbackPwr, transform.position.z));
            Debug.Log(timer);
        }
        yield return 0;
    }*/
}
