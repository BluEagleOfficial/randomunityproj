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
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (hp < 1)
        {
            dead = true;
        }
    }


}
