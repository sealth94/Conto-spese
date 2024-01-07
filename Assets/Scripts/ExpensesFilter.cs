using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ExpensesFilter : MonoBehaviour
{
    [SerializeField]
    TrackMoney trackMoney;


    [SerializeField]
    TMP_InputField fromDayText, fromMonthText, fromYearText, toDayText, toMonthText, toYearText, keywordText;
    [SerializeField]
    TMP_Text
    categoryText, totalText;

    DateTime from, to;
    kindOfExpense category;
    string total;

    bool isOk;

    string totalBeginning = "Spese nel periodo selezionato: ";

    public void FilterExpenses()
    {
        GetDateInfo();
        float spent = 0;
        isOk = false;

        foreach (var item in TrackMoney.data.expensesInfoSave)
        {
            DateTimeFilter(item);
            CategoryFilter(item);
            KeywordFilter(item);
            if (isOk)
                spent += item.expenseAmmount;
        }

        totalText.text = totalBeginning + "€ " + spent;
    }

    private void DateTimeFilter(ExpensesInfoSave item)
    { isOk = item.dateTime > from && item.dateTime < to; }

    private void CategoryFilter(ExpensesInfoSave item)
    {
        if (isOk)
        {
            if (categoryText.text.Equals("Tutto"))
                isOk = true;
            else
                isOk = item.expenseCategory.Equals(categoryText.text);
        }
    }

    private void KeywordFilter(ExpensesInfoSave item)
    {
        if(isOk)
        {
            if(string.IsNullOrWhiteSpace(keywordText.text))
            { /*Lascia a isOk=true*/ }
            else
                isOk = item.expenseType.ToUpper().Contains(keywordText.text.ToUpper().Trim());
        }
    }

    void GetDateInfo()
    {
        int fromYear = string.IsNullOrWhiteSpace(fromYearText.text) ? 1900 : int.Parse(fromYearText.text);
        int fromMonth = string.IsNullOrWhiteSpace(fromMonthText.text) ? 1 : int.Parse(fromMonthText.text);
        int fromDay = string.IsNullOrWhiteSpace(fromDayText.text) ? 1 : int.Parse(fromDayText.text);
        
        from = new DateTime(fromYear, fromMonth, fromDay, 0, 0, 0);

        int toYear = string.IsNullOrWhiteSpace(toYearText.text) ? 2150 : int.Parse(toYearText.text);
        int toMonth = string.IsNullOrWhiteSpace(toMonthText.text) ? 12 : int.Parse(toMonthText.text);
        int toDay = string.IsNullOrWhiteSpace(toDayText.text) ? DateTime.DaysInMonth(toYear, toMonth) : int.Parse(toDayText.text);

        to = new DateTime(toYear, toMonth, toDay, 23, 59, 59);
    }    
}
