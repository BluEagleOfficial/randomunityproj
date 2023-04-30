using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxhp = 100;

    public int hp = 100;

    public bool dead = false;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            dead = true;
        }
    }
    public void healHp(int hpmore)
    {
        hp += hpmore;
        if (hp > maxhp)
        {
            hp = maxhp;
        }
    }


}
