using ProjetoExemplo.Dominio.Core.Eventos;
using System;
using System.Collections.Generic;

namespace ProjetoExemplo.Dominio.Core.Modelos
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private List<Evento> _eventosDominio;
        public IReadOnlyCollection<Evento> EventosDominio => _eventosDominio?.AsReadOnly();

        public void AdicionarEventoDominio(Evento eventoDominio)
        {
            _eventosDominio = _eventosDominio ?? new List<Evento>();
            _eventosDominio.Add(eventoDominio);
        }

        public void RemoverEventoDominio(Evento ventoDominio)
        {
            _eventosDominio?.Remove(ventoDominio);
        }

        public void LimparEventoDominio()
        {
            _eventosDominio?.Clear();
        }

        #region Base Behaviours

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
