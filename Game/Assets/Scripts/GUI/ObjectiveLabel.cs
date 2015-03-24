using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectiveLabel : MonoBehaviour
{
	public int Index;
	public Text Label;
	public Text Quantity;

	public Color TodoColor = Color.red;
	public Color DoneColor = Color.green;

	void Start()
	{
		UpdateData();
	}

	// Update is called once per frame
	public void UpdateData ()
	{
		if (Index < 0) return;
		if (ObjectiveManager.Instance.Objectives.Length <= Index)
		{
			gameObject.SetActive(false);
			return;
		}

		var objective = ObjectiveManager.Instance.Objectives[Index];
		
		Label.text = LocalizationManager.GetText(objective.Name);

		Quantity.text = objective.CurrentQuantity + "/" + objective.QuantityNeeded;
		Quantity.color = objective.Complete ? DoneColor : TodoColor;
	}
}
