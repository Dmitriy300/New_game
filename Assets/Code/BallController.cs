using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public Transform paddle;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // Устанавливаем позицию шара на платформе в начале игры
        transform.position = paddle.position + new Vector3(0, 0.5f, 0); // На пару юнитов выше платформы
    }

    private void Update()
    {
        // Запускаем шар по нажатию пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }
    void LaunchBall()
    {
        float randomAngle = Random.Range(-45f, 45f);
        Vector3 direction = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), 0, Mathf.Sin(randomAngle * Mathf.Deg2Rad));
        _rigidbody.velocity = direction * speed;
    }
}
