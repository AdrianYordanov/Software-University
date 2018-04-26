using System.Drawing;
using System.IO;

using OfficeOpenXml;
using OfficeOpenXml.Style;

// Should add from NuGet "EPPlus"
public class ExportToExcel
{
    private static void Main()
    {
        var directory = Directory.GetCurrentDirectory();
        var inputData = File.ReadAllLines(directory + @"\..\..\resources\StudentData.txt");
        var newFile = new FileInfo(directory + @"\..\..\resources\StudentData.xlsx");
        var excelColumns = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
        using (var excelFile = new ExcelPackage(newFile))
        {
            var workingSheet = excelFile.Workbook.Worksheets.Add("Content");
            var headers = inputData[0];
            var columns = headers.Split('\t');
            for (var j = 0; j < columns.Length; j++)
            {
                var cell = excelColumns[j] + 1;
                workingSheet.Cells[cell].Value = columns[j];
                workingSheet.Cells[cell].Style.Font.Bold = true;
                workingSheet.Cells[cell].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                workingSheet.Cells[cell].Style.Border.Left.Style = ExcelBorderStyle.Medium;
                workingSheet.Cells[cell].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                workingSheet.Cells[cell].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                workingSheet.Cells[cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workingSheet.Cells[cell].Style.Fill.BackgroundColor.SetColor(Color.GreenYellow);
            }

            for (var i = 1; i < inputData.Length; i++)
            {
                columns = inputData[i].Split('\t');
                for (var j = 0; j < columns.Length; j++)
                {
                    var cell = excelColumns[j] + (i + 1);
                    workingSheet.Cells[cell].Value = columns[j];
                }
            }

            excelFile.Save();
        }
    }
}