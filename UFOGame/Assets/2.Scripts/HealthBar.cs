using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer bar;
    public float maxScale;
    public int healthMax;
    public int healthCur;

    private void OnEnable()
    {
        healthCur = healthMax;

        Vector3 barScale = bar.transform.localScale;
        barScale.x = maxScale;
        bar.transform.localScale = barScale;
    }

    public void Decrease()
    {
        if(healthCur > 0)
        {
            healthCur--;

            Vector3 barScale = bar.transform.localScale;
            barScale.x = (float)healthCur / healthMax * maxScale;
            bar.transform.localScale = barScale;
        }
    }
}
