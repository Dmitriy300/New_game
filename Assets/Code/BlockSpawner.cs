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
    private void Start()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        float horizontalspacing = 0.3f; // Расстояние между блоками
        float verticalSpacing = 0.3f;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 blockPosition = new Vector3(startingX + column * (blockWidth + horizontalspacing),startingY - row * (blockHeight + verticalSpacing),0);

                // Вывод расстояния между текущим и следующим блоком
                if (column < columns - 1) // Проверяем, есть ли следующий блок в строке
                {
                    float distance = blockWidth + horizontalspacing + verticalSpacing;
                    
                }

                Quaternion blockRotation = Quaternion.Euler(0, 0, 0); // Угол поворота блока по умолчанию
                GameObject block = Instantiate(blockPrefab, blockPosition, blockRotation);

                if (row < rowColors.Length) // Обеспечиваем, что индекс не выходит за пределы массива
                {
                    Color blockColor = rowColors[row];
                    block.GetComponent<Renderer>().material.color = blockColor; // Устанавливаем цвет блока
                }

                
            }
        }
    }
}
