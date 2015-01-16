using UnityEngine;
using System.Collections;

public class TabActivator : MonoBehaviour 
{
	public int Id = 0;

	public void ActivateTab()
	{
		if( TabManager.Instance != null )
		{
			TabManager.Instance.ActivateTab(Id);
		}
	}
}
