using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpensesList : MonoBehaviour {		//IN REALTà POTRESTI FARE CHE LA LISTA RIMANE AGGIORNATA SEMPRE. SENZA DOVER METTERE E CANCELLARE LE COSE AD OGNI APERTURA/CHIUSURA

	public GameObject prefabExpense;
	public TrackMoney trackMoney;

	private List<Text> texts = new List<Text>();
	private List<GameObject> garbage = new List<GameObject>();

	void OnEnable()
	{ StartCoroutine(enumerator()); }

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			trackMoney.ShowListOfExpenses();
		}
	}

    IEnumerator enumerator()
	{
		for (int i = TrackMoney.expensesInfoSavesList.Count - 1; i >= 0; i--)
		{
			yield return null;

			//Spawno la casella
			GameObject spawnGameObj = Instantiate(prefabExpense, gameObject.transform);
			//Metto i gameobjects che spawno in una lista, per poterli eliminare dopo.
			garbage.Add(spawnGameObj);

			//Mi collego ai testi all'inteno del figli
			texts.AddRange(spawnGameObj.GetComponentsInChildren<Text>());

			//Cerco in base al loro nome e riempio i campi di testo con i dati giusti
			for (int a = 0; a < texts.Count; a++)                                                                   
			{
				if (texts[a].name == "NOME")
				{ texts[a].text = TrackMoney.expensesInfoSavesList[i].expenseType; }

				else if (texts[a].name == "PREZZO")
				{ texts[a].text = TrackMoney.expensesInfoSavesList[i].expenseAmmount.ToString(); }

				else if (texts[a].name == "DATA")
				{
					if (TrackMoney.expensesInfoSavesList[i].dateTime != null)
					{ texts[a].text = TrackMoney.expensesInfoSavesList[i].dateTime.ToString(); }
				}

				else if (texts[a].name == "CATEGORIA")
				{ texts[a].text = TrackMoney.expensesInfoSavesList[i].expenseCategory; }

			}

			texts.Clear();
        }
	}

	void OnDisable()
	{
		for(int i = 0; i < garbage.Count; i++)
		{ Destroy(garbage[i]); }

		garbage.Clear();
	}
}
