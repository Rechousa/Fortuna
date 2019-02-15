namespace Fortuna.Infrastructure.Data
{
    public class RandomListValuePersonConvencao : RandomListValue<string>
    {
        public RandomListValuePersonConvencao()
        {
            names.Add(null);
            names.Add("");
            names.Add("ADSE");
            names.Add("Medicare");
            names.Add("Médis");
            names.Add("SAMS");
            names.Add("SNS");
        }
    }
}
