using Fabrick;
using UnityEngine;
using MyTimer;

public class MainController
{

    private Bolon _bolon;
    private Timer _SpeedMultiplayTimer = new Timer();

  

    public void StarTimer()
    {
        CompleatSpeedTimer();
        BolonFabrick.StartFactory();
        BombFabrick.StartFactory();
    }

    private void CompleatSpeedTimer()
    {
        _SpeedMultiplayTimer.Start(30f, () => _bolon.SpeedMultipli());
    }
    
}
