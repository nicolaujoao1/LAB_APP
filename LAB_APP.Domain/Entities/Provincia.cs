using LAB_APP.Domain.Common;

namespace LAB_APP.Domain.Entities
{
    public class Provincia: BaseAuditableEntity
    {
        public string? Nome { get; set; }
        public string? Capital { get; set; }
    }
    public class Angola
    {
        public List<Provincia>? Provincias { get; set; }
    }
    public class DadosPais
    {
        public Angola? Angola { get; set; }
    }

}
