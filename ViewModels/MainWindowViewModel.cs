using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Password.Avalonia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _MinCharacters = true;
        public bool MinCharacters
        {
            get 
            {
                return _MinCharacters; 
            }
            set
            {
                if (_MinCharacters != value)
                {
                    _MinCharacters = value;
                }
            }
        }

        private bool _MajCharacters = true;
        public bool MajCharacters
        {
            get 
            {
                return _MajCharacters; 
            }
            set
            {
                if (_MajCharacters != value)
                {
                    _MajCharacters = value;
                }
            }
        }

        private bool _NumCharacters = false;
        public bool NumCharacters
        {
            get 
            {
                return _NumCharacters; 
            }
            set
            {
                if (_NumCharacters != value)
                {
                    _NumCharacters = value;
                }
            }
        }

        private bool _SpeCharacters = false;
        public bool SpeCharacters
        {
            get 
            {
                return _SpeCharacters; 
            }
            set
            {
                if (_SpeCharacters != value)
                {
                    _SpeCharacters = value;
                }
            }
        }

        private int _PasswordLength = 6;
        public int PasswordLength
        {
            get 
            {
                return _PasswordLength; 
            }
            set
            {
                if (_PasswordLength != value)
                {
                    _PasswordLength = value;
                }
            }
        }

        private string _PasswordGenerated = "";

        public string PasswordGenerated
        {
            get 
            {
                return _PasswordGenerated; 
            }
            set
            {
                if (_PasswordGenerated != value)
                {
                    _PasswordGenerated = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void GeneratePassword(){
            string ListChars = "";
            var random = new Random();

            if(MinCharacters){
                ListChars+="abcdefghijklmnopqrstuvwxyz";
            }

            if(MajCharacters){
                ListChars+="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if(NumCharacters){
                ListChars+="0123456789";
            }

            if(SpeCharacters){
                ListChars+="!#%$&@?-_|])([";
            }

            var ListPassword = Enumerable.Repeat(0, PasswordLength).Select(x => ListChars[random.Next(ListChars.Length)]);
            PasswordGenerated = string.Join("", ListPassword);

        }
    }
}
