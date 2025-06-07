using Unity.VisualScripting;
using UnityEngine;
using MyTimer;

namespace Fabrick
{
    public class BolonFabrick
    {

        private static MyTimer.Timer _BalonSpavnTimer = new MyTimer.Timer();
        private static float _SpavnTime = 3;
        private static int _MaxBolonSpavn;

        // перенести рандом цвета на шарик и производить шарики 
        public static void BalonSpavn() =>
            GameObject.Instantiate(Resources.Load("Prefabs/Red Balloon"),
                new Vector2(0, -8.55f), Quaternion.identity)
                .GetComponent<Bolon>().Init();

        public static void StartFactory()
        {
            for (int i = 0; i <= Random.Range(2, _MaxBolonSpavn); i++)
            {
                BalonSpavn();
            }

            if (_SpavnTime > 1.6f) _SpavnTime -= 0.03f;
            else if (_MaxBolonSpavn > 2) _MaxBolonSpavn--;

            _BalonSpavnTimer.Start(_SpavnTime, () => StartFactory());
        }

        public static void StopFactory() 
        {
            _BalonSpavnTimer.Kill();
        }
    }
}