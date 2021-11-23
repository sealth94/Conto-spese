using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ExpensesInfoSave
{
    public string expenseType;
    public float expenseAmmount;
    public string expenseCategory;
    public DateTime dateTime;

    /// <summary>
    /// Indica una spesa fatta in questo momento, e imposta la data attuale come riferimento
    /// </summary>
    public ExpensesInfoSave(float _expenseAmmount, string _expenseType, kindOfExpense _expenseCategory)
    {
        expenseType = _expenseType;
        expenseAmmount = _expenseAmmount;
        expenseCategory = _expenseCategory.ToString();
        dateTime = DateTime.Now;
    }

    /// <summary>
    /// Indica una spesa effettuata indicando quando è stata effettuata (oppure per una spesa rateizzata)
    /// </summary>
    public ExpensesInfoSave(float _expenseAmmount, string _expenseType, kindOfExpense _expenseCategory, DateTime _dateTime)
    {
        expenseType = _expenseType;
        expenseAmmount = _expenseAmmount;
        expenseCategory = _expenseCategory.ToString();
        dateTime = _dateTime;
    }
}
