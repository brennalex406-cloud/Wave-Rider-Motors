using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            SceneManager.LoadScene("Win");
        }
        if (collision.gameObject.tag == "Player 2")
        {
            SceneManager.LoadScene("Lose");
        }
    } 
}
