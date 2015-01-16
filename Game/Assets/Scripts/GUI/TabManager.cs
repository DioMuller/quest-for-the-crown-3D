using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class TabInfo
{
	public int Id;
	public GameObject Tab;
}

public class TabManager : MonoBehaviour 
{
	private List<TabInfo> _tabs;
	private int _currentTab = -1;

	public static TabManager Instance { get; private set; }

	/// <summary>
	/// Called on Initialization.
	/// </summary>
	void Awake () 
	{
		_tabs = new List<TabInfo>();

		Instance = this;
	}

	public void AddTab(int id, GameObject tab)
	{
		_tabs.Add(new TabInfo{Id = id, Tab = tab});
		tab.SetActive(false);

		if( _currentTab == -1 || _currentTab > id )
		{
			ActivateTab(id);
		}
	}

	public void ClearTabs()
	{
		foreach( var tab in _tabs )
		{
			tab.Tab.SetActive(false);
		}
	}

	public void ActivateTab(int id)
	{
		ClearTabs();

		var tab = _tabs.FirstOrDefault((t) => t.Id == id);

		if( tab != null )
		{
			_currentTab = id;
			tab.Tab.SetActive(true);
		}
		else
		{
			_currentTab = -1;
		}
	}
}
