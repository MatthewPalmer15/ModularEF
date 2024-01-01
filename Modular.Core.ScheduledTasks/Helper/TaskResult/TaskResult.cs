using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.ScheduledTasks.Helper
{
    internal class TaskResult
    {

        private TaskResult(bool isValid, List<string>? errors = null)
        {
            this.IsValid = isValid;
            this.Errors = errors ?? new List<string>();
        }

        public bool IsValid { get; private set; }

        public List<string> Errors { get; private set; }


        public static TaskResult Success()
        {
            return new TaskResult(true);
        }

        public static TaskResult Failed(IList<string> errors)
        {
            return new TaskResult(false, errors.ToList());
        }

    }
}
