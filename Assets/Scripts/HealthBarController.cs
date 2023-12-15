using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private float maxValue;
    [Header("Health Bar Visual Components")]
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform modifiedBar;
    [SerializeField] private float changeSpeed;

    public float currentValue;
    private float _fullWidth;
    private float TargetWidth => currentValue * _fullWidth / maxValue;
    private Coroutine updateHealthBarCoroutine;
    public int damage;

    public event Action<float> OnLifeUpdated;
    public event Action OnPlayerDeath;
    private void Start()
    {
        if (GetComponent<PlayerController>() != null)
        {
             maxValue = GetComponent<PlayerController>().GetLife();
        }else if(GetComponent<EnemyController>() != null)
        {
            maxValue = GetComponent<EnemyController>().GetLife();
        }        
        currentValue = maxValue;
        _fullWidth = healthBar.rect.width;
    }

    public void UpdateHealth(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);

        if (updateHealthBarCoroutine != null)
        {
            StopCoroutine(updateHealthBarCoroutine);
        }
        updateHealthBarCoroutine = StartCoroutine(AdjustWidthBar(amount));

        if (currentValue <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }
   

    IEnumerator AdjustWidthBar(float amount)
    {
        RectTransform targetBar = amount >= 0 ? modifiedBar : healthBar;
        RectTransform animatedBar = amount >= 0 ? healthBar : modifiedBar;

        targetBar.sizeDelta = SetWidth(targetBar, TargetWidth);

        while (Mathf.Abs(targetBar.rect.width - animatedBar.rect.width) > 1f)
        {
            animatedBar.sizeDelta = SetWidth(animatedBar, Mathf.Lerp(animatedBar.rect.width, TargetWidth, Time.deltaTime * changeSpeed));
            yield return null;
        }

        animatedBar.sizeDelta = SetWidth(animatedBar, TargetWidth);
    }

    private Vector2 SetWidth(RectTransform t, float width)
    {
        return new Vector2(width, t.rect.height);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyController>() != null)
            {
                OnLifeUpdated?.Invoke(collision.GetComponent<EnemyController>().GetDamage());
            }else if(collision.GetComponent<BulletController>()!= null)
            {
                OnLifeUpdated?.Invoke(collision.GetComponent<BulletController>().damage);
            }
            
            collision.GetComponent<EnemyController>().setLife(currentValue);
        }
        if (collision.gameObject.tag == "Player")
        {
            OnLifeUpdated?.Invoke(collision.GetComponent<PlayerController>().GetDamage());
            collision.GetComponent<PlayerController>().setLife(currentValue);
        }
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "Enemy")
        {
            OnLifeUpdated?.Invoke(collision.GetComponent<BulletController>().damage);
            Debug.Log(collision.GetComponent<BulletController>().damage);
            Debug.Log(collision.GetComponent<EnemyController>());
            collision.GetComponent<EnemyController>().setLife(currentValue);
        }
    }
}
