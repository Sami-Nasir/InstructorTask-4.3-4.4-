using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalInput;
    public float horizontalInput;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");      
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        //rb.AddForce();
        //rb.AddForce(Vector3.forward * verticalInput * speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && IsPowerUp)
        {
            Debug.Log("You hit an " + collision.gameObject.name + "And your score is " + IsPowerUp);
            Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pos = (EnemyRigidbody.transform.position - transform.position);
            EnemyRigidbody.AddForce(pos * Strenght, ForceMode.Impulse);
        }
    }
}
