using Modular.Core.Interfaces;
using System.Reflection;

namespace Modular.Core
{
    public class BaseEntity<T>
    {

        public BaseEntity()
        {
            SetDefaultValues();
        }

        #region "  Properties  "

        public T Id { get; set; }

        public DateTime Created { get; set; }

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
