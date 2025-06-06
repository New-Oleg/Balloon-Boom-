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

    private int count;

    private MainController _MC = new MainController();
    private Healts _hp = new Healts(3);

    private void Start()
    {
        Bolon.bolonBoomCounter += countAdd;
        Bolon.bolonOverUp += HpLoss;

        Bomb.HealtsLoss += HpLoss;

        HraltsText.text = _hp.GetHp() + "";
    }

    public void Play()
    {
        Buttons.DOMoveY(-367.3f, 0.5f).OnComplete(() => _MC.StarTimer());
        BackGround.DOMoveY(BackGround.position.y - 6.4f, 0.8f);
    }


    public void countAdd()
    {
        count++;
        text.text = count + "";
    }

    public void HpLoss()
    {
        _hp.HpLoss();
        HraltsText.text = _hp.GetHp() + "";
    }

}