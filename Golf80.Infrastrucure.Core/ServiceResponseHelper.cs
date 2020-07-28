using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golf80.Infrastrucure.Core
{
    public static class ServiceResponseHelper
    {
        public static ServiceResponse<T> GetSuccessResponse<T>(T data)
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Success = true,
                Message = string.Empty,
            };
        }
        public static ServiceResponse<T> GetFailureResponse<T>()
        {
            return new ServiceResponse<T>
            {
                Data = default(T),
                Success = false,
                Message = string.Empty,
            };
        }
        public static ServiceResponse<T> GetFailureResponse<T>(string message)
        {
            return new ServiceResponse<T>
            {
                Data = default(T),
                Success = false,
                Message = message,
            };
        }
    }
}
