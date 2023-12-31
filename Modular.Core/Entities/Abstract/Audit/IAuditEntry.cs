﻿#nullable disable

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modular.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modular.Core.Entities.Abstract
{
    public interface IAuditEntry : IBaseEntity<Guid>
    {

        public enum ActionType
        {
            Unknown,
            Create,
            Update,
            Delete
        }

        public DateTime Timestamp { get; set; }

        public Guid ApplicationUserId { get; set; }

        public ActionType Action { get; set; }

        public string EntityId { get; set; }

        public string EntityName { get; set; }

        public Dictionary<string, object> EntityObject { get; set; }

        [NotMapped]
        public List<PropertyEntry> TempProperties { get; set; }

    }
}
