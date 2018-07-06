using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private Rigidbody2D rb2d;
    private bool hasStarted = false;
    private AudioSource ballAudio;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                rb2d = GetComponent<Rigidbody2D>();
                rb2d.velocity = new Vector2(0f, 10f);
            }
        }
    }
        

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            ballAudio = GetComponent<AudioSource>();
            ballAudio.Play();
            rb2d.velocity += tweak;
        }
    }
}
