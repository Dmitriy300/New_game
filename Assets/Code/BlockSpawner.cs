using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Префаб блока
    public int rows = 5; // Количество рядов
    public int columns = 8; // Количество колонн
    public float blockWidth = 1.0f; // Ширина блока
    public float blockHeight = 0.5f; // Высота блока
    public float startingX = -7f; // Начальная позиция по X
    public float startingY = 4f; // Начальная позиция по Y

    public Color[] rowColors;

    private List<GameObject> spawnedBlocks = new List<GameObject>();

    private void Start()
    {
        SpawnBlocks();
    }

    public List<GameObject> SpawnBlocks()
    {
        ClearBlocks();
              
        float horizontalspacing = 0.3f; // Расстояние между блоками
        float verticalSpacing = 0.3f;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 blockPosition = new Vector3(startingX + column * (blockWidth + horizontalspacing), startingY - row * (blockHeight + verticalSpacing), 0);

                Quaternion blockRotation = Quaternion.Euler(0, 0, 0); // Угол поворота блока по умолчанию
                GameObject block = Instantiate(blockPrefab, blockPosition, blockRotation);
                spawnedBlocks.Add(block);

                // Вывод расстояния между текущим и следующим блоком
                if (column < columns - 1) // Проверяем, есть ли следующий блок в строке
                {
                    float distance = blockWidth + horizontalspacing + verticalSpacing;

                }
                
                if (row < rowColors.Length) // Обеспечиваем, что индекс не выходит за пределы массива
                {
                    Color blockColor = rowColors[row];
                    block.GetComponent<Renderer>().material.color = blockColor; // Устанавливаем цвет блока
                }
                

            }
        }

        return spawnedBlocks;
        
    }
    public void ClearBlocks()
    {
        foreach (GameObject block in spawnedBlocks)
        {
            Destroy(block); // Уничтожить блоки
        }
        spawnedBlocks.Clear(); // Очистить список
    }
    public void RemoveBlock(GameObject block)
    {
        // Убрать блок из списка в GameController
        FindObjectOfType<GameController>().RemoveBlock(block);
    }
}

