namespace Cacs.Domain.Models.SeedWork
{
    public abstract class Entidade
    {
        public Guid Id { get; protected set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entidade outra)
                return false;

            if (ReferenceEquals(this, outra))
                return true;

            return Id == outra.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
