using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    private float Num;

    Rigidbody ShipRigid;

    // Start is called before the first frame update
    void Start()
    {
        ShipRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        ShipRigid.velocity = transform.forward * Speed * Num;
        Num = Mathf.Clamp(Num, 0, 1);
        Debug.Log(Num);

        /*if (Input.GetKey(KeyCode.J))
        {
            Num += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            Num -= Time.deltaTime;
        }*/

        if (Input.GetKey(KeyCode.W))
        {
            ShipRigid.AddTorque(RotationSpeed * transform.right);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ShipRigid.AddTorque(-RotationSpeed * transform.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ShipRigid.AddTorque(RotationSpeed * transform.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ShipRigid.AddTorque(-RotationSpeed * transform.forward);
        }

        if (Input.GetKey(KeyCode.E))
        {
            ShipRigid.AddTorque(RotationSpeed * transform.up);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ShipRigid.AddTorque(-RotationSpeed * transform.up);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Num += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Num -= Time.deltaTime;
        }
    }
}
