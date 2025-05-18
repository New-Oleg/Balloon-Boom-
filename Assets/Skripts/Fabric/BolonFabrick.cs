using Unity.VisualScripting;
using UnityEngine;

namespace Fabrick
{
    public class BolonFabrick
    {
        // перенести рандом цвета на шарик и производить шарики 
        public void BalonSpavn() =>
            GameObject.Instantiate(Resources.Load("Prefabs/Red Balloon"),
                new Vector2(0, -8.55f), Quaternion.identity)
                .GetComponent<Bolon>().Init();
        
    }
}