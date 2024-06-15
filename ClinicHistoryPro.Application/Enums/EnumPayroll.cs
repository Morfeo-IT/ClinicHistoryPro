using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumPayroll
    {
        [Description("N�mina Mensual")]
        MENSUAL = 1,
        
        [Description("N�mina Quincenal")]
        QUINCENAL = 2,
        
        [Description("N�mina Semanal")]
        DECENAL = 3,
    }
}
