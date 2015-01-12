using System;
using UnityEngine;
using System.Linq;

public class LocalizationData : ScriptableObject
{
    #region Structures
    /// <summary>
    /// Dictionary Entry Value.
    /// </summary>
    [System.Serializable]
    public class DictionaryEntry
    {
        public string Key;
        public string Value;
    }
    #endregion Structures

    #region Public Attributes

	/// <summary>
	/// The dictionary language.
	/// </summary>
	public string Language;

    /// <summary>
    /// Dictionary Entries
    /// </summary>
    public DictionaryEntry[] Entries;
    #endregion Public Attributes

    #region Methods
    public string GetEntry(string key)
    {
        var entry = Entries.FirstOrDefault((e) => e.Key == key);

        if(entry == null) throw new Exception("Key Not Found for Default Dictionary.");

        return entry.Value;
    }
    #endregion Methods

    #region ScriptableObject Methods
    /// <summary>
    /// Clones object instance.
    /// </summary>
    /// <returns>Clone object.</returns>
    public LocalizationData Clone()
    {
		var newLocalizationData = CreateInstance<LocalizationData>();
		
		newLocalizationData.Entries = (DictionaryEntry[]) Entries.Clone();

        return newLocalizationData;
    }
    #endregion ScriptableObject Methods

}
