using UnityEngine;

public interface IThrowable
{
    void Throw(Vector3 direction);
}

public interface ITakeable
{
    void Take(Transform parent);
    void Drop();
}



