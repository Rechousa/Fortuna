using System.Linq;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public class RandomListValuePersonAddress : RandomListValue<string>
    {
        public RandomListValuePersonAddress()
        {
            names.Add("Avenida");
            names.Add("Estrada");
            names.Add("Largo");
            names.Add("Lugar");
            names.Add("Passeio");
            names.Add("Praceta");
            names.Add("Praça");
            names.Add("Rua");
            names.Add("Travessa");
            names.Add("Viela");
        }

        public string GetRandomValue(IRandomListValue<string>[] randomLists)
        {
            var validLists = randomLists?.Where(t => t != null).ToArray();

            if(validLists == null || validLists.Length == 0)
            {
                return names.PickRandom();
            }

            var sb = new StringBuilder();
            sb.Append($" {names.PickRandom()}");

            foreach (var item in validLists)
            {
                sb.Append($" {item.GetRandomValue()}");

            }
            return sb.ToString().Trim();
        }
    }
}
