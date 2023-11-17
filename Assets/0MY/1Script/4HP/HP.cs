using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class HP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;        // HP�\���p��UI�e�L�X�g
    [SerializeField] Slider sliderHP;               // HPslider
    [SerializeField] int maxHP = 10;�@              // �ő�HP
    [SerializeField] int hp = 10;                   // ����HP
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool colorChange = true;
    public event Action HPChanged;
    /// <summary>         �ϐ�         </summary>///
    public virtual void Start()
    {
        UpdateHPText(); // �����l��HP�\�����X�V����
    }
    private void OnEnable()
    {
        HPChanged += UpdateHPText;
    }
    public void HPaddValue(int damageOrHeal)
    {
        hp += damageOrHeal;

        if (hp <= 0) HpUnder0();

        if (hp >= maxHP) HpOverMax();

        Debug.Log(this + "HIT");

        HPChanged?.Invoke(); // HP�@expression�\�����X�V����
    }

    void UpdateHPText()
    {
        if (sliderHP) sliderHP.value = (float)hp / (float)maxHP; // HP�̊������v�Z����

        if (hpText) hpText.text = "HP: " + hp.ToString(); // HP�̕\�����X�V����

        if (spriteRenderer != null && colorChange == true) spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)GetHP() / (float)GetMaxHP());
    }


    public virtual void HpUnder0()
    {
        Debug.Log("Die" + this);
    }
    public virtual void HpOverMax()
    {
        hp = maxHP;
    }
    public int GetHP()
    {
        return hp;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }
}