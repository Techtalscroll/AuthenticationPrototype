using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AuthenticationPrototype.Authentication;
namespace AuthenticationPrototype.ViewModels
{   
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _outputMessage = string.Empty;   
        private Account _account = new Account();

        public string Username {
            get => _username;
            set { _username = value; OnPropertyChanged(); } }

        public string Password {
            get => _password;
            set { _password = value; OnPropertyChanged(); } }

        public string OutputMessage {
            get => _outputMessage;
            set { _outputMessage = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; }

        public MainWindowViewModel() { LoginCommand = new RelayCommand(LoginButtonClicked); }

        private void LoginButtonClicked() {
            if (FormValidation.ValidateUsername(Username) && FormValidation.ValidatePassword(Password))
            { if (_account.Login(Username, Password)) { OutputMessage = "Login successful!"; }
                else { OutputMessage = "Invalid username or password."; } }
            else { OutputMessage = "Please enter valid credentials."; } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class RelayCommand : ICommand
    { private readonly Action _execute;

        public RelayCommand(Action execute) { _execute = execute; }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute();
    }
}
