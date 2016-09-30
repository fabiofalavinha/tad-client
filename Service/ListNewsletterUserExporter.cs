using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class ListNewsletterUserExporter
    {
        public void ExportTo(IList<NewsletterUser> newsletterUsers, string filePath)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet(string.Format("Usuários - {0}", DateTime.Now.ToString("dd-MMM-yyyy")));

            var headerRow = sheet.CreateRow(0);
            var headerColumnNumber = 0;

            var tableHeadStyle = workbook.CreateCellStyle();
            tableHeadStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
            tableHeadStyle.FillPattern = FillPattern.SolidForeground;

            var tableHeadFont = workbook.CreateFont();
            tableHeadFont.Color = HSSFColor.Black.Index;
            tableHeadStyle.SetFont(tableHeadFont);

            var headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Nome");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("e-Mail");

            var dataStyle = workbook.CreateCellStyle();
            dataStyle.Alignment = HorizontalAlignment.Left;
            dataStyle.VerticalAlignment = VerticalAlignment.Top;

            var dataRowNumber = 1;
            var dataColumnNumber = 0;
            foreach (var newsletterUser in newsletterUsers)
            {
                var dataRow = sheet.CreateRow(dataRowNumber++);
                dataColumnNumber = 0;

                var dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(newsletterUser.Name);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(newsletterUser.Email);
            }

            for (int i = 0; i < dataColumnNumber; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            workbook.Write(new FileStream(filePath, FileMode.Create));
        }
    }
}
