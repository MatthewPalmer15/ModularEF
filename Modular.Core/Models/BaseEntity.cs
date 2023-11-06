using Modular.Core.Interfaces;
using System.Reflection;

namespace Modular.Core
{
    public class BaseEntity : IBaseEntity
    {

        public BaseEntity()
        {
            SetDefaultValues();
        }

        #region "  Properties  "

        public Guid Id { get; set; }

        // public DateTime CreatedDate { get; set; }
        // 
        // public Guid CreatedBy { get; set; }
        // 
        // public DateTime ModifiedDate { get; set; }
        // 
        // public Guid ModifiedBy { get; set; }

        public Guid AuditTrailId { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region "  Methods  "

        private void SetDefaultValues()
        {
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                object? defaultValue = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : null;
                property.SetValue(this, defaultValue);
            }
        }

        #endregion

    }
}
