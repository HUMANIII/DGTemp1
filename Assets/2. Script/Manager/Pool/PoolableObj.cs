using UnityEngine;

public abstract class PoolableObj : MonoBehaviour
{
    public void OnGet()
    {
        gameObject.SetActive(true);
        OnGetAction();
    }
    protected abstract void OnGetAction();

    public void OnRelease()
    {
        gameObject.SetActive(false);
        OnReleaseAction();
    }
    protected abstract void OnReleaseAction();
}
