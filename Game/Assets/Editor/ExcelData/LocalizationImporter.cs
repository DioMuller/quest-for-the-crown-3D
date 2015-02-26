using UnityEditor;
using System.Collections;
using System.Linq;
using NPOI.SS.UserModel; 
using NPOI.XSSF.UserModel;

public class LocalizationImporter  : Editor
{
    [MenuItem("Aditional Tools/Create Translation from Excel")]
    public static void CreateLocalizationFiles()
    {
        XSSFWorkbook workbook; 

        using (var fs = File.OpenRead(@"Data\test.xls")) 
        { 
            workbook = new XSSFWorkbook(fs); 
        }

        var sheet = workbook.GetSheetAt(0);

        var rows = sheet.GetRow(0);

        var languages = rows.Cells.Where(c => c.StringCellValue != "Key");

        foreach (var language in languages)
        {
            LocalizationData asset = LocalizationData.CreateInstance("LocalizationData");

            asset.Language = language;

            AssetDatabase.CreateAsset(asset, String.Format("Assets/Localization/LocalizationData.{0}.asset", language));
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}
