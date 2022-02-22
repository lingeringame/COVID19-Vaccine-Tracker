using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Patient
    {
        // Perform data validation the long way
        // Since project is not in .net 8 cannot use nullable types and if you return => property name it will cause a 
        // Stack over flow only way to add data validation is to have a public field and set and get this value inside each propoerty
        // Note properties must be the same as columns in SQL inorder for Dapper to map correctly
        public string id;
        public string first_name;
        public string middle_name;
        public string last_name;
        public DateTime date_of_birth;
        public string street_address;
        public string city;
        public string county;
        public string state;
        public string zipcode;
        public string race1;
        public string race2;
        public string ethnicity;
        public string sex;
        public string extract_type;

        // Note value is build in variable it is the obj being passed in to the property when called
        public string Id
        {
            get => this.id; // The "getter" is a lambda that returns the value of Id property 
            set
            {
                try // Surronding with try should catch errors wrong data type
                {
                    if (value.Length > 10) // If string longer then 10 chars
                        throw new Exception("Id must be 10 characters or less");
                    else if (string.IsNullOrEmpty(value)) // If string is null or empty
                        throw new Exception("Id cannot be empty or null");
                    else
                        this.id = value; // If good assign value to Id
                }
                catch (Exception ex) 
                { throw ex; }
            }
        }


        public string First_name 
        {
            get => this.first_name;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 25)
                        throw new Exception("First name must be 25 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("First name cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("First name cannot be numeric");
                    else
                        this.first_name = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }

 
        public string Middle_name
        {
            get => this.middle_name;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 35)
                        throw new Exception("Middle name must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Middle name cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Middle name cannot be numeric");
                    else
                        this.middle_name = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        public string Last_name
        {
            get => this.last_name;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 35)
                        throw new Exception("Last name must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Last name cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Last name cannot be numeric");
                    else
                        this.last_name = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        // Need to add a little more validation for date need to look into it
        public DateTime Date_of_birth
        {
            get => this.date_of_birth;
            set
            {
                try
                {
                    if (value.AddYears(-110) >= value || value >= DateTime.Today)
                        throw new Exception("Invalid date of birth");
                    else if (string.IsNullOrEmpty(value.ToString()))
                        throw new Exception("Date of birth cannot be empty or null");
                    else
                        this.date_of_birth = value;
                }
                catch (Exception ex)
                { throw ex; }
                    
            }
        }

        
        public string Street_address
        {
            get => this.street_address;
            set
            {
                try
                {
                    if (value.Length > 100)
                        throw new Exception("Street address must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Street address cannot be empty or null");
                    else
                        this.street_address = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }


        public string City
        {
            get => this.city;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 100)
                        throw new Exception("City must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("City cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("City cannot be numeric");
                    else
                        this.city = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }


        public string County
        {
            get => this.county;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 100)
                        throw new Exception("County must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("County cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("County cannot be numeric");
                    else
                        this.county = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        public string State
        {
            get => this.state;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 50)
                        throw new Exception("State must be 50 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("State cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("State cannot be numeric");
                    else
                        this.state = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }


        public string Zipcode
        {
            get => this.zipcode;
            set
            {
                try
                {
                    if (value.Length != 5)
                        throw new Exception("Zipcode must be 5 characters");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Zipcode cannot be empty or null");
                    else
                        this.zipcode = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        public string Race1
        {
            get => this.race1;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 75)
                        throw new Exception("Race must be 75 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Race cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Race cannot be numeric");
                    else
                        this.race1 = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        public string Race2
        {
            get => this.race2;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 75)
                        throw new Exception("Race must be 75 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Race cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Race cannot be numeric");
                    else
                        this.race2 = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }

        // Ethnicity code is stored in patient info
        public string Ethnicity
        {
            get => this.ethnicity;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 6)
                        throw new Exception("Ethnicity code must be 6 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Ethnicity cannot be empty or blank");
                    else if (isNumeric || isDouble)
                        throw new Exception("Ethnicity cannot be numeric");
                    else
                        this.ethnicity = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }


        public string Sex
        {
            get => this.sex;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 10)
                        throw new Exception("Sex must be 10 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Sex cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Sex cannot be numeric");
                    else
                        this.sex = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }


        public string Extract_Type
        {
            get => this.extract_type;
            set
            {
                try
                {
                    // TryParse will parse a string to an int and return an out variable
                    // But having out _ discards the out variable  so this isNumeric will dettermine
                    // If string is numeric
                    bool isNumeric = int.TryParse(value, out _);
                    // Dose same as above but for double
                    bool isDouble = double.TryParse(value, out _);

                    if (value.Length > 15)
                        throw new Exception("Extract type must be 15 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Extract type cannot be empty or null");
                    else if (isNumeric || isDouble)
                        throw new Exception("Extract type cannot be numeric");
                    else
                        this.extract_type = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        // method to copy a Patient object allows you to assign a copy of a patient to another patient obj
        public Patient CopyPatient()
        {
            return (Patient)this.MemberwiseClone();
        }
    }
}
