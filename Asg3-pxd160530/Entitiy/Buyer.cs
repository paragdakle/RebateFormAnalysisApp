using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_pxd160530.Entitiy
{
    /// <remarks>
    /// Author: Parag Pravin Dakle
    /// Course: Human Computer Interaction CS 6326 Spring 2017
    /// Net ID: pxd160530
    /// </remarks>
    /// <summary>
    /// <c>class Buyer</c>
    /// The rebate form Buyer entity model class.
    /// </summary>
    class Buyer
    {
        public Buyer()
        {
            firstName = middleInitial = lastName = addressLine1 = addressLine2 = city = state = zipCode = phoneNumber = email = dateReceived = creationStartTime = creationEndTime = "";
            creationErrorCount = 0;
            proofOfPurchase = true;
        }

        public Buyer(Buyer buyer)
        {
            firstName = buyer.firstName;
            middleInitial = buyer.middleInitial;
            lastName = buyer.lastName;
            addressLine1 = buyer.addressLine1;
            addressLine2 = buyer.addressLine2;
            city = buyer.city;
            state = buyer.state;
            zipCode = buyer.zipCode;
            phoneNumber = buyer.phoneNumber;
            email = buyer.email;
            proofOfPurchase = buyer.proofOfPurchase;
            dateReceived = buyer.dateReceived;
            creationStartTime = buyer.creationStartTime;
            creationEndTime = buyer.creationEndTime;
            creationErrorCount = buyer.creationErrorCount;
        }
        public bool populateBuyer(string csvEntry)
        {
            string[] elements = csvEntry.Split(csvSeparator);
            if (elements.Length == 15)
            {
                firstName = elements[0];
                middleInitial = elements[2];
                lastName = elements[1];
                addressLine1 = elements[3];
                addressLine2 = elements[4];
                city = elements[5];
                state = elements[6];
                zipCode = elements[7];
                phoneNumber = elements[8];
                email = elements[9];
                proofOfPurchase = Convert.ToBoolean(elements[10]);
                dateReceived = elements[11];
                creationStartTime = elements[12];
                creationEndTime = elements[13];
                creationErrorCount = Convert.ToInt16(elements[14]);
                return true;
            }
            return false;
        }

        readonly char csvSeparator = '\t';

        public string firstName { get; set; }

        public string middleInitial { get; set; }

        public string lastName { get; set; }

        public string addressLine1 { get; set; }

        public string addressLine2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zipCode { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public bool proofOfPurchase { get; set; }

        public string dateReceived { get; set; }

        public string creationStartTime { get;  set; }

        public string creationEndTime { get; set; }

        public int creationErrorCount { get; set; }

        public string getFullName()
        {
            return firstName + " " + middleInitial + " " + lastName;
        }

        public override string ToString()
        {
            return firstName + csvSeparator + lastName + csvSeparator + middleInitial + csvSeparator + 
                addressLine1 + csvSeparator + addressLine2 + csvSeparator + city + csvSeparator + state + csvSeparator + zipCode + csvSeparator + 
                phoneNumber + csvSeparator + email + csvSeparator + Convert.ToString(proofOfPurchase) + csvSeparator + dateReceived + 
                csvSeparator + creationStartTime + csvSeparator + creationEndTime + csvSeparator + creationErrorCount;
        }
    }
}
