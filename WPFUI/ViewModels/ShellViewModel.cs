using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
		private string _firstName;
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people;
        public ShellViewModel()
		{
			People = new BindableCollection<PersonModel>
			{
				new PersonModel { FirstName = "Mehul", LastName = "Manhas" },
				new PersonModel {FirstName = "Alpha", LastName = "Harsh" }
			};
            //People.Add(new PersonModel("Meh", "Man"));
        }
        public string FirstName
		{
			get { return _firstName; }
			set 
			{
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set 
			{
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
		}
        public string FullName 
		{
			get { return $"{ FirstName } { LastName }"; }
		}
		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set 
			{ 
				_people = value;
                NotifyOfPropertyChange(() => People);
            }
		}
		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set 
			{
				_selectedPerson = value; 
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}
		public bool CanClearText(string firstName, string lastName)
		{
			return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
		}
		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}
		public void LoadPageOne()
		{
			ActivateItemAsync(new FirstChildViewModel());
		}
        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
}
