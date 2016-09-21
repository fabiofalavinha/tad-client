using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.Service
{
    class ListFinancialEntryExporter
    {
        public void ExportTo(IList<FinancialEntry> financialEntrys, string filePath)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet(string.Format("Lançamentos - {0}", DateTime.Now.ToString("dd-MMM-yyyy")));

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
            headerCell.SetCellValue("Data");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Origem");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Tipo de Lançamento");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Observações");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Valor");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("D/C");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Saldo");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Recibo");

            var dataStyle = workbook.CreateCellStyle();
            dataStyle.Alignment = HorizontalAlignment.Left;
            dataStyle.VerticalAlignment = VerticalAlignment.Top;

            var dataRowNumber = 1;
            var dataColumnNumber = 0;
            foreach (var financialEntry in financialEntrys)
            {
                var dataRow = sheet.CreateRow(dataRowNumber++);
                dataColumnNumber = 0;

                var dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.DateString);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.Target.Name);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.Type.Description);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.AdditionalText);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.Value.ToString("#,#.00#;(#,#.00#)", new CultureInfo("pt-BR")));

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(CategoryExtensions.TranslateValue(financialEntry.Type.Category));

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.Value.ToString("#,#.00#;(#,#.00#)", new CultureInfo("pt-BR")));

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(financialEntry.FinancialReceiptInfo == null ? "N/D" : string.Concat(financialEntry.FinancialReceiptInfo.Number, " - ", financialEntry.FinancialReceiptInfo.Sent));
            }

            for (int i = 0; i < dataColumnNumber; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            workbook.Write(new FileStream(filePath, FileMode.Create));
        }
    }
}
