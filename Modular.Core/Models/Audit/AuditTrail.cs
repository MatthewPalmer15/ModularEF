using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Audit
{
    public class AuditTrail 
    {

        public Guid Id { get; set; }

        public string ObjectType { get; set; }

        public Guid ObjectID { get; set; }

        public virtual List<AuditLog> AuditLogs { get; set; }

    }
}
