using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {

    /// <summary>
    /// A street address model. House number and street name.
    /// </summary>
    public class Address {

        #region Constructor
        public Address () { }
        /// <summary>
        /// Creates a address based on a house number and street name
        /// </summary>
        /// <param name="address">The first space must seperate the house number and the street name</param>
        public Address(String address) {

            // Check for null address
            if (address == null) 
                throw new ArgumentNullException(nameof(address));

            // Check for empty address
            if (address.Length == 0 )
                throw new ArgumentException("Empty parameter:" + nameof(address));
            
            // Check for house number and streen name
            int indexOfFirstSpace = address.IndexOf(' ');
            if (indexOfFirstSpace == -1)  
                throw new ArgumentException("Invalid address: '" + address +
                    "'. Must have house number and street name.");
            
            this.houseNumber = address.Substring(0, indexOfFirstSpace);
            this.streetName = address.Substring(indexOfFirstSpace + 1);
        }
        
        public Address(String houseNumber, String streetName) {

            this.houseNumber = houseNumber;
            this.streetName = streetName;
        }
        #endregion // Constructor

        #region Private members
        // Simple house number regex
        private readonly Regex _houseRegex = new Regex(@"^[0-9]([a-zA-Z0-9]*?)$");

        // Simple street name regex
        private readonly Regex _streetRegex = new Regex(@"^[a-zA-Z0-9].");               

        private String _houseNumber = "";
        private String _streetName = "";
        #endregion // Private members

        #region Public members
        /// <summary>
        /// First charactor must be a number, subsequent charators can be alphabets
        /// </summary>
        public String houseNumber {

            get { return _houseNumber; }

            set {
                // Check for null
                if (value == null)
                    throw new ArgumentNullException(nameof(houseNumber));
                
                // Check for empty parameter
                if (value.Length == 0)
                    throw new ArgumentException("Empty parameter:" + nameof(houseNumber));

                if (!_houseRegex.IsMatch(value))
                    throw new ArgumentException("Invalid house number: '" + value +
                        "' . Must satisfy regex: '" + _houseRegex.ToString() + "'.");
                
                this._houseNumber = value;
            }
        }
        public String streetName {

            get { return _streetName; }

            set {
                // Check for null
                if (value == null) 
                    throw new ArgumentNullException(nameof(streetName));

                // Check for empty parameter
                if (value.Length == 0) 
                    throw new ArgumentException("Empty parameter:" + nameof(streetName));
                
                if (!_streetRegex.IsMatch(value))
                    throw new ArgumentException("Invalid street name: " + value +
                        "' . Must satisfy regex: '" + _streetRegex.ToString() + "'.");
                
                this._streetName = value;
            }
        }
        /// <summary>
        /// House number and street name seperated by a space
        /// </summary>
        public String houseStreet {
            get { return this.houseNumber + " " + this.streetName; }
        }
        #endregion // Public members
    }
}
