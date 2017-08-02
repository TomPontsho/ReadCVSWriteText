using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {
    public static class PeopleAnalyzer {
        /// <summary>
        /// Gets the frequency of the first and last names ordered by 
        /// frequency descending and then alphabetically ascending
        /// </summary>
        /// <param name="people">Persons to be analyzed</param>
        /// <returns></returns>
        public static String freq9to0NamesZtoA(IEnumerable<Person> people) {

            Dictionary<String, int> dictionary = new Dictionary<string, int>();

            foreach(Person p in people) {

                if (dictionary.ContainsKey(p.name))
                    ++dictionary[p.name];
                else
                    dictionary.Add(p.name, 1);

                if (dictionary.ContainsKey(p.surname))
                    ++dictionary[p.surname];
                else
                    dictionary.Add(p.surname, 1);
            }

            dictionary.OrderBy(freq => freq.Value).ThenByDescending(name => name.Value);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var kv in dictionary)
                stringBuilder.Append(kv.Key + ", " + kv.Value.ToString() + Environment.NewLine);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Gets the addresses sorted alphabetically by street name
        /// </summary>
        /// <param name="people">Persons to be analyzed</param>
        /// <returns></returns>
        public static String addressAtoZ0to9(IEnumerable<Person> people) {

            List<Address> addresses = new List<Address>();

            foreach (Person p in people)
                addresses.Add(p.address);

            // Street names with numbers last
            addresses.OrderBy(addr => addr.streetName);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var addr in addresses)
                stringBuilder.Append(addr.houseStreet + Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
