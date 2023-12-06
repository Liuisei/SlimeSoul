using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    int _money = 0;


    // アクションのデリゲートを定義
    public Action<int> OnMoneyChanged;

    protected override void AwakeFunction()
    {

    }




    public bool MoneyChanger(int value)
    {
        if (_money + value > 100000000)
        {
            Debug.LogWarning("Max Maney error");

            _money = 10000000;
            OnMoneyChanged?.Invoke(_money);

            return true;
        }
        else if (_money + value < 0)
        {
            Debug.Log("No Maney !");

            return false;
        }
        else
        {
            Debug.Log("Change !");

            _money += value;
            OnMoneyChanged?.Invoke(_money);// アクションが登録されていれば呼び出す

            return true;
        }
    }


    /// <summary>
    /// Geter
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return _money;
    }

}