using TarefasApi.Entities.Enums;

namespace TarefasApi.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ConcluidaEm { get; set; }
        public StatusTarefa Status { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public void Concluir()
        {
            Status = StatusTarefa.Concluida;
            ConcluidaEm = DateTime.Now;
        }
    }
}
