using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel; 
using NPOI.XSSF.UserModel;

public class LocalizationImporter  : Editor
{
    [MenuItem("Aditional Tools/Create Translation from Excel")]
    public static void CreateLocalizationFiles()
    {
        XSSFWorkbook workbook; 

        using (var fs = File.OpenRead(@"Assets\Localization\LanguageData.xlsx")) 
        { 
            workbook = new XSSFWorkbook(fs); 
        }

        var sheet = workbook.GetSheetAt(0);

        var columns = sheet.GetRow(0);

        for( int i = 1; i < columns.Cells.Count; i++ )
        {
            LocalizationData asset = LocalizationData.CreateInstance("LocalizationData") as LocalizationData;
            var language = columns.GetCell(i).StringCellValue;

            if (asset != null)
            {
                asset.Language = language;
                AssetDatabase.CreateAsset(asset, String.Format("Assets/Localization/LanguageData.{0}.asset", language));

                int currentRow = 1;
                var row = sheet.GetRow(currentRow);

                List<DictionaryEntry> entries = new List<DictionaryEntry>();

                while( row != null )
                {
                    try
                    {
                        var entry = new DictionaryEntry() { Key = row.GetCell(0).StringCellValue, Value = row.GetCell(i).StringCellValue };
                        entries.Add(entry);

                        currentRow++;
                        row = sheet.GetRow(currentRow);
                    }
                    catch // Row was not null, but cells are invalid.
                    {
                        break;
                    }
                }

                asset.Entries = entries.ToArray();

                AssetDatabase.SaveAssets();
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
            }
        }
    }
}
