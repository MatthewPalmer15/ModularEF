using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Helpers.Types
{
    public enum ObjectType
    {
        Unknown = 000000,

        //  MODULAR.CORE
        Base = 000001,
        BindableBase = 000002,
        Document = 000003,
        DataExporter = 000004,
        DocumentPack = 000005,
        Email = 000006,
        EmailLog = 000007,
        Contact = 000008,
        Organisation = 000009,
        Account = 000010,
        AccountProfile = 000011,
        AccountRole = 000012,
        AccountRolePermission = 000013,
        Department = 000014,
        Industry = 000015,
        Occupation = 000016,
        Country = 000017,
        Region = 000018,
        Credit = 000019,
        CreditItem = 000020,
        CreditPayment = 000021,
        DiscountVoucher = 000022,
        Invoice = 000023,
        InvoiceItem = 000024,
        InvoicePayment = 000025,
        AppConfig = 000026,
        SystemConfig = 000027,
        Exception = 000028,
        ExceptionLog = 000029,
        Owner = 000030,
        Notification = 000031,
        AuditLog = 000032,
        System = 000033,
        SystemPolicy = 000034,
        ApplicationPage = 000035,
        ApplicationMultiPage = 000036,
        ScheduledTask = 000037,
    }


}
