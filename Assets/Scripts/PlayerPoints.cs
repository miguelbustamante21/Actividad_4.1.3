/*
Keep track of the points collected by the player
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] int points = 30;
    [SerializeField] Text pointsText;
    [SerializeField] SpriteRenderer colorRenderer;
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] float flashStep;  
    
    void Start()
    {
        // Initiate score
        pointsText.text = "Score: " + points;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            points--;
            pointsText.text = "Score: " + points;
            // Start a new process to animate the flasing plane
            StartCoroutine(Flash());
        }
        else if (col.gameObject.tag == "Portal") {
            points++;
            pointsText.text = "Score: " + points;
            // Start a new process to animate the flasing plane
            StartCoroutine(Flash());
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            points -= 5;
            transform.position = new Vector3(0, 0, 0);
        }
        else if (col.gameObject.tag == "Portal") {
            points += 5;
            transform.position = new Vector3(0, 0, 0);
        }
        pointsText.text = "Score: " + points;
    }

    // This method must be of type IEnumerator to be able to wait
    IEnumerator Flash()
    {
        Color newColor;
        for (int i=0; i<5; i++) {
            newColor = Color.Lerp(startColor, endColor, i/5.0f);
            colorRenderer.color = newColor;
            // Sleep this process for some time
            yield return new WaitForSeconds(flashStep);
        }
        for (int i=0; i<5; i++) {
            newColor = Color.Lerp(endColor, startColor, i/5.0f);
            colorRenderer.color = newColor;
            // Sleep this process for some time
            yield return new WaitForSeconds(flashStep);
        }
        colorRenderer.color = startColor;
    }
}
