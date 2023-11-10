
#nullable disable

using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modular.Core.Models.Audit
{
    public class AuditRequestLog
    {

       public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string? Exception { get; set; }

        public bool HasException
        {
            get
            {
                return !string.IsNullOrEmpty(Exception);
            }
        }

    }
}
