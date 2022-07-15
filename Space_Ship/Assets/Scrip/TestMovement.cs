using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Vector3 TestCube = new Vector3(50, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 Move = new Vector3(TestCube.x * inputX, 0, 0);

        Move *= Time.deltaTime;

        transform.Translate(Move);
    }
}
