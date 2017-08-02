using LINQtoCSV;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {

    /// <summary>
    /// A model for people data read from a CSV file (my DB later)
    /// </summary>
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
        /// <summary>
        /// How many people are stored
        /// </summary>
        public int count {
            get { return _people.Count; }
        }

        /// <summary>
        /// Return true if there is at least on person added, false if zero
        /// </summary>
        /// <returns></returns>
        public bool hasData() {

            return _people.Count > 0;
        }
        /// <summary>
        /// Adds the given person. Null not allowed. Does not check for repetitions
        /// </summary>
        /// <param name="person">The person to be added</param>
        public void add(Person person) {

            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _people.Add(person);     
        }
        /// <summary>
        /// Adds the given collection of people. Null not allowed. Does not check for repetitions
        /// </summary>
        /// <param name="people">The people to add</param>
        public void add(IEnumerable<Person> people) {

            if (people == null)
                throw new ArgumentNullException(nameof(people));

            foreach (Person p in people)
                add(p);    
        }
        /// <summary>
        /// Takes a function that performs some analysis on people, and returns a string.
        /// </summary>
        /// <param name="analyzer">A method that analayzes people and returns a string</param>
        /// <returns>String output of the analysis</returns>
        public String analyze(Func<IEnumerable<Person>, String> analyzer) {

            return analyzer(_people);
        }
        /// <summary>
        /// Removes all people that have been added
        /// </summary>
        public void clearData() {

            _people.Clear();
        }
        #endregion // Public members
    }
}
