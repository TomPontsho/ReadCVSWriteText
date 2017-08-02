using LINQtoCSV;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {
    public class PeopleData {

        #region Constructors
        public PeopleData() : this(new List<Person>()) {

        }

        public PeopleData(IEnumerable<Person> people) {

            _people = new List<Person>();

            add(people);
        }
        #endregion // Constructors

        #region Private members
        private List<Person> _people;
        #endregion // Private members

        #region Public members
        public int count {
            get { return _people.Count; }
        }
        public bool hasData() {

            return _people.Count > 0;
        }

        public void add(Person person) {

            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _people.Add(person);     
        }
        public void add(IEnumerable<Person> people) {

            if (people == null)
                throw new ArgumentNullException(nameof(people));

            foreach (Person p in people)
                add(p);    
        }

        public String analyze(Func<IEnumerable<Person>, String> analyzer) {

            return analyzer(_people);
        }
        public void clearData() {

            _people.Clear();
        }
        #endregion // Public members
    }
}
