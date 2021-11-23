﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public enum kindOfExpense
{
    Altro,
    Alimentari,
    FreeTime,
    Studio,
    Salute,
    Casa,
    Trasporti
}

public class TrackMoney : MonoBehaviour {

    DataController data;
    public static float totalSpent;

    public Text moneySpent;
    public Text expenseType;
    public Text rate;
    public Text totalSpentText;    

    [HideInInspector]
    kindOfExpense expenseCategory;

    public static ExpensesInfoSave expensesInfoSave;

    public static List<ExpensesInfoSave> expensesInfoSavesList;

    public GameObject showExpenses_Panel;

    public delegate void SelectedCategory();
    public SelectedCategory selectedCategory;

    void Start ()
    {
        //Test di Parsing ENUM: expenseCategory = kindOfExpense.FreeTime; string s = (expenseCategory.ToString()); expenseCategory = kindOfExpense.Alimentari; expenseCategory = (kindOfExpense)Enum.Parse(typeof(kindOfExpense), s, true);

        expensesInfoSavesList = new List<ExpensesInfoSave>();

        data = SaveLoad.LoadData();

        if(data != null)
        {
            totalSpent = data.totalSpent;
            totalSpentText.text = totalSpent.ToString();

            if (data.expensesInfoSave != null)
            {
                for (int i = 0; i < data.expensesInfoSave.Count; i++)
                {
                    expensesInfoSavesList.Add(data.expensesInfoSave[i]);
                   // print(data.expensesInfoSave[i].expenseType);
                }
            }
        }

        else
        {
            totalSpent = 0;
            totalSpentText.text = "0";
        }

    }

    public string MonthlyExpenses(DateTime selectedDate)
    {
        float spent = 0;

        foreach (var item in data.expensesInfoSave)
        {
            if(item.dateTime.Year == selectedDate.Year && item.dateTime.Month == selectedDate.Month)
            {
                spent += item.expenseAmmount;
            }
        }

        return "Spese del mese: " + spent;
    }

    public void addExpense()
    {
        float expenseToAdd = float.Parse(moneySpent.text);
        moneySpent.text = "";
        totalSpent += expenseToAdd;

        totalSpentText.text = totalSpent.ToString();

        string expenseTypeToAdd = expenseType.text;
        print(expenseToAdd);

        //Se non è richiesta la rateizzazione, inserisce tutta la spesa nella stessa data..
        if (string.IsNullOrEmpty(rate.text) || rate.text == "0" || rate.text == "1")
        {
            expensesInfoSave = new ExpensesInfoSave(expenseToAdd, expenseTypeToAdd, expenseCategory);
            expensesInfoSavesList.Add(expensesInfoSave);
        }
        //..altrimenti la suttivide per il numero di mesi indicati
        else
        {
            int numberOfRates = int.Parse(rate.text);

            expensesInfoSave = new ExpensesInfoSave((expenseToAdd/numberOfRates), expenseTypeToAdd, expenseCategory);
            expensesInfoSavesList.Add(expensesInfoSave);

            for (int i = 1; i < numberOfRates; i++)
            {
                expensesInfoSave = new ExpensesInfoSave((expenseToAdd / numberOfRates), expenseTypeToAdd, expenseCategory, DateTime.Now.AddMonths(i));
                expensesInfoSavesList.Add(expensesInfoSave);
            }
        }

        SaveLoad.SaveData();
        print(totalSpent);
        print(expensesInfoSavesList[expensesInfoSavesList.Count - 1].expenseType);
    }

    public void DeleteSave()
    {
        SaveLoad.DeleteSave();
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
    }

    public void ButtonOther()
    {
        expenseCategory = kindOfExpense.Altro;
    }

    public void Button0()
    {
        expenseCategory = kindOfExpense.Alimentari;
    }

    public void Button1()
    {
        expenseCategory = kindOfExpense.FreeTime;
    }

    public void Button2()
    {
        expenseCategory = kindOfExpense.Studio;
    }

    public void Button3()
    {
        expenseCategory = kindOfExpense.Salute;
    }

    public void Button4()
    {
        expenseCategory = kindOfExpense.Casa;
    }

    public void Button5()
    {
        expenseCategory = kindOfExpense.Trasporti;
    }

    public void ShowListOfExpenses()
    {
        showExpenses_Panel.SetActive(!showExpenses_Panel.activeSelf);
    }
}
