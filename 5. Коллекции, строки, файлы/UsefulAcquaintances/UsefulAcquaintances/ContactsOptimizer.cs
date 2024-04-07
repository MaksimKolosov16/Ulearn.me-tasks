namespace UsefulAcquaintances
{
    public class UsefulAcquaintancesOptimizer
    {
        private class Contact
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string AllInfo { get; set; }
        }

        public static Dictionary<string, List<string>> OptimizeContacts(List<string> contactRecords)
        {
            var dictionary = new Dictionary<string, List<string>>();

            var contacts = ToContacts(contactRecords);

            foreach (var contact in contacts)
            {
                var shortName = GetShortName(contact.Name);

                if (dictionary.ContainsKey(shortName) is false)
                    dictionary[shortName] = new List<string>();

                dictionary[shortName].Add(contact.AllInfo);
            }


            return dictionary;
        }

        private static List<Contact> ToContacts(List<string> contacts)
        {
            var result = new List<Contact>();

            foreach (var contact in contacts)
            {
                var nameAndEmail = contact.Split(':');
                result.Add(new Contact
                {
                    Name = nameAndEmail[0],
                    Email = nameAndEmail[1],
                    AllInfo = contact
                });
            }

            return result;
        }

        private static string GetShortName(string fullName)
        {
            return fullName.Length >= 2
                ? fullName.Substring(0, 2)
                : fullName;
        }
    }
}