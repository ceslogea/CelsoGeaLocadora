using System.ComponentModel.DataAnnotations;

namespace S2CelsoGea.Context.ContextModels
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}