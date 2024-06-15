using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumStrategyPayroll
    {
        [Description("SALARIOBASICO")]
        CalculateOrdinarySalary = 2,

        [Description("PENSIONSALUD")]
        CalculatePensionAndHealth = 3,
        
        [Description("HORASEXTRAS")]
        CalculateExtraHour = 4,

        [Description("BONUS")]
        CalculateBonus = 5,
            
        [Description("AUXILIOTRANSPORTE")]
        CalculateTransportAllowance = 6,
            
        [Description("APORTEPENSIONSALUD")]
        CalculateContributionPensionHealth = 7
    }
}
