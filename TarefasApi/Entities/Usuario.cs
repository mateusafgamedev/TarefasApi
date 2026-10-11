using Microsoft.AspNetCore.Identity;

namespace TarefasApi.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public DateTime CriadoEm { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
