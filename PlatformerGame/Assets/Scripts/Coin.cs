using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 90f;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }
}