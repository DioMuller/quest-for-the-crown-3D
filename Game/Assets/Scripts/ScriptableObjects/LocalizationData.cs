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
        public string Language;
        public string Key;
        public string Value;
    }
    #endregion Structures

    #region Public Attributes
    /// <summary>
    /// Dictionary Entries
    /// </summary>
    public DictionaryEntry[] Entries;
    #endregion Public Attributes

    #region Methods
    public string GetEntry(string key)
    {
        return GetEntryLanguageOrDefault(Application.systemLanguage.ToString(), key);
    }

    public string GetEntryDefault(string key)
    {
        var entry = Entries.FirstOrDefault((e) => e.Key == key && e.Language == String.Empty);

        if(entry == null) throw new Exception("Key Not Found for Default Dictionary.");

        return entry.Value;
    }

    public string GetEntryLanguage(string language, string key)
    {
        var entry = Entries.FirstOrDefault((e) => e.Key == key && e.Language == language);

        if (entry == null) throw new Exception("Key Not Found for Language " + language + ".");

        return entry.Value;
    }

    /// <summary>
    /// Get Entry for the specified language, or for the default language.
    /// </summary>
    /// <param name="language">Language.</param>
    /// <param name="key">Entry key.</param>
    /// <returns>Entry value.</returns>
    public string GetEntryLanguageOrDefault(string language, string key)
    {
        try
        {
            return GetEntryLanguage(language, key);
        }
        catch (Exception)
        {
            try
            {
                return GetEntryDefault(key);
            }
            catch (Exception)
            {

                throw new Exception("Key Not Found for Language " + language + " or in the default dictionary.");
            }
        }
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
