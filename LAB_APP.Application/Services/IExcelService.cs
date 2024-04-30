using LAB_APP.Application.DTOs;

namespace LAB_APP.Application.Services
{
    public interface IExcelService
    {
        List<EscolaDTO> ReadDataFromExcel(string filePath);
    }
}
