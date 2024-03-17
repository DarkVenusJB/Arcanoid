using System.Net.Http.Headers;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    private InfinitySceneController infinitySceneController;

    private void Start()
    {
        infinitySceneController = GetComponentInParent<InfinitySceneController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        infinitySceneController.BlockOnHit();
        gameObject.SetActive(false);

    }
}
