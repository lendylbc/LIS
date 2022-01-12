namespace Lis.Monitoring.Dto.Core
{
    public interface IDto<TId>
    {
        TId Id { get; set; }
    }
}