using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumPayroll
    {
        [Description("Nómina Mensual")]
        MENSUAL = 1,
        
        [Description("Nómina Quincenal")]
        QUINCENAL = 2,
        
        [Description("Nómina Semanal")]
        DECENAL = 3,
    }
}
