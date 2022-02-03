using System;

namespace SilverTongue.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public T Data { get; set; }
    }
}
