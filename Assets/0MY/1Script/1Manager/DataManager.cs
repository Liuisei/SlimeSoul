using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    int _money = 0;


    // �A�N�V�����̃f���Q�[�g���`
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
            OnMoneyChanged?.Invoke(_money);// �A�N�V�������o�^����Ă���ΌĂяo��

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