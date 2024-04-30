using LAB_APP.Application.DTOs;
using OfficeOpenXml;

namespace LAB_APP.Application.Services
{
    public class ExcelService : IExcelService
    {
        public List<EscolaDTO> ReadDataFromExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var escolas = new List<EscolaDTO>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var escola = new EscolaDTO
                    {
                        Nome = worksheet.Cells[row, 1].Value?.ToString(),
                        Email = worksheet.Cells[row, 2].Value?.ToString(),
                        NumeroDeSalas = Convert.ToInt32(worksheet.Cells[row, 3].Value?.ToString()),
                        Provincia = worksheet.Cells[row, 4].Value?.ToString()
                    };

                    escolas.Add(escola);
                }
            }

            return escolas;
        }
    }
}
