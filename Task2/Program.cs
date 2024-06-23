using Microsoft.Office.Interop.Excel;
using System.IO;


Application excelApp = new Application();
excelApp.Visible = true;
Workbook workbook = excelApp.Workbooks.Add();
Worksheet filesSheet = workbook.Sheets[1];
filesSheet.Name = "Файлы";

filesSheet.Cells[1, 1] = "номер файла";
filesSheet.Cells[1, 2] = "Имя файла";
filesSheet.Cells[1, 3] = "Размер файла";

Worksheet foldersSheet = workbook.Sheets.Add();
foldersSheet.Name = "подпапки";

foldersSheet.Cells[1, 1] = "Номер подпапки";
foldersSheet.Cells[1, 2] = "Имя подпапки";

string directoryPath = @"C:\temp\ispp21";

string[] files = Directory.GetFiles(directoryPath);
int fileRow = 2;

foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    filesSheet.Cells[fileRow, 1] = fileRow - 1;
    filesSheet.Cells[fileRow, 2] = Path.GetFileName(file);
    filesSheet.Cells[fileRow, 3] = fileInfo.Name;
}
string[] folders = Directory.GetDirectories(directoryPath);
int folderRow = 2;
foreach (string folder in folders)
{
    DirectoryInfo folderInfo = new DirectoryInfo(folder);
    foldersSheet.Cells[folderRow, 1] = folderRow - 1;
    foldersSheet.Cells[folderRow, 2] = folderInfo.Name;
    folderRow++;
}
workbook.SaveAs(@"C:\temp\ispp21\lloh.xlsx");

workbook.Close();
excelApp.Quit();



