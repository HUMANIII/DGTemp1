using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TraceTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float stopDistance = 1f;
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

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float dis = dir.magnitude;
        if (dis > distance || dis < stopDistance)
        {
            if(rb.linearVelocityX != 0)
            {
                rb.linearVelocityX = 0;
            }
            return;
        }

        float dirX = dir.x > 0 ? 1 : -1;

        rb.linearVelocityX = dirX * MoveSpeed;
    }
}
