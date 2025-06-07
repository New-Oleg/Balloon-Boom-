using Fabrick;
using UnityEngine;
using MyTimer;

public class MainController
{

    private Bolon _bolon;
    private Timer _SpeedMultiplayTimer = new Timer();

  

    public void StarTimers()
    {
        CompleatSpeedTimer();
        BolonFabrick.StartFactory();
        BombFabrick.StartFactory();
    }

    public void StopTimers()
    {
        BolonFabrick.StopFactory();
        BombFabrick.StopFactory();

        _SpeedMultiplayTimer.Kill();
    }

    private void CompleatSpeedTimer()
    {
        _SpeedMultiplayTimer.Start(30f, () => _bolon.SpeedMultipli());
    }
    
}
