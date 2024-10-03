using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 8f;
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(moveHorizontal * speed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);
        
        transform.position = newPosition;
    }
}
