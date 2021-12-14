using System.Threading.Tasks;

namespace Lis.Monitoring.Infrastructure.Db
{
    public static class DbServiceListenersExtensions
    {
        public static void AddMetadataHandling(this DbServiceListeners listeners)
        {
            listeners.AddBeforeSaveListener(ctx =>
            {
                ctx.Changes.ApplyUpdateMetadataHandling(ctx.User?.UserName, ctx.User?.Id);
                return Task.CompletedTask;
            });
        }
    }
}