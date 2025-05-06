using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Making Movement again
    public float speed = 10f;
    public float health = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementFunction();
    }

    void MovementFunction()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

       if (Input.GetKey(KeyCode.D))
        {
            transform.position -= Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        { transform.position -= Vector3.right * speed * Time.deltaTime; }
    }
}
