using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U7
{
    // ---------------------------------------------------------
    class Program {
        static void Main(string[] args) {
            List<Person> theDudes = new List<Person>();

            theDudes.Add(new Person("Mark", "Muster", Sprache.Deutsch));
            theDudes.Add(new Person("Jean", "Dupont", Sprache.Französisch));
            theDudes.Add(new Person("John", "Doe", Sprache.Englisch));

            // We could also use an implicit 'var'
            foreach (Person dude in theDudes) {
                dude.SageHallo();
            }
        }
    }
    // ---------------------------------------------------------

    class Person
    {
        private string vorname;
        private string nachname;
        private Sprache sprache;

        public Person(string vorname, string nachname, Sprache sprache)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.sprache = sprache;
        }

        public void SageHallo()
        {
            if(sprache == Sprache.Deutsch)
            {
                Console.WriteLine("Guten Tag ich heisse {0} {1}", vorname, nachname);
            } else if (sprache == Sprache.Französisch)
            {
                Console.WriteLine("Bonjour je m'appelle {0} {1}", vorname, nachname);
            } else if (sprache == Sprache.Englisch)
            {
                Console.WriteLine("Hello my name is {0} {1}", vorname, nachname);
            }
            else
            {
                Console.WriteLine("nuqneH");
            }
        }
    }
    enum Sprache { Deutsch, Französisch, Englisch}

}
