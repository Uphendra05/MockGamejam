using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool Cango;

    private void Start()
    {
        Cango = false;
    }
    private void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(Cango == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
      
    }
}
