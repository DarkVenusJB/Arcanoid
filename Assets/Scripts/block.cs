using UnityEngine;

public class block : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer RedBlock;
    [SerializeField] private SpriteRenderer GreyBlock;
    [SerializeField] private SpriteRenderer PurpleBlock;
    [SerializeField] private bool infinityLevel;

    private SpriteRenderer BlockColor;
    private SceneController sceneController;
    private InfinitySceneController infinitySceneController;

    private void Start()
    {
        if (infinityLevel)
            infinitySceneController = GetComponentInParent<InfinitySceneController>();
        else
            sceneController = GetComponentInParent<SceneController>();

        BlockColor = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BlockColor.color == RedBlock.color)
        {
            if (infinityLevel)
                infinitySceneController.BlockOnHit();
            else
                sceneController.BlockOnHit();
            if (collision.gameObject.CompareTag("baseBlock"))
            {
                collision.gameObject.SetActive(false);
                Debug.Log("baseBLock");
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (BlockColor.color == PurpleBlock.color)
        {
            BlockColor.color = RedBlock.color;
        }
        else if (BlockColor.color ==  GreyBlock.color)
        {
            BlockColor.color = PurpleBlock.color;
        }
    }
}
