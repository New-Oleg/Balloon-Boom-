using UnityEngine;

public abstract class AEntety : MonoBehaviour
{
    [SerializeField]
    protected Sprite[] sprites;

    protected static float _speed = 10;
    public abstract void OnMouseDown();
    public abstract void Init();

    public abstract void Move(); 

    public abstract void SpeedMultipli();

    public abstract void Boom();

    public void Dead() => Destroy(gameObject);

}
