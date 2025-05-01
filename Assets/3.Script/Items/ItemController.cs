using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moveDirection;

    public void Initialize(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}