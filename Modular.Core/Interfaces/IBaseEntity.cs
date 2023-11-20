namespace Modular.Core.Interfaces
{
    public interface IBaseEntity<T>
    {

        public T Id { get; set; }

        public DateTime Created { get; set; }

    }
}
