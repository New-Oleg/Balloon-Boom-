using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private RectTransform Buttons;
    [SerializeField]
    private Transform BackGround;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI HraltsText;

    private Tween _ButtonTween;
    private Tween _BackGroundTween;

    private int count;
    private bool _IsPlay;

    private MainController _MC = new MainController();
    private Healts _hp = new Healts(3);

    private void Start()
    {
        Bolon.bolonBoomCounter += countAdd;
        Bolon.bolonOverUp += HpLoss;

        Bomb.HealtsLoss += HpLoss;

        _ButtonTween =  Buttons.DOMoveY(-367.3f, 0.5f).Pause().SetAutoKill(false).OnComplete(() => _MC.StarTimers());
        _BackGroundTween = BackGround.DOMoveY(BackGround.position.y - 6.4f, 0.8f).Pause().SetAutoKill(false);
    }

    public void Play()
    {
        _IsPlay = true;
        _ButtonTween.PlayForward();
        _BackGroundTween.PlayForward();
        HraltsText.gameObject.SetActive(true);
        _hp = new Healts(3);
        HraltsText.text = _hp.GetHp() + "";
    }


    private void Update()
    {
        if (_hp.GetHp() <= 0)
        {
            loos();
        }
    }

    public void loos()
    {
        _IsPlay = false; 
        HraltsText.gameObject.SetActive(false);
        _MC.StopTimers();
        _ButtonTween.PlayBackwards();
        _BackGroundTween.PlayBackwards();
    }


    public void countAdd()
    {
        count++;
        text.text = count + "";
    }

    public void HpLoss()
    {
        _hp.HpLoss();
        if(_IsPlay)
        HraltsText.text = _hp.GetHp() + "";
    }

}