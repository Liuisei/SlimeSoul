using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Money�pTMP")]
    [SerializeField] List<TextMeshProUGUI> textMeshProUGUIsMoney = new List<TextMeshProUGUI>();

    protected override void AwakeFunction()
    {

    }

    private void OnEnable()
    {
        Invoke("SetDelegete",1f);       
    }
    void SetDelegete()
    {
        DataManager.Instance.OnMoneyChanged += UpdateGameMoney;

        DataManager.Instance.MoneyChanger(10);
    }

    public void UpdateGameMoney(int money)     // ��ʏ�̋����X�V���郁�\�b�h
    {
        foreach (var textMeshProUGUI in textMeshProUGUIsMoney)
        {
            textMeshProUGUI.text = money.ToString();
        }
    }

}
