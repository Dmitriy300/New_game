using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // ������ �����
    public int rows = 5; // ���������� �����
    public int columns = 8; // ���������� ������
    public float blockWidth = 1.0f; // ������ �����
    public float blockHeight = 0.5f; // ������ �����
    public float startingX = -7f; // ��������� ������� �� X
    public float startingY = 4f; // ��������� ������� �� Y

    public Color[] rowColors;
    private void Start()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        float horizontalspacing = 0.3f; // ���������� ����� �������
        float verticalSpacing = 0.3f;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 blockPosition = new Vector3(startingX + column * (blockWidth + horizontalspacing),startingY - row * (blockHeight + verticalSpacing),0);

                // ����� ���������� ����� ������� � ��������� ������
                if (column < columns - 1) // ���������, ���� �� ��������� ���� � ������
                {
                    float distance = blockWidth + horizontalspacing + verticalSpacing;
                    
                }

                Quaternion blockRotation = Quaternion.Euler(0, 0, 0); // ���� �������� ����� �� ���������
                GameObject block = Instantiate(blockPrefab, blockPosition, blockRotation);

                if (row < rowColors.Length) // ������������, ��� ������ �� ������� �� ������� �������
                {
                    Color blockColor = rowColors[row];
                    block.GetComponent<Renderer>().material.color = blockColor; // ������������� ���� �����
                }

                
            }
        }
    }
}
