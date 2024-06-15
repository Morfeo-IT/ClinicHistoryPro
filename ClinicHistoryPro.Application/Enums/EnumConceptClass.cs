using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumConceptClass
    {
        [Description("Salario B�sico")]
        BasicSalary = 1,

        [Description("Horas Extras")]
        OvertimeHours = 2,

        [Description("Bonificaci�n")]
        Bonus = 3,

        [Description("AUXILIOTRANSPORTE")]
        TransportAllowance = 4,

        [Description("Aporte a Seguridad Social")]
        SocialSecurityContribution = 5,

        [Description("Deducci�n de Salud")]
        HealthDeduction = 6,

        [Description("Deducci�n de Pensi�n")]
        PensionDeduction = 7
    }
}
