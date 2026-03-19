


namespace Professonal.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProfessionalDBContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public IMediaItemRepo mediaItemRepo { get; }
        public IAppUserRepo appUserRepo { get; }
        public IcommentRepo commentRepo { get; }
        public ILeakRequestRepo leakRequestRepo { get; }
        public IVedioRepo vedioRepo { get; }

        // Specific Repositories

        public UnitOfWork(ProfessionalDBContext context,IMediaItemRepo mediaItemRepo,IAppUserRepo appUserRepo,IcommentRepo commentRepo,ILeakRequestRepo leakRequestRepo,IVedioRepo vedioRepo)
        {
            _context = context;
           this. mediaItemRepo = mediaItemRepo;
           this. appUserRepo = appUserRepo;
           this. commentRepo = commentRepo;
            this.leakRequestRepo = leakRequestRepo;
           this. vedioRepo = vedioRepo;
            _repositories = new Dictionary<Type, object>();
        }

      

        // Specific Repository (Product)
     

        // Save Changes
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Transactions
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction?.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction?.RollbackAsync();
        }

        // Dispose
        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }
    }
}