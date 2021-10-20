namespace MoqApp.Services
{
    public interface ILogService
    {
        void LogInformation(string message, params object[] parameters);
    }
}