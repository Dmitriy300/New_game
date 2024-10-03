using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = 10.0f;
    public int lives = 3;
    public Transform paddle;
    public AudioClip hitSoundBall;
    public AudioClip hitSoundBlock;
    private Rigidbody _rigidbody;
    private bool _isPlaying = false;
    private AudioSource _audioSource;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.zero;
        RespawnBall();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isPlaying)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        _rigidbody.velocity = new Vector3(speed, speed, 0);
        _isPlaying = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector3 ballDirection = new Vector3(Random.Range(-1f, 1f), 1f, 0).normalized;
            _rigidbody.velocity = ballDirection * speed;
            _audioSource.PlayOneShot(hitSoundBall);
        }

        else if (collision.gameObject.CompareTag("Bottom"))
        {
            MissedBall();
        }

        else if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject); 
            Vector3 bounceDirection = Vector3.Reflect(_rigidbody.velocity.normalized, collision.contacts[0].normal);
            _rigidbody.velocity = bounceDirection * speed;
            _audioSource.PlayOneShot(hitSoundBlock);
        }
    }

    private void MissedBall()
    {
        lives--; 
        
        if (lives <= 0)
        {
            EndGame();
        }
        else
        {
            RespawnBall(); 
        }
    }

    private void RespawnBall()
    {
        transform.position = paddle.position + new Vector3(0, 0, 0); 
        _rigidbody.velocity = Vector3.zero; 
        _isPlaying = false; 
    }

    private void EndGame()
    {
        Debug.Log("Game Over");

    }
}

