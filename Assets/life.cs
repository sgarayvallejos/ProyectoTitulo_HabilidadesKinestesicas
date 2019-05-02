using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    public Image healthy;
    float hp, maxHP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void voidTakeBadAliment(float amount)
    {
        hp = Mathf.Clamp(hp-amount, 0f, maxHP);
        healthy.transform.localScale = new Vector2(hp/maxHP, 1);
 
    }
}
