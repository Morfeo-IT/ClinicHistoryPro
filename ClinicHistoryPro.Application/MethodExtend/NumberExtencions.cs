namespace ClinicHistoryPro.Application.MethodExtend
{
    public static class NumberExtencions
    {
        public static decimal Truncate(this double value, int decimals)
        {
            double aux_value = Math.Pow(10, decimals);
            return (decimal)(Math.Truncate(value * aux_value) / aux_value);
        }
        
        public static decimal Truncate(this decimal value, int decimals)
        {
            return decimal.Round(value, decimals);
        }
    }
}
