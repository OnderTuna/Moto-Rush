using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject centerOfMass;

    [Header ("Variables")]
    private float turnSpeed = 10.0f;
    private float horsePower = 1.75f;
    private float xBound = 6.5f;
    private float zBound = 5f;
    public float speed;
    private float rpm;
    private float verticalInput;
    private float horizontalInput;

    [Header("Effects")]
    public ParticleSystem explosionParticle;
    public ParticleSystem flameParticle;
    public ParticleSystem pointParticle;

    [Header("Audios")]
    public AudioSource pointSound;
    public AudioSource crashSound;
    public AudioSource bombSound;

    [Header("Texts")]
    public TextMeshProUGUI speedometerText;
    public TextMeshProUGUI rpmText;

    private GameManager gameManagerScripti;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
        gameManagerScripti = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Boundry();

        if (gameManagerScripti.isGameActive == true)
        {
            KeepMoving();
        }

        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        if(speed <= 150)
        {
            speedometerText.text = "Speed: " + speed + "kph";
        }
        else
        {
            speedometerText.text = "Speed: " + "150" + "kph";
        }

        rpm = (speed % 30) *40;
        rpmText.text = "RPM: " + rpm; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            crashSound.Play();
            bombSound.Play();
            explosionParticle.Play();
            flameParticle.Play();
            gameManagerScripti.isGameActive = false;
            gameManagerScripti.GameOver();
        }

        if (collision.gameObject.CompareTag("Point"))
        {
            gameManagerScripti.UpdateScore(5);
            pointParticle.Play();
            pointSound.Play();
            Destroy(collision.gameObject);
        }
    }

    void Boundry()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    void KeepMoving()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddRelativeForce(horsePower * verticalInput * Vector3.left);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
