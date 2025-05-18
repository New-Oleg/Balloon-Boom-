using UnityEngine;

public abstract class AEntety : MonoBehaviour
{
    public abstract void Init();

    public abstract void Move(); 

    public abstract void SpeedMultipli();

    public abstract void Boom();

    public abstract void OnMouseDown();
}
