using System;
using DG.Tweening;
using UnityEngine;

public class Bomb : AEntety
{
    private float _StartX;
    private Vector2 _MidPoint;
    private Vector2 _EndPoint;

    private Tween MoveTween;


    public static event Action HealtsLoss;

    public override void OnMouseDown()
    {
        Boom();
    }

    private void Start()
    {
        Move();
    }

    //--------------------------------------------------------------
    public override void Init()
    {
        transform.position = new Vector3(_StartX = UnityEngine.Random.Range(-3.45f, 3.45f), -8.55f);
        Move();
    }

    public override void Move()
    {
        float i;
        if (_StartX > 0)
        {
            _EndPoint = new Vector2(UnityEngine.Random.Range(_StartX - 0.1f, -3f), -8.55f);
        }
        else if (_StartX <= 0)
        {
            _EndPoint = new Vector2(UnityEngine.Random.Range(_StartX + 0.1f, -3f), -8.55f);
        }

        _MidPoint = ((Vector2)transform.position + _EndPoint) / 2 + Vector2.up * (i = UnityEngine.Random.Range(8.0f, 14.0f));
        Tween MoveTween = transform.DOPath(new Vector3[]
            {transform.position,
            _MidPoint,
            _EndPoint},
            _speed/2,
            PathType.CatmullRom)
            .SetEase(Ease.Linear)
            .OnComplete(() => Dead());
    }

    public override void Boom()
    {
        HealtsLoss.Invoke();
        MoveTween.Kill();
        gameObject.GetComponent<Animator>().SetBool("IsDead",true);
    }

    public override void SpeedMultipli()
    {
       // throw new System.NotImplementedException();
    }
}
