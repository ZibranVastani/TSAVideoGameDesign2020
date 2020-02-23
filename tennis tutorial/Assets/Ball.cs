using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos; // ball's initial position
    public int hitter;
    public GameObject scorecontroller;
    private void Start()
    {
        initialPos = transform.position; // default it to where we first place it in the scene
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.CompareTag("Wall")) ) // if the ball hits a wall
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            
            StartCoroutine(ExampleCoroutine("Wall"));

        }
        else if(collision.transform.CompareTag("Net"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            GetComponent<Rigidbody>().useGravity = false;
            StartCoroutine(ExampleCoroutine("Net"));
        }
        
    }
    IEnumerator ExampleCoroutine(string What)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        scorecontroller.GetComponent<ScoreController>().changeScore(What);
        transform.position = initialPos; // reset it's position 
        GetComponent<Rigidbody>().useGravity = true; 


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}