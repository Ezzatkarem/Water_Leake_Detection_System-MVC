


namespace Professonal.DAL.Repo.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        ILeakRequestRepo leakRequestRepo { get; }
        IAppUserRepo appUserRepo { get; }
        IcommentRepo commentRepo { get; }
        IMediaItemRepo mediaItemRepo { get; }
        IVedioRepo vedioRepo { get; }

        // Save Changes
        Task<int> CompleteAsync();

        // Begin Transaction
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
