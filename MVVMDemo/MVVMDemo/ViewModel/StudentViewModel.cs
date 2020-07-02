using MVVMDemo.Command;
using MVVMDemo.Model;
using MVVMDemo.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{ 
    public class StudentViewModel
    {
        private ICommand iCommand;
        public StudentModel Model { get; set; } = new StudentModel();
        private Window View;
        private GenderEnum selectedGender;
        public StudentViewModel(Window window)
        {
            View = window;
            SelectedGender = GenderEnum.Male;
        }
        public GenderEnum SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                if(selectedGender == GenderEnum.Male)
                {
                    Model.Gender = GenderEnum.Male.ToString();
                }
                else
                {
                    Model.Gender = GenderEnum.Female.ToString();
                }
            }
        }
        public ICommand ShowDataButtonCommand
        {
            get
            {
                iCommand = new ModelCommand(ShowData, IsSavebtnEnabled);
                return iCommand;
            }
        }
        private bool IsSavebtnEnabled()
        {
            if (Model.Name != string.Empty && Model.IsValidName && Model.Phone_Number != string.Empty && 
                    Model.IsValidPhoneNumber && Model.Email_ID != string.Empty && Model.IsValidEmailAddress &&
                    Model.Address != string.Empty && Model.Gender != string.Empty && Model.DOB != string.Empty &&
                    Model.BloodGroup != string.Empty && Model.State != string.Empty && Model.City != string.Empty)
                 return true;
            return false;
        }
        private void ShowData(object obj)
        {
            string showData = "Name : " + Model.Name + "\nPhone Number : " + Model.Phone_Number +
                              "\nEmail-Id : " + Model.Email_ID + "\nAddress : " + Model.Address +
                              "\nGender : " + Model.Gender + "\nDoB : " + Model.DOB +
                              "\nBlood group : " + Model.BloodGroup + "\nState : " + Model.State +
                              "\nCity : " + Model.City;
            MessageBox.Show(showData, "User Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public ICommand ClearButtonCommand
        {
            get
            {
                iCommand = new ModelCommand(Clear, IsClearbtnEnabled);
                return iCommand;
            }
        }
        private bool IsClearbtnEnabled()
        {
            if (Model.Name != string.Empty && Model.Phone_Number != string.Empty && 
                Model.Email_ID != string.Empty && Model.Address != string.Empty)
                return true;
            return false;
        }
        private void Clear(object obj)
        {
            Model.Name = string.Empty;
            Model.Phone_Number = string.Empty;
            Model.Email_ID = string.Empty;
            Model.Address = string.Empty;
        }
        public ICommand CancelButtonCommand
        {
            get
            {
                iCommand = new ModelCommand(Cancel);
                return iCommand;
            }
        }
        private void Cancel(object obj)
        {
            StudentView studentView = obj as StudentView;
            studentView.Close();
        }
        public enum GenderEnum
        {
            Male,
            Female
        }
    }
  
}