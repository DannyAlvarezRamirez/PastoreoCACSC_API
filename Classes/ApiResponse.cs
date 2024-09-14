using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Classes
{
    public class ApiResponse
    {
        // Default constructor
        public ApiResponse() : this(true, 0, "Success", string.Empty) { }

        // Parameterized constructor
        public ApiResponse(bool success, ExitCode exitCode, string message, string details = "")
        {
            SetResponse(success, exitCode, message, details);
            this.Data = new List<object>();
        }

        // Method to set the response
        public void SetResponse(bool success, ExitCode exitCode, string message, string details = "")
        {
            this.Success = success;
            this.ExitCode = (int)exitCode;
            this.Message = message;
            this.Details = details;
        }

        // Response structure
        public string Message { get; set; }
        public bool Success { get; set; }
        public int ExitCode { get; set; }
        public string Details { get; set; }
        public List<object> Data { get; set; }
    }

    // Enum for exit codes
    public enum ExitCode
    {
        Success = 0,
        ErrorInvalidRequest = 1,
        ErrorNotFound = 2,
        ErrorUnauthorized = 3,
        ErrorServer = 4
    }
}
