namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using Common;
    using Repository;
    public class LogService : ILogService
    {
        private ILogRepository _logRepository;
        public LogService()
        {
            _logRepository = new LogRepository();
        }

        public Task Create(LogEntity logEntity)
        {
            return _logRepository.Create(logEntity);
        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}