using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = ReadAccounts();
            Boolean exit = false;
            
            while (!exit) {
                switch (menu()) {
                    case "1": // View accounts
                        PrintAccounts(accounts);
                    break;

                    case "2": // View account by number
                        Console.WriteLine("Enter id: ");
                        String id = Console.ReadLine();
                        List<Account> list = new List<Account>();

                        foreach (var account in accounts) {
                            if (account.Number.ToString().Equals(id)) {
                                list.Add(account);
                            }
                        }
                        PrintAccounts(list);
                    break;

                    case "3": // Search
                        Console.WriteLine("Enter search value (wildcard search)");
                        String search = Console.ReadLine();
                        List<Account> result = new List<Account>();

                        foreach(var account in accounts) {
                            if (
                                account.Number.ToString().Equals(search) || 
                                account.Label.Contains(search) || 
                                account.Owner.ToString().Contains(search)) {
                                    
                                if (!result.Contains(account)) 
                                    result.Add(account);
                            }
                        }

                        PrintAccounts(result);

                    break;

                    case "4": // Move
                        Console.WriteLine("Enter account number to move money FROM");
                        String from = Console.ReadLine();
                        Console.WriteLine("Enter account number to move money TO");
                        String to = Console.ReadLine();

                        Account accFrom = null;
                        Account accTo = null; 

                        foreach(var account in accounts) {
                            if (account.Number.ToString().Equals(from)) {
                                accFrom = account;
                            }
                            else if (account.Number.ToString().Equals(to)) {
                                accTo = account;
                            }   
                        }

                        if (accFrom != null && accTo != null) {
                            accTo.Balance += accFrom.Balance;
                            accFrom.Balance = 0;

                            /*foreach(var account2 in accounts) {
                                Console.WriteLine(account2.ToString());
                            }*/
                            String str = JsonSerializer.Serialize(accounts);
                            Console.WriteLine(str);

                            SaveAccounts(accounts);
                        }
                        else {
                            Console.WriteLine("1 or both of the account numbers couldnt be found"); 
                        }
                        
                    break;

                    case "0": // Exit
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("Invalid menu option!\n");
                    break;
                }
            }
        }

        static String menu() {
            Console.WriteLine("1. View accounts");
            Console.WriteLine("2. View account by number");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Move");
            Console.WriteLine("0. Exit\n");

            return Console.ReadLine();
        }        

        static void PrintAccounts(IEnumerable<Account> accounts) {
            Console.WriteLine("+----------+----------+----------+----------+");
            Console.WriteLine("| Number   | Balance  | Label    | Owner    |");

            foreach(var account in accounts) {
                Console.WriteLine("+----------+----------+----------+----------+");
                
                String numberStr = " ";
                numberStr += account.Number;
                // dynamically adding whitespace for the number string to fit the table box
                for (int i=0; i<(9-account.Number.ToString().Length); i++) {
                    numberStr += " ";
                }
                
                String balanceStr = " ";
                balanceStr += account.Balance;
                // dynamically adding whitespace for the balance string to fit the table box
                for (int i=0; i<(9-account.Balance.ToString().Length); i++) {
                    balanceStr += " ";
                }

                String labelStr = " ";
                labelStr += account.Label;
                // dynamically adding whitespace for the label string to fit the table box
                for (int i=0; i<(9-account.Label.Length); i++) {
                    labelStr += " ";
                }

                String ownerStr = " ";
                ownerStr += account.Owner;
                // dynamically adding whitespace for the balance string to fit the table box
                for (int i=0; i<(9-account.Owner.ToString().Length); i++) {
                    ownerStr += " ";
                }

                Console.WriteLine("|"+numberStr+"|"+balanceStr+"|"+labelStr+"|"+ownerStr+"|");
            }

            Console.WriteLine("+----------+----------+----------+----------+");
        }

        static IEnumerable<Account> ReadAccounts()
        {
            String file = "../../account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();
                // Console.WriteLine(data);

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

                //Console.WriteLine(json[0]);
                return json;
            }
        }

        static void SaveAccounts(IEnumerable<Account> accounts) {
            String file = "../../account.json";

            String str = JsonSerializer.Serialize(accounts, new JsonSerializerOptions {
                WriteIndented = true
            });

            System.IO.File.WriteAllText(file, str);
        }

        static void SaveAccounts2(IEnumerable<Account> accounts)
        {
            String file = "../../account.json";

            using (var outputStream = File.OpenWrite(file))
            {
                JsonSerializer.Serialize<IEnumerable<Account>>(
                    new Utf8JsonWriter (
                        outputStream,
                        new JsonWriterOptions {
                            SkipValidation = true,
                            Indented = true
                        }
                    ),
                    accounts
                );
                
            }
        }
    }

    public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize<Account>(this);
        }
    }
}
