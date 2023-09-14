using System.Runtime.Serialization;

namespace BusinessTrackerApp.Persistence.Services
{
    [Serializable]
    internal class AuthenticationErrorExcepiton : Exception
    {
        public AuthenticationErrorExcepiton() : base("Kimlik doğrulama hatası")
        {
        }

        public AuthenticationErrorExcepiton(string? message) : base(message)
        {
        }

        
    }
}