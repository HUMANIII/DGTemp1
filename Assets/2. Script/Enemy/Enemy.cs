using UnityEngine;

public class Enemy : PoolableObj, IDestructable
{
    protected override void OnGetAction()
    {
    }

    protected override void OnReleaseAction()
    {
    }

    public void OnDestruct()
    {
        PoolManager.Instance.Release(this);
    }
}
