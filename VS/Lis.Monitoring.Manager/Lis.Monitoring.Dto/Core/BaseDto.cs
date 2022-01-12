namespace Lis.Monitoring.Dto.Core
{
    public class BaseDto<TId> : IDto<TId>
    {
        public TId Id { get; set; }
    }
}