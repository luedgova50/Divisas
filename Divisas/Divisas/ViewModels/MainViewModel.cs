namespace Divisas.ViewModels
{
    
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes

        public decimal pesos { get; set; }

        public decimal dollars { get; set; }

        public decimal euros { get; set; }

        public decimal pounds { get; set; }

        #endregion

        #region Properties

        public decimal Pesos
        {
            set
            {
                if (pesos != value)
                {
                    pesos = value;

                    PropertyChanged?.
                        Invoke(
                        this, 
                        new PropertyChangedEventArgs("Pesos"));
                }
            }
            get
            {
                return pesos;
            }
        }

        public decimal Dollars
        {
            set
            {
                if (dollars != value)
                {
                    dollars = value;

                    PropertyChanged?.
                        Invoke(
                        this, 
                        new PropertyChangedEventArgs("Dollars"));
                }
            }
            get
            {
                return dollars;
            }
        }

        public decimal Pounds
        {
            set
            {
                if (pounds != value)
                {
                    pounds = value;

                    PropertyChanged?.
                        Invoke(
                        this, 
                        new PropertyChangedEventArgs("Pounds"));
                }
            }
            get
            {
                return pounds;
            }
        }

        public decimal Euros
        {
            set
            {
                if (euros != value)
                {
                    euros = value;

                    PropertyChanged?.
                        Invoke(
                        this, 
                        new PropertyChangedEventArgs("Euros"));
                }
            }
            get
            {
                return euros;
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion

        #region Commands

        public ICommand ConvertCommand
        {
            get
            {
                return new RelayCommand(ConvertMoney);
            }
        }

        

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await App.
                    Current.
                    MainPage.
                    DisplayAlert(
                    "Error", 
                    "Debe ingresar un valor en pesos mayor a cero (0)",
                    "Aceptar");

                return;
            }

            Dollars = Pesos / (decimal)3165.10;
            Pounds = Pesos / (decimal)4119.83;
            Euros = Pesos / (decimal)3557.41;
        }

        #endregion

    }
}
