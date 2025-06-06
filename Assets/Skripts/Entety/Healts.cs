using UnityEngine;

public class Healts
{
    private static int Hp;

    public int GetHp() => Hp;

    public Healts(int hp)
    {
        Hp = hp;
    }

    public void HpLoss()
    {
        Hp -= 1;
    }
}
