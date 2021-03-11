using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Switch : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject bullet, player,door;
    public float bulletSpeed;
    public bool Isdoor, Canshoot;
    public float timeToFire;
    public AudioSource laserSound;

    private void Update()
    {
        if(Canshoot== true)
        {
            if (timeToFire <= 0)
            {
                laserSound.Play();
                for (int i = 0; i < spawnPoints.Length; i++)
                {

                    GameObject temp = Instantiate(bullet, spawnPoints[i].transform.position, Quaternion.identity);
                    timeToFire = 2f;
                }
            }
            else
            {
                timeToFire -= Time.deltaTime;
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            Canshoot = true;

        }

        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("DoorSwitch"))
        {
            Isdoor = true;

            if (Isdoor == true)
            {
                Debug.Log("Door Opened");
                player.GetComponent<PlayerMovement>().enabled = false;
                door.GetComponent<MeshRenderer>().material.color = Color.green;
                door.GetComponent<Door>().Cango = true;
                Isdoor = false;
            }
        }

    }

}
