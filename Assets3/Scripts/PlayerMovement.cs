using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 12f;                 
    public float TurnSpeed = 180f;
    public GameObject deadPlayer, startPos;
    private string MovemnetAxis;          
    private string TurnAxis;              
    private Rigidbody rb;              
    private float Movementinput;         
    private float TunrInput;
    public int deathCount = 2;

  
    private void Awake()
    {
       
       
        rb = GetComponent<Rigidbody>();
    }
   

    private void Start()
    {
        deathCount = 3;
        MovemnetAxis = "Vertical";
        TurnAxis = "Horizontal";
    }

   
    private void Update()
    {
        Movementinput = Input.GetAxis(MovemnetAxis);
        TunrInput = Input.GetAxis(TurnAxis);

       Move();       
       Turn();           
     
    } 
   


    private void Move()
    {
        Vector3 movement = transform.forward * Movementinput * Speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement );

       
    }


    private void Turn()
    {
        float turn = TunrInput * TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(deathCount >=2)
            {
                this.gameObject.SetActive(false);
                GameObject temp = Instantiate(deadPlayer, this.transform.position, this.transform.rotation);
                Invoke("RespawnPlayer", 1.5f);
                Destroy(other.gameObject);

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("You're dead");
            }
            
        }
    }

    public void RespawnPlayer()
    {
        GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = startPos.transform.position;
        deathCount--;

    }




}
