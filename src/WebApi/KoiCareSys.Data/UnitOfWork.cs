using KoiCareSys.Data.Repository;

namespace KoiCareSys.Data
{
    public class UnitOfWork
    {
        private ApplicationDbContext _unitOfWorkContext;
        private KoiReposiory koiReposiory;
        private FeedingScheduleRepository feedingScheduleRepository;
        private PondRepository pondRepository;
        private UserRepository userRepository;
        private MeasurementRepository measurementRepository;
        private MeasureDataRepository measureDataRepository;
        private UnitRepository unitRepository;

        public UnitOfWork(ApplicationDbContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public UnitOfWork()
        {
        }

        public UserRepository User
        {
            get { return userRepository ??= new UserRepository(); }

        }

        public KoiReposiory Koi
        {
            get { return koiReposiory ??= new KoiReposiory(); }

        }

        public PondRepository Pond
        {
            get { return pondRepository ??= new PondRepository(); }

        }

        public FeedingScheduleRepository FeedingSchedule
        {
            get { return feedingScheduleRepository ??= new FeedingScheduleRepository(); }

        }

        public MeasurementRepository Measurement
        {
            get { return measurementRepository ??= new MeasurementRepository(); }
        }

        public MeasureDataRepository MeasureData
        {
            get { return measureDataRepository ??= new MeasureDataRepository(); }
        }

        public UnitRepository Unit
        {
            get { return unitRepository ??= new UnitRepository(); }
        }

        ////TO-DO CODE HERE/////////////////

        #region Set transaction isolation levels

        /*
        Read Uncommitted: The lowest level of isolation, allows transactions to read uncommitted data from other transactions. This can lead to dirty reads and other issues.

        Read Committed: Transactions can only read data that has been committed by other transactions. This level avoids dirty reads but can still experience other isolation problems.

        Repeatable Read: Transactions can only read data that was committed before their execution, and all reads are repeatable. This prevents dirty reads and non-repeatable reads, but may still experience phantom reads.

        Serializable: The highest level of isolation, ensuring that transactions are completely isolated from one another. This can lead to increased lock contention, potentially hurting performance.

        Snapshot: This isolation level uses row versioning to avoid locks, providing consistency without impeding concurrency. 
         */

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = _unitOfWorkContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = await _unitOfWorkContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
        #endregion
    }
}