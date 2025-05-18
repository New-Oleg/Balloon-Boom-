using Fabrick;
using UnityEngine;
using MyTimer;

public class MainController
{
    private BolonFabrick _bolonFabrick = new BolonFabrick();

    private Bolon _bolon;
    private Timer _SpeedMultiplayTimer = new Timer();

    private float _SpavnTime = 0;
    private Timer _BalonSpavnTimer = new Timer();


    public MainController(float spavnTime)
    {
        _SpavnTime = spavnTime;
    }

    public void StarTimer()
    {
        CompleatSpeedTimer();
        BolonSpavnMultiplai();
    }

    private void CompleatSpeedTimer()
    {
        _SpeedMultiplayTimer.Start(30f, () => _bolon.SpeedMultipli());
    }

    private void BolonSpavnMultiplai()
    {
        for (int i = 0; i <= Random.Range(2, 4); i++)
        {
            _bolonFabrick.BalonSpavn();
        }

        if (_SpavnTime > 1f) _SpavnTime -= 0.03f;

        _BalonSpavnTimer.Start(_SpavnTime, () => BolonSpavnMultiplai());
    }
}
