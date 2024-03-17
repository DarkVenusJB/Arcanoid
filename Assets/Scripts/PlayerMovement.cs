using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float Speed = 7f;
    private Transform T;
    private Vector3 MoveDirection = Vector3.zero;

    private void Start()
    {
        T = GetComponent<Transform>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            MoveDirection = new Vector3(horizontal * Speed, 0f, 0f);
            T.Translate(MoveDirection * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            MoveDirection = Vector3.zero;
        }
    }
}