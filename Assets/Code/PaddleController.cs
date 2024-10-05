using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 6f;
    public BlockSpawner blockSpawner;
    private void Start()
    {        
        if (blockSpawner != null)
        {
            boundary = (blockSpawner.columns * (blockSpawner.blockWidth + 0.3f) / 2) - (blockSpawner.blockWidth / 2);
        }       
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * moveHorizontal * speed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);
        transform.position = newPosition;
    }
}
