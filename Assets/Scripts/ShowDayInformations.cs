using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDayInformations : MonoBehaviour
{
    [SerializeField]
    TMP_Text dayNumber;

    [SerializeField]
    Calendar calendar;

    public void ShowDailyInformations()
    {
        calendar.ShowDailyExpenses(int.Parse(dayNumber.text));
    }
}
