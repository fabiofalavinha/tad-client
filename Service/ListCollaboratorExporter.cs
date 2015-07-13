using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class ListCollaboratorExporter
    {
        public void ExportTo(IList<Collaborator> collaborators, string filePath)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet(string.Format("Colaboradores - {0}", DateTime.Now.ToString("dd-MMM-yyyy")));

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

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Data de Nascimento");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Data de Início");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Data de Saída");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Sexo");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Telefones");

            headerCell = headerRow.CreateCell(headerColumnNumber++);
            headerCell.CellStyle = tableHeadStyle;
            headerCell.CellStyle.Alignment = HorizontalAlignment.Left;
            headerCell.SetCellValue("Ativo?");

            var dataStyle = workbook.CreateCellStyle();
            dataStyle.Alignment = HorizontalAlignment.Left;
            dataStyle.VerticalAlignment = VerticalAlignment.Top;

            var dataRowNumber = 1;
            var dataColumnNumber = 0;
            foreach (var collaborator in collaborators)
            {
                var dataRow = sheet.CreateRow(dataRowNumber++);
                dataColumnNumber = 0;

                var dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.Name);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.Email);

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.BirthDate.ToString("dd/MMM/yyyy"));

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.StartDate.HasValue ? collaborator.StartDate.Value.ToString("dd/MMM/yyyy") : "Não Infomado");

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.ReleaseDate.HasValue ? collaborator.ReleaseDate.Value.ToString("dd/MMM/yyyy") : "Não Infomado");

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.Gender.Translate());

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(string.Join(", ", collaborator.Telephones.Select(t => string.Format("{0}: ({1}) {2}", t.PhoneType.Translate(), t.AreaCode, t.Number))));

                dataCell = dataRow.CreateCell(dataColumnNumber++);
                dataCell.CellStyle.Alignment = HorizontalAlignment.Left;
                dataCell.SetCellValue(collaborator.Active ? "Sim" : "Não");
            }

            for (int i = 0; i < dataColumnNumber; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            workbook.Write(new FileStream(filePath, FileMode.Create));
        }
    }
}
