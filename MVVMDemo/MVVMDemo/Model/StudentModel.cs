using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MVVMDemo.Model
{
    public class StudentModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
        private Regex phoneRegex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        private Regex nameRegex = new Regex(@"/^[A - Za - z] +$/");
        string[] stateName;
        string[] cityName1;
        string[] cityName2;
        string[] cityName3;
        string[] cityName4;
        string[] cityName5;
        string[] cityName6;
        string[] cityName7;
        public StudentModel()
        {
            Name = string.Empty;
            Phone_Number = string.Empty;
            Email_ID = string.Empty;
            Address = string.Empty;
            Gender = string.Empty;
            BloodGroup = string.Empty;
            State = string.Empty;
            City = string.Empty;

            BloodGroupList = new List<string>();
            string[] bloodGroupName = { "--Select Blood Group--", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            BloodGroupList.AddRange(bloodGroupName);
            SelectedBloodGroupIndex = 0;
            IsBloodGroupComboBoxEditable = true;

            StateList = new List<string>();
            stateName = new string[]{ "--Select state--", "Maharashtra", "Andra Pradesh", "Karnataka", "Kerala", "Madhya Pradesh", "Gujarat", "Rajasthan"};
            StateList.AddRange(stateName);
            SelectedStateIndex = 0;
            IsStateComboBoxEditable = true;
       
            UpdateCities();

        }
        private void UpdateCities()
        {
            cityName1 = new string[] {"Mumbai", "Pune", "Thane", "Nashik", "Nagpur" };
            cityName2 = new string[] {"Hyderabad", "Visakhapatnam", "Vijayawada", "Warangal", "Krishna" };
            cityName3 = new string[] {"Bangalore", "Mangalore", "Mysore", "Hubli-Dharwad", "Chikmagalur" };
            cityName4 = new string[] {"Trivandrum", "Kollam", "Kozhikode", "Sulthan Bathery", "Kochi" };
            cityName5 = new string[] {"Bhopal", "Ujjain", "Jabalapur", "Indore", "Patna" };
            cityName6 = new string[] {"Ahemdabad", "Surat", "Rajkot", "Jamnagar", "Porbandar" };
            cityName7 = new string[] {"Jaipur", "Jhodhpur", "Udhaipur", "Ajmer", "Kota" };
        }
        private void UpdateCityListComboBox()
        {
           
            if (State == "Maharashtra")
            {
                foreach (var city in cityName1)
                    CityList.Add(city);
               // CityList.AddRange(cityName1);
            }
            else if (State == "Andra Pradesh")
            {
                foreach (var city in cityName2)
                    CityList.Add(city);
               // CityList.AddRange(cityName2);
            }
            else if (State == "Karnataka")
            {
                CityList.AddRange(cityName3);
            }
            else if (State == "Kerala")
            {
                CityList.AddRange(cityName4);
            }
            else if(State == "Madhya Pradesh")
            {
                CityList.AddRange(cityName5);
            }
            else if (State == "Gujarat")
            {
                CityList.AddRange(cityName6);
            }
            else if (State == "Rajasthan")
            {
                CityList.AddRange(cityName7);
            }
            SelectedCityIndex = 0;
        }

        private string name;
        private string phoneNumber;
        private string emailid;
        private string address;
        private string gender;
        private string dob;
        private string bloodGroup;
        List<string> bloodgroupList;
        private string state;
        List<string> stateList;
        private string city;
        List<string> cityList;

        private int selectedBloodGroupIndex;
        private bool isBloodGroupComboBoxEditable;
        private int selectedStateIndex;
        private bool isStateComboBoxEditable;
        private int selectedCityIndex;
        private bool isCityComboBoxEditable;

        private string error;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Phone_Number
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("Phone_Number");
            }
        }
        public string Email_ID
        {
            get => emailid;
            set
            {
                emailid = value;
                OnPropertyChanged("Email_ID");
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public string DOB
        {
            get => dob;
            set
            {
                dob = value;
                OnPropertyChanged("DOB");
            }
        }
        public string BloodGroup
        {
            get => bloodGroup;
            set
            {
                bloodGroup = value;
                OnPropertyChanged("BloodGroup");
            }
        }
        public List<string> BloodGroupList
        {
            get => bloodgroupList;
            set
            {
                bloodgroupList = value;
                OnPropertyChanged("BloodGroupList");
            }
        }
        public string State
        {
            get => state;
            set
            {
                if (value != string.Empty && value != state)
                {
                    state = value;
                    UpdateCityListComboBox();
                    OnPropertyChanged("State");
                }

            }
        }
        public List<string> StateList
        {
            get => stateList;
            set
            {
                stateList = value;
                OnPropertyChanged("StateList");
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }
        public List<string> CityList
        {
            get => cityList;
            set
            {
                cityList = value;
                OnPropertyChanged("CityList");
            }
        }
        public int SelectedBloodGroupIndex
        {
            get => selectedBloodGroupIndex;
            set
            {
                selectedBloodGroupIndex = value;
                OnPropertyChanged("SelectedBloodGroupIndex");
            }
        }
        public bool IsBloodGroupComboBoxEditable
        {
            get => isBloodGroupComboBoxEditable;
            set
            {
                isBloodGroupComboBoxEditable = value;
                OnPropertyChanged("IsBloodGroupComboBoxEditable");
            }
        }
        public int SelectedStateIndex
        {
            get => selectedStateIndex;
            set
            {
                selectedStateIndex = value;
                OnPropertyChanged("SelectedStateIndex");
            }
        }
        public bool IsStateComboBoxEditable
        {
            get => isStateComboBoxEditable;
            set
            {
                isStateComboBoxEditable = value;
                OnPropertyChanged("IsStateComboBoxEditable");
            }
        }
        public int SelectedCityIndex
        {
            get => selectedCityIndex;
            set
            {
                selectedCityIndex = value;
                OnPropertyChanged("SelectedCityIndex");
            }
        }
        public bool IsCityComboBoxEditable
        {
            get => isCityComboBoxEditable;
            set
            {
                isCityComboBoxEditable = value;
                OnPropertyChanged("I" +
                    "sCityComboBoxEditable");
            }
        }

        #region Validation 
        public string Error
        {
            get { return error; }
        }
        public bool ISValidName
        { 
            get { return nameRegex.IsMatch(Name); }
        }
        public bool IsValidEmailAddress 
        {
            get { return emailRegex.IsMatch(Email_ID); }
        }
        public bool ISValidPhoneNumber
        { 
            get { return phoneRegex.IsMatch(Phone_Number); }
        }
        public string this[string columnName]
        {
            get
            {
                error = string.Empty;
                if (columnName == "Name" && Name != string.Empty && !ISValidName)
                {
                    error = "Please input alphabets are required!";
                }
                else if(columnName == "EMail" && Email_ID != string.Empty && !IsValidEmailAddress)
                {
                    error = "Please enter valid email address!";

                }
                else if (columnName == "Phone" && Phone_Number != string.Empty && !ISValidPhoneNumber)
                {
                    error = "Please input digits are required!";
                }
                return error;
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}