using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[System.Serializable]
public class ComboBoxItem
{
    public string Label = "";
    public string Value = "";
}

public class ComboBox : MonoBehaviour
{
    #region Public Attributes
    public ComboBoxItem[] Items;
    public string Label;
    #endregion Public Attributes

    #region Component References
    private Text _label;
    private Text _value;
    #endregion Component References

    #region MonoBehaviour Methods
    void Awake()
    {
        _label = GetComponentInChildren<Text>();
        _value = transform.Find("Options").GetComponentInChildren<Text>();

        _label.text = Label;

        UpdateItem();
    }
    #endregion MonoBehaviour Methods

    #region Properties
    public int SelectedIndex {get; private set;}

    public ComboBoxItem SelectedItem
    {
        get
        {
            if (SelectedIndex < 0 || SelectedIndex >= Items.Length) return null;
            return Items[SelectedIndex];
        }
    }

    public string SelectedValue
    {
        get
        {
            var item = SelectedItem;

            if (item != null) return item.Value;

            return null;
        }
    }
    #endregion Properties


    #region Events
    public void OnClick()
    {
        SelectedIndex = (SelectedIndex + 1) % Items.Length;
        UpdateItem();
    }
    #endregion Events

    #region Private Methods
    private void UpdateItem()
    {
        var item = SelectedItem;

        if (item != null)
        {
            _value.text = item.Label;
        }
    }
    #endregion Private Methods
}
