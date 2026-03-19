using UnityEngine;

public class MoveTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * 5f * Time.deltaTime;
        }
    }
}