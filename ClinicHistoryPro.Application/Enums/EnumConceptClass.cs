using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumConceptClass
    {
        [Description("Salario Básico")]
        BasicSalary = 1,

        [Description("Horas Extras")]
        OvertimeHours = 2,

        [Description("Bonificación")]
        Bonus = 3,

        [Description("AUXILIOTRANSPORTE")]
        TransportAllowance = 4,

        [Description("Aporte a Seguridad Social")]
        SocialSecurityContribution = 5,

        [Description("Deducción de Salud")]
        HealthDeduction = 6,

        [Description("Deducción de Pensión")]
        PensionDeduction = 7
    }
}
