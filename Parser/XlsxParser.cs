using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows;
using System.IO;

namespace Parser
{
    public partial class MainWindow
    {
        public static int attempts = 0;
        public void ParseXlsx()
        {
            try
            {
                using (Stream stream = File.Open(thrlistPath, FileMode.Open))
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(stream, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                    int t = -1;
                    int i = 0;
                    foreach (Row r in sheetData.Elements<Row>().Skip(2))
                    {
                        threats.Add(new ThreatModel());
                        t++;
                        i = 0;
                        foreach (Cell c in r.Elements<Cell>().Take(8))
                        {
                            switch (i)
                            {
                                case 0:
                                    threats[t].ThreatId = Int32.Parse(c.InnerText);
                                    break;

                                case 1:
                                    int id = Int32.Parse(c.InnerText);
                                    SharedStringItem item = GetSharedStringItemById(workbookPart, id);
                                    threats[t].ThreatName = item.Text.Text;
                                    break;

                                case 2:
                                    id = Int32.Parse(c.InnerText);
                                    item = GetSharedStringItemById(workbookPart, id);
                                    threats[t].Description = item.Text.Text;
                                    break;

                                case 3:
                                    id = Int32.Parse(c.InnerText);
                                    item = GetSharedStringItemById(workbookPart, id);
                                    threats[t].Source = item.Text.Text;
                                    break;

                                case 4:
                                    id = Int32.Parse(c.InnerText);
                                    item = GetSharedStringItemById(workbookPart, id);
                                    threats[t].Target = item.Text.Text;
                                    break;

                                case 5:
                                    threats[t].ConfidentialityBreach = (c.InnerText == "1") ? true : false;
                                    break;

                                case 6:
                                    threats[t].IntegrityViolation = (c.InnerText == "1") ? true : false;
                                    break;

                                case 7:
                                    threats[t].AccessViolation = (c.InnerText == "1") ? true : false;
                                    break;

                                default:
                                    break;
                            }
                            i++;
                        }
                    }
                }
            }
            catch (FileFormatException)
            {
                MessageBox.Show("Your file seems to be corrupted or has wrong format");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found \n App (project) should have 'Data' in the root folder");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Missing file or disk fails");
            }
            catch (IOException)
            {
                MessageBox.Show("Refresh button needs to rest...");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("OS denies acces to file \n" + " Try again and...\n  May the Force be with you");
            }
            catch (Exception)
            {
                MessageBox.Show("We made a little whoopsie --- Already fixing!");
                ParseXlsx();
            }
            finally
            {
                updateThreats = threats;
                Paginate(threats);
                currentPage = 0;
                PreviousPage.Visibility = Visibility.Collapsed;
                if (Pages.Count == 1)
                {
                    NextPage.Visibility = Visibility.Collapsed;
                }
                else
                {
                    NextPage.Visibility = Visibility.Visible;
                }
                Table.ItemsSource = null;
                Table.ItemsSource = Pages[0];
                RefreshFile.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Method for retrieving cell data in excel 
        /// </summary>
        public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }
    }
}
