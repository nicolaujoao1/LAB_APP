﻿using ClosedXML.Excel;
using LAB_APP.Application.DTOs;

namespace LAB_APP.Application.Services
{
    public class ExcelService : IExcelService
    {
        public List<EscolaDTO> ReadDataFromExcel(byte[] fileContent)
        {
            var escolas = new List<EscolaDTO>();

            using (var memoryStream = new MemoryStream(fileContent))
            {
                using (var workbook = new XLWorkbook(memoryStream))
                {
                    var worksheet = workbook.Worksheet(1);

                    if (worksheet.LastRowUsed() is null) return escolas;

                    for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                    {
                        var escola = new EscolaDTO
                        {
                            Nome = worksheet.Cell(row, 1).Value.ToString(),
                            Email = worksheet.Cell(row, 2).Value.ToString(),
                            NumeroDeSalas = Convert.ToInt32(worksheet.Cell(row, 3).Value.ToString()),
                            Provincia = worksheet.Cell(row, 4).Value.ToString()
                        };

                        escolas.Add(escola);
                    }
                }
            }

            return escolas;
        }
    }
}
