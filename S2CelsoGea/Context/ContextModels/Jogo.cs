using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S2CelsoGea.Context.ContextModels
{
    public class Jogo : EntityBase
    {
        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "O campo Nome do Jogo é obrigatório")]
        public string Name { get; set; }

        public int? WithUser_Id { get; set; }

        [ForeignKey("WithUser_Id")]
        public virtual User WithUser { get; set; }

        /*modelBuilder.Entity<Foo>()
    .HasRequired(f => f.Bar)
    .WithMany(b => b.Foos)
    .HasForeignKey(f => f.BarId);*/
    }
}