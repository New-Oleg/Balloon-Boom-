using Unity.VisualScripting;
using UnityEngine;

public class BombFabrick
{
    private static MyTimer.Timer _BombSpavnTimer = new MyTimer.Timer();
    private static float _maxSpavnTime = 5f;

    public static void Spavn() =>
            GameObject.Instantiate(Resources.Load("Prefabs/Bomb"),
                new Vector2(0, -8.55f), Quaternion.identity)
                .GetComponent<Bomb>().Init();

    public static void StartFactory()
    {
        Spavn();
        _BombSpavnTimer.Start(Random.Range(1f, _maxSpavnTime),() => StartFactory());
    }
}
