namespace LAB_APP.Application.DTOs
{
    public class ProvinciaDTO
    {
        public string? Nome { get; set; }
        public string? Capital { get; set; }
    }
    public class AngolaDTO
    {
        public List<ProvinciaDTO>? Provincias { get; set; }
    }
    public class DadosPaisDTO
    {
        public AngolaDTO? Angola { get; set; }
    }
}
