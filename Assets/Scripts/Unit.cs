using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public Slider HPSlider;
    public int hp;
    int hpMax = 10;
    public int at;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
        at = 10;
    }

    public void OnDamage(int _damage)
    {
        hp -= _damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        HPSlider.value = hp;
    }
}
