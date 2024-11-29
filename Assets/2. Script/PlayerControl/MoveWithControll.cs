using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        rb.linearVelocityX = Input.GetAxis("Horizontal") * speed;
    }
}
