using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[System.Serializable]
public class DataController
{
    public float totalSpent;
    public List<ExpensesInfoSave> expensesInfoSave;


    public DataController()
    {
        totalSpent = TrackMoney.totalSpent;
        expensesInfoSave = new List<ExpensesInfoSave>();
        expensesInfoSave = TrackMoney.expensesInfoSavesList;
    }
}
