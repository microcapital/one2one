namespace OneTwoOne.Infrastructure.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
