namespace ml_waluty
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            fromPicker.ItemsSource = currency_handler.rates;
            fromPicker.SelectedIndex = 0;
            toPicker.ItemsSource = currency_handler.rates;
            toPicker.SelectedIndex = 1;
        }

        private void exBtn_Clicked(object sender, EventArgs e)
        {
            int temp = fromPicker.SelectedIndex;
            fromPicker.SelectedIndex = toPicker.SelectedIndex;
            toPicker.SelectedIndex = temp;
        }

        private void refresh(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kwota.Text) || kwota.Text == "-" || kwota.Text == ".")
            {
                kwota.Text = "";
                return;
            }
            double kwotaa = double.Parse(kwota.Text);
            if (kwotaa < 0)
            {
                wynik.Text = "Podaj poprawne wartości";
                return;
            }
            currencyClass from = fromPicker.SelectedItem as currencyClass;
            currencyClass to = toPicker.SelectedItem as currencyClass;

            double wynikint = Math.Round(kwotaa * from.bid / to.ask,2);
            wynik.Text = wynikint.ToString();

        }
    }
}