using System;
using DG.Tweening;
using UnityEngine;

public class Bolon : AEntety
{
    public static event Action bolonBoomCounter;
    public static event Action bolonOverUp;

    private float _waveAmplitude; // радиус колебаний
    private float _waveFrequency; //частота колебаний 

    private Tween TweenY, TweenX;

    public override void OnMouseDown()
    {
        bolonBoomCounter.Invoke();
        Boom();
    }

    //--------------------------------------------------------------

    //вызывает фабрика при создании
    public override void Init()
    {
        _waveAmplitude = UnityEngine.Random.Range(0.7f, 1f);
        _waveFrequency = UnityEngine.Random.Range(1f, 1.5f);
        transform.position = new Vector3(UnityEngine.Random.Range(-3.45f, 3.45f), -8.55f);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        Move();
    }


    public override void Move()
    {
        // движение вверх
        TweenY = transform.DOMove(new Vector2(transform.position.x, 9.37f), _speed)
            .SetEase(Ease.Linear)
            .OnComplete(() => bolonOverUp.Invoke());

        // Колебания по X вручную в Update
        TweenX = DOTween.To(() => 0f, x =>
        {
            float newX = Mathf.Sin(Time.time * _waveFrequency * Mathf.PI * 2) * _waveAmplitude;
            transform.position = new Vector3(transform.position.x + newX, transform.position.y, transform.position.z);
        }, 0f, _speed).SetEase(Ease.Linear)
            .OnComplete(() => Dead());

    }

    public override void SpeedMultipli() => _speed += 0.5f;

    // уничтожение шарика
    public override void Boom() 
    {
        TweenY.Kill();
        TweenX.Kill();
        gameObject.GetComponent<Animator>().SetBool("IsDead", true);
    }
}
