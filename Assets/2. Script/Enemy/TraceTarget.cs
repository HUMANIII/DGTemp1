using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TraceTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float MoveSpeed;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude > distance)
        {
            return;
        }

        dir.Normalize();
        rb.linearVelocity = dir * MoveSpeed;
    }
}
