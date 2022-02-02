using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed= 2.0f;
    public float horizontalInput;
    public float verticalInput;
    //public Rigidbody rbody;
    private GameObject fpoint;
    public bool IsPowerUp=false;
    public float Strenght=4.0f;
    //public GameObject PowerIndicator; 
    void Start()
    {
       // rbody=GetComponent<Rigidbody>();
        fpoint= GameObject.Find("Focal Point");
    }
    // Update is called once per frame
    void Update()
    {
       // verticalInput= Input.GetAxis("Vertical");
        //rbody.AddForce(fpoint.transform.forward * verticalInput * speed);

        horizontalInput = Input.GetAxis("Horizontal");
        //rb.AddForce();
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        //rb.AddForce(Vector3.forward * verticalInput * speed);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
       // PowerIndicator.transform.position=(transform.position)+ new Vector3(0,-0.5f,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup")){
            IsPowerUp=true;
            Destroy(other.gameObject);
         //   PowerIndicator.gameObject.SetActive(true);
            StartCoroutine(CountDown());
        }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds(7);
        //PowerIndicator.gameObject.SetActive(false);
        IsPowerUp=false; 
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && IsPowerUp){
        Debug.Log("You hit an "+ collision.gameObject.name + "And your score is "+ IsPowerUp);
      //  Rigidbody EnemyRigidbody= collision.gameObject.GetComponent<Rigidbody>();
       // Vector3 pos=(EnemyRigidbody.transform.position- transform.position);
        //EnemyRigidbody.AddForce(pos*Strenght,ForceMode.Impulse);
        }
    }    
}
