using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumConceptType
    {
        [Description("Ingreso")]
        INGRESO = 1,
        [Description("Deducción")]
        DEDUCCION = 2,
        [Description("Aport")]
        APORTE = 3,
    }
}
