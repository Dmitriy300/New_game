using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BlockSpawner blockSpawner; // Ссылка на спавнер блоков
    public BallController ballController; // Ссылка на контроллер мяча
    public PaddleController paddleController; // Ссылка на контроллер ракетки
    
    private bool gameStarted = false; // Флаг начала игры
    private List<GameObject> blocks; // Список блоков

    private void Start()
    {
        
        blocks = blockSpawner.SpawnBlocks(); // Запустить и сохранить спавн блоков
    }

    private void Update()
    {
        // Запустите игру при нажатии пробела
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        // Проверка условия окончания игры
        if (ballController.GameOver)
        {
            GameOver();
        }

        // Проверка, остались ли блоки
        if (blocks.Count == 0 && gameStarted)
        {
            RestartGame();
        }
    }

    private void StartGame()
    {
        gameStarted = true; // Установите флаг начала игры
        ballController.LaunchBall(); // Запустить мяч
        
    }

    private void GameOver()
    {
        gameStarted = false; // Обнуление флага
              
        
    }

    private void RestartGame()
    {
        foreach (var block in blocks)
        {
            Destroy(block); // Удалить все блоки
        }

        blocks = blockSpawner.SpawnBlocks(); // Повторно создать блоки
        gameStarted = false; // Сбросить флаг
    }

    // Этот метод вызывается при уничтожении блока
    public void RemoveBlock(GameObject block)
    {
        blocks.Remove(block); // Удалить блок из списка
        
    }
}
