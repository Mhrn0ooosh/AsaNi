using System;

namespace AsaNi.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public Exception Exception { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }
    }
}
