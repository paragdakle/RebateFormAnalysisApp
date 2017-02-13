using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

  
namespace Asg3_pxd160530
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>class Validation</c>
    /// This class consists of methods for performing various validations.
    /// </summary>
    class Validation
    {
        /// <summary>
        /// The function validates whether all the mandatory TextBox Controls of a given <c>Form</c> object are either Null, Empty or contain whitespaces only.
        /// </summary>
        /// <param name="form">The form object.</param>
        /// <param name="visualAid">Indicates whether the background of invalid TextBox Controls should be turned Red to provide a visual aid to the user.</param>
        /// <returns>True if all TextBox Controls are valid else false.</returns>
        public bool validateMandatoryFields(Form1 form, bool visualAid)
        {
            var error = true;
            foreach (TextBox tb in form.Controls.OfType<TextBox>().Where(x => x.CausesValidation))
            {
                if (String.IsNullOrWhiteSpace(tb.Text))
                {
                    if(visualAid)
                        tb.BackColor = Color.Red;
                    error = false;
                }
            }
            return error;
        }

        /// <summary>
        /// The function validates given name with a regex. The regex accepts a name with valid alphabets and may contain '.','- ',' '.
        /// </summary>
        /// <param name="name">Name to validate</param>
        /// <returns>True if name is valid else false.</returns>
        public bool validateName(string name)
        {
            return Regex.IsMatch(name, @"^[\p{L} \.\-]+$");
        }

        /// <summary>
        /// The function validates given middle initial with a regex. The regex accepts a middle initial with alphabets only and of length 1.
        /// </summary>
        /// <param name="middleInitial">Middle initial to validate</param>
        /// <returns>True if middle initial is valid else false.</returns>
        public bool validateMiddleInitial(string middleInitial)
        {
            return Regex.IsMatch(middleInitial, @"^[a-zA-Z]$");
        }

        /// <summary>
        /// The function validates given city with a regex. The regex accepts a city with valid alphabets and may contain '- ',' '.
        /// </summary>
        /// <param name="city">City to validate</param>
        /// <returns>True if city is valid else false.</returns>
        public bool validateCity(string city)
        {
            return Regex.IsMatch(city, @"^[a-zA-Z\- ]+$");
        }

        /// <summary>
        /// The function validates given state with a regex. The regex accepts a state with valid alphabets of length 2.
        /// </summary>
        /// <param name="state">State to validate</param>
        /// <returns>True if state is valid else false.</returns>
        public bool validateState(string state)
        {
            return Regex.IsMatch(state, @"^[A-Za-z]{2}$");
        }

        /// <summary>
        /// The function validates given zip code with a regex. The regex accepts a zipcode of the form XXXXX or XXXXX-XXXX where X = {1-9}.
        /// </summary>
        /// <param name="zipCode">Zip code to validate</param>
        /// <returns>True if zip code is valid else false.</returns>
        public bool validateZipCode(string zipCode)
        {
            return Regex.IsMatch(zipCode, @"^\d{5}(?:[-\s]\d{4})?$");
        }

        /// <summary>
        /// The function validates given phoneNumber with a regex. The regex accepts a phone number with valid numbers and special characters from '+', '-', 'x', ' ', '(', ')'.
        /// </summary>
        /// <param name="phoneNumber">Phone number to validate</param>
        /// <returns>True if phone number is valid else false.</returns>
        public bool validatePhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^[a-zA-Z\- ]+$");
        }

        /// <summary>
        /// The function validates given email address with a regex.
        /// </summary>
        /// <param name="emailAddress">Email address to validate</param>
        /// <returns>True if email address is valid else false.</returns>
        public bool validateEmailAddress(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }
    }
}
