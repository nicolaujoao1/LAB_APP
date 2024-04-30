using LAB_APP.Domain.Common;

namespace LAB_APP.Domain.Entities
{
    public class Escola:BaseAuditableEntity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int NumeroDeSalas { get; set; }
        public string? Provincia { get; set; }
    }
}
