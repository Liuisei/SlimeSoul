using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Money用TMP")]
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

    public void UpdateGameMoney(int money)     // 画面上の金を更新するメソッド
    {
        foreach (var textMeshProUGUI in textMeshProUGUIsMoney)
        {
            textMeshProUGUI.text = money.ToString();
        }
    }

}
