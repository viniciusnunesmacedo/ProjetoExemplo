using Newtonsoft.Json;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Dominio.Interfaces;
using ProjetoExemplo.Infraestrutura.Dados.Repositorio.FonteEventos;

namespace ProjetoExemplo.Infraestrutura.Dados.FonteEventos
{
    public class SqlArmazenamentoEvento : IArmazenamentoEvento
    {
        private readonly IArmazenamentoEventoRepositorio _armazenamentoEventoRepositorio;
        //private readonly IUsuario _usuario;

        public SqlArmazenamentoEvento(IArmazenamentoEventoRepositorio armazenamentoEventoRepositorio
            /*,IUsuario usuario*/)
        {
            _armazenamentoEventoRepositorio = armazenamentoEventoRepositorio;
            //_usuario = usuario;
        }

        public void Salvar<T>(T oEvento) where T : Evento
        {
            // Using Newtonsoft.Json because System.Text.Json
            // is a sad joke to be considered "Done"

            // The System.Text don't know how serialize a
            // object with inherited properties, I said is sad...
            // Yes! I tried: options = new JsonSerializerOptions { WriteIndented = true };

            var dadosSerializado = JsonConvert.SerializeObject(oEvento);

            var eventoArmazenado = new EventoArmazenado(
                oEvento,
                dadosSerializado,
                "teste"); // _usuario.Nome ?? _usuario.Nome); //_usuario.GetUserEmail());

            _armazenamentoEventoRepositorio.Armazenar(eventoArmazenado);
        }
    }
}
