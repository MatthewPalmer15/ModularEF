using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entities.Audit
{
    public class AuditLog : BaseEntity
    {

        public ObjectTypes.ObjectType ObjectType { get; set; } = ObjectTypes.ObjectType.Unknown;

        public Guid ObjectID { get; set; } = Guid.Empty;

        public string Message { get; set; } = string.Empty;

        public string DeviceInformation { get; set; } = string.Empty;

    }
}
