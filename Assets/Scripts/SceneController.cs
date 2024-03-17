using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{   
    [SerializeField] private int gridRows=0;
    [SerializeField] private int gridColumns=0;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private Text counterText;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject baseBlock;
    [SerializeField] private GameObject[] Block;

    private int BlockIndex;
    private int _blockCount;

    private void Awake()
    {
        _blockCount = gridRows * gridColumns;
        Debug.Log(_blockCount);
        SetText(_blockCount);
    }
    void Start()
    {
        Vector3 StartPosition = baseBlock.transform.position;   
        for (int i = 0; i< gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                GameObject part;
                BlockIndex = Random.Range(0, Block.Length);
                if (i==0 && j==0)
                {
                    part= baseBlock;  
                    part.transform.SetParent(transform, false);
                }
                else
                {
                    part = Instantiate(Block[BlockIndex]) as GameObject;
                    part.transform.SetParent(transform, false);
                }
                float PosX = StartPosition.x + (offsetX*i); 
                float PosY = StartPosition.y + (offsetY * j);
                part.transform.position = new Vector3(PosX, PosY, StartPosition.z);
            }
        }
    }
    
    public void BlockOnHit()
    {
        _blockCount--;
        SetText(_blockCount);
        if ( _blockCount <= 0)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void SetText(int count)
    {
        counterText.text = $"Blocks: {count}";   
    }
}
