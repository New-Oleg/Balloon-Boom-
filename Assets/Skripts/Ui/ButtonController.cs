using DG.Tweening;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private RectTransform Buttons;
    [SerializeField]
    private Transform BackGround;

    private MainController _MC = new MainController(3);

    public void Play()
    {
        Buttons.DOMoveY(-367.3f, 0.5f).OnComplete(() => _MC.StarTimer());
        BackGround.DOMoveY(BackGround.position.y - 6.4f, 0.8f);
    }
}