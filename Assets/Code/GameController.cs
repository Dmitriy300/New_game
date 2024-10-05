using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BlockSpawner blockSpawner; 
    public BallController ballController; 
    public PaddleController paddleController; 
    
    private bool gameStarted = false;
    private List<GameObject> blocks; 

    private void Start()
    {
        blocks = blockSpawner.SpawnBlocks(); 
    }
    private void Update()
    {        
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
                
        if (ballController.GameOver)
        {
            GameOver();
        }
                
        if (blocks.Count == 0 && gameStarted)
        {
            RestartGame();
        }
    }
    private void StartGame()
    {
        gameStarted = true; 
        ballController.LaunchBall();        
    }
    private void GameOver()
    {
        gameStarted = false;   
    }
    private void RestartGame()
    {
        foreach (var block in blocks)
        {
            Destroy(block); 
        }

        blocks = blockSpawner.SpawnBlocks(); 
        gameStarted = false; 
    }
    public void RemoveBlock(GameObject block)
    {
        blocks.Remove(block);       
    }
}
