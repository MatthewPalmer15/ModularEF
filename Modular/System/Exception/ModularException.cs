using System.Runtime.Serialization;

namespace Modular.Core.System
{
    public class ModularException : Exception
    {

        #region "  Constructors  "

        public ModularException()
        {
        }

        public ModularException(string message)
            : base(message)
        {
        }

        public ModularException(string message, Exception inner)
            : base(message, inner)
        {
            // TODO: Create a log entry

        }


        #endregion

        #region "  Instance Methods  "

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion


    }


    public enum ExceptionType
    {
        Unknown = 000000,

        // Base Class
        BaseClassAccess = 000001,
        OrphanRecord = 000002,

        // Database
        DatabaseConnectionError = 000010,
        DatabaseTableNotFound = 000011,
        StoredProcedureNotFound = 000012,
        DatabaseConnectivityNotDefined = 000013,
        DynamicDatabaseDisabled = 000014,

        // SMTP
        SMTPClientConnectionError = 000020,
        SMTPClientAuthenticationError = 000021,
        SMTPClientEmailSendError = 000022,

        // Data Exporter
        ExecutionOfScriptFailed = 000030,



        // Network
        IPAddressError = 000031,

        // Encryption
        EncryptionError = 000041,

        // Generic
        NotImplemented = 000100,
        InvalidCast = 000101,
        InvalidOperation = 000102,
        ArgumentError = 000103,

        // Other
        DataTypeNotSupported = 001000,
        NullObjectReturned = 001001,
    }
}
