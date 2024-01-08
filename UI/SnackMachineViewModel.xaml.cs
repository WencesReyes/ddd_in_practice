using Core.Entities;
using Core.ValueObjects;
using Infrastructure.Contexts;
using System.ComponentModel;
using System.Windows;
using static Core.ValueObjects.Money;

namespace UI
{
    /// <summary>
    /// Interaction logic for SnackMachineViewModel.xaml
    /// </summary>
    public partial class SnackMachineViewModel : Window, INotifyPropertyChanged
    {
        private readonly SnackMachine _snackMachine;

        private readonly DddInPracticeContext _dddInPracticeContext = new();

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();

        public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;

        public string Message { get; set; } = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public SnackMachineViewModel()
        {
            _snackMachine = _dddInPracticeContext.SnackMachines.FirstOrDefault() ?? new();

            DataContext = this;

            InitializeComponent();
        }

        public void InsertCent(object sender, RoutedEventArgs e) => InsertMoney(Cent);

        public void InsertTenCent(object sender, RoutedEventArgs e) => InsertMoney(TenCent);

        public void InsertQuarter(object sender, RoutedEventArgs e) => InsertMoney(Quarter);

        public void InsertDollar(object sender, RoutedEventArgs e) => InsertMoney(Dollar);

        public void InsertFiveDollar(object sender, RoutedEventArgs e) => InsertMoney(FiveDollar);

        public void InsertTwentyDollar(object sender, RoutedEventArgs e) => InsertMoney(TwentyDollar);

        public void ReturnMoney(object sender, RoutedEventArgs e)
        {
            _snackMachine.ReturnMoney();

            Message = "Money has returned";

            OnPropertiesChanged();
        }

        public void BuySnack(object sender, RoutedEventArgs e)
        {
            _snackMachine.BuySnack();

            if (_snackMachine.Id == default)
            {
                _dddInPracticeContext.SnackMachines.Add(_snackMachine);
            }
            else
            {
                _dddInPracticeContext.SnackMachines.Update(_snackMachine);
            }

            _dddInPracticeContext.SaveChanges();

            Message = "You bought a snack";

            OnPropertiesChanged();
        }

        public void InsertMoney(Money CoinOrNote)
        {
            _snackMachine.InsertMoney(CoinOrNote);

            Message = $"You have inserted {CoinOrNote}";

            OnPropertiesChanged();
        }

        public void OnPropertiesChanged()
        {
            OnPropertyChanged(nameof(MoneyInTransaction));
            OnPropertyChanged(nameof(MoneyInside));
            OnPropertyChanged(nameof(Message));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _dddInPracticeContext.Dispose();

            base.OnClosing(e);
        }
    }
}