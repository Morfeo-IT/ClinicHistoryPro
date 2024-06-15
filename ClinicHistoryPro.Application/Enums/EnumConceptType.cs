using System.ComponentModel;

namespace ClinicHistoryPro.Application.Enums
{
    public enum EnumConceptType
    {
        [Description("Ingreso")]
        INGRESO = 1,
        [Description("Deducci�n")]
        DEDUCCION = 2,
        [Description("Aport")]
        APORTE = 3,
    }
}
