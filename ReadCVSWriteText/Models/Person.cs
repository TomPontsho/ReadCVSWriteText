using LINQtoCSV;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {

    /// <summary>
    /// A model for a person
    /// </summary>
    public class Person {

        #region Constructors

        public Person() {
            
            _address = new Address();
        }
        /// <summary>
        /// Ensures the model is always in a valid state. Throws ArgumentNullException and ArgumentException
        /// </summary>
        /// <param name="name">The person's name</param>
        /// <param name="surname">The person's surname</param>
        /// <param name="addressHouseStreet">The person's address</param>
        /// <param name="phoneNumber">The person's phone number</param>
        public Person(String name, String surname, String addressHouseStreet, String phoneNumber) {

            this.name = name;
            this.surname = surname;
            this.addressHouseStreet = addressHouseStreet;
            this.phoneNumber = phoneNumber;
        }

        public Person(String name, String surname, Address address, String phoneNumber) {

            this.name = name;
            this.surname = surname;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }
        #endregion // Constructors

        #region Private members
        // Simple phone number regex
        private readonly Regex _phoneRegex = new Regex(@"^[0-9]+$");
        private String _name;
        private String _surname;
        private Address _address;
        private String _phoneNumber;
        #endregion // Private members

        #region Properties
        [CsvColumn(Name = "FirstName", FieldIndex = 1)]
        public String name {

            get { return _name; }

            set {
                // Check for null
                if (value == null) 
                    throw new ArgumentNullException(nameof(name));
                
                // Check for empty parameter
                if (value.Length == 0 )
                    throw new ArgumentException("Empty parameter:" + nameof(name));
                
                /*
                 * Name regex not validated. Too wide of a scope.
                 * Also, any random "valid" set of charactors such as Kadukukukukula or Hahahahaha, 
                 * would pass :-), yet not really valid 
                 */

                _name = value;
            }
        }

        [CsvColumn(Name = "LastName", FieldIndex = 2)]
        public String surname {

            get { return _surname; }

            set {
                // Check for null
                if (value == null)
                    throw new ArgumentNullException(nameof(surname));
                
                // Check for empty parameter
                if (value.Length == 0)
                    throw new ArgumentException("Empty parameter:" + nameof(surname));

                /*
                 * Surname regex not validated. Too wide of a scope.
                 * Also, any random "valid" set of charactors such as Kadukukukukula or Hahahahaha, 
                 * would pass :-), yet not really valid 
                 */

                _surname = value;
            }
        }

        /// <summary>
        /// The house number and street name seperated by a space
        /// </summary>
        [CsvColumn(Name = "Address", FieldIndex = 3)]
        public String addressHouseStreet {

            get { return address.houseStreet; }

            set {
                address = new Address(value);
            }
        }
        /// <summary>
        /// The model for the address, which is always equivalent to addressHouseStreet
        /// </summary>
        public Address address {
            get { return _address; }

            set {
                // Check for null
                if (value == null)
                    throw new ArgumentNullException(nameof(address));

                this._address = value;
            }
        }

        /// <summary>
        /// Must not contain any charactors other than digits
        /// </summary>
        [CsvColumn(Name = "PhoneNumber", FieldIndex = 4)]
        public String phoneNumber {

            get { return _phoneNumber; }

            set {
                // Check for null
                if (value == null)
                    throw new ArgumentNullException(nameof(phoneNumber));

                // Check for empty parameter
                if (value.Length == 0) 
                    throw new ArgumentException("Empty parameter:" + nameof(phoneNumber));

                // Validate phone number
                if (!_phoneRegex.IsMatch(value))
                    throw new ArgumentException("Invalid phone number: " + value +
                        "' . Must satisfy regex: '" + _phoneRegex.ToString() + "'.");
                
                this._phoneNumber = value;
            }
        }
        #endregion // Properties
    }
}
