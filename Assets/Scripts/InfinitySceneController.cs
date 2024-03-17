using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinitySceneController : MonoBehaviour
{

    [SerializeField] private int gridRows = 0;
    [SerializeField] private int gridColumns = 0;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    [SerializeField] private GameObject BaseBlock;
    [SerializeField] private GameObject[] Block;
    [SerializeField] private Text scoreText;
    private int BlockIndex;
    private int _blockCount;
    private int _scoreCount;
    private Vector3 StartPosition;

    private void Awake()
    {
        _blockCount = gridRows * gridColumns;
        Debug.Log(_blockCount);
        SetText(_scoreCount);
    }
    void Start()
    {
       StartPosition = BaseBlock.transform.position;
        SpawnBlocks(StartPosition);
    }

    private void SpawnBlocks(Vector3 StartPosition)
    {
        for (int i = 0; i < gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                GameObject Part;
                BlockIndex = Random.Range(0, Block.Length);
                if (i == 0 && j == 0)
                {
                    if (BaseBlock.activeSelf == false)
                    {
                        BaseBlock.SetActive(true);
                    }
                    Part = BaseBlock;
                    Part.transform.SetParent(transform, false);
                }
                else
                {
                    Part = Instantiate(Block[BlockIndex]) as GameObject;
                    Part.transform.SetParent(transform, false);
                }
                float PosX = StartPosition.x + (offsetX * i);
                float PosY = StartPosition.y + (offsetY * j);
                Part.transform.position = new Vector3(PosX, PosY, StartPosition.z);
            }
        }
    }

    public void BlockOnHit()
    {
        _blockCount--;
        _scoreCount++;
        SetText(_scoreCount);
        if (_blockCount <= 0)
        {
            _blockCount = gridRows * gridColumns;
            SpawnBlocks(StartPosition);
        }
    }
    private void SetText(int count)
    {
        scoreText.text = $"Score: {count}";
    }
}
