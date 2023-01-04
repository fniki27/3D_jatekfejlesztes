using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveInDirection;
    private Vector3 newPosition;

    public float forwardSpeed;
    public static float increaseSpeed = 0.1f;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance;
    public float jumpForce;
    public float gravity;
    public static bool isGameOver = false;
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    AudioSource audioSource;
    public AudioClip jumpSound, crashSound, coinSound;

    private void Start()
    {
        isGameOver = false;
        forwardSpeed = 6;
        score = 0;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isGameOver || PauseMenu.gameIsPaused)
            return;

        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += increaseSpeed * Time.deltaTime;
        }

        moveInDirection.z = forwardSpeed;
        controller.Move(moveInDirection * Time.fixedDeltaTime);

        if (controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(jumpSound);
                Jump();
            }
        }
        else
        {
            moveInDirection.y += gravity * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        newPosition =  transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            newPosition += Vector3.left * laneDistance;
        }

        if (desiredLane == 2)
        {
            newPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, 60 * Time.deltaTime);

    }

    private void Jump ()
    {
        moveInDirection.y = jumpForce;
        anim.SetTrigger("Jump");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isGameOver || PauseMenu.gameIsPaused)
           return;

        if (hit.gameObject.tag == "Obstacle")
        {
            isGameOver = true;
            anim.SetBool("Dead",true);
            audioSource.PlayOneShot(crashSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
            score++;
            scoreText.SetText("Score: " + score);
        }
    }

}

