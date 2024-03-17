using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform spawn;
    [SerializeField] private Text lifeCounterText;
    [SerializeField] private GameObject gameOverMenu;

    private int lifeCounter=3;
    private Transform tr;
    private Rigidbody2D rb;
    
    private void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        lifeCounterText.text = $"balls: {lifeCounter}";
        StartCoroutine(RestartTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("killZone"))
        {
            rb.velocity = Vector3.zero;
            tr.position = spawn.position;
            lifeCounter--;
            lifeCounterText.text = $"balls: {lifeCounter}";
            if (lifeCounter == 0)
            {
                GameOver();
            }
            else StartCoroutine(RestartTimer());

        }
    }

    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        StopAllCoroutines();
        this.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(1f);
        Drop();
    }
    private void Drop()
    {
        Vector3 moveDirection = new Vector3(speed, speed);
        moveDirection = Vector3.ClampMagnitude(moveDirection, speed);
        rb.velocity = moveDirection;
    }
}
