using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Globalization;
using System.Text.Json;

namespace matus_zihala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            var status = (TextBlock)this.FindName("StatusTextBlock");
            var weatherResult = (TextBlock)this.FindName("WeatherResultTextBlock");
            var weatherIcon = (TextBlock)this.FindName("WeatherIconTextBlock");
            var latBox = (TextBox)this.FindName("LatitudeTextBox");
            var lonBox = (TextBox)this.FindName("LongitudeTextBox");
            var emailBox = (TextBox)this.FindName("EmailTextBox");
            var loadingEllipse = (System.Windows.Shapes.Ellipse)this.FindName("LoadingEllipse");
            status.Text = string.Empty;
            weatherResult.Text = string.Empty;
            weatherIcon.Text = string.Empty;
            loadingEllipse.Visibility = Visibility.Visible;
            var rotate = new System.Windows.Media.RotateTransform();
            loadingEllipse.RenderTransform = rotate;
            var anim = new System.Windows.Media.Animation.DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(1)));
            anim.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
            rotate.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, anim);
            if (!double.TryParse(latBox.Text, out double lat) || !double.TryParse(lonBox.Text, out double lon))
            {
                status.Text = "Zadajte platnú zemepisnú šírku a dĺžku.";
                loadingEllipse.Visibility = Visibility.Collapsed;
                rotate.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, null);
                return;
            }
            string email = emailBox.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                status.Text = "Zadajte platný email pre API.";
                loadingEllipse.Visibility = Visibility.Collapsed;
                rotate.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, null);
                return;
            }
            try
            {
                string url = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lon}";
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"WeatherApp/1.0 ({email})");
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                string temp = ExtractTemperature(json);
                string symbol = ExtractWeatherSymbol(json);
                weatherResult.Text = $"Aktuálna teplota: {temp} °C";
                weatherIcon.Text = GetWeatherEmoji(symbol);
            }
            catch (Exception ex)
            {
                status.Text = $"Chyba: {ex.Message}";
            }
            loadingEllipse.Visibility = Visibility.Collapsed;
            rotate.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, null);
        }

        private string ExtractTemperature(string json)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var root = doc.RootElement;
                    var timeseries = root.GetProperty("properties").GetProperty("timeseries");
                    if (timeseries.GetArrayLength() > 0)
                    {
                        var instant = timeseries[0].GetProperty("data").GetProperty("instant").GetProperty("details");
                        if (instant.TryGetProperty("air_temperature", out JsonElement tempElem))
                        {
                            return tempElem.GetDouble().ToString("0.0");
                        }
                    }
                }
            }
            catch { }
            return "-";
        }

        private string ExtractWeatherSymbol(string json)
        {
            var symbolKey = "\"symbol_code\":\"";
            int idx = json.IndexOf(symbolKey);
            if (idx != -1)
            {
                int start = idx + symbolKey.Length;
                int end = json.IndexOf('"', start);
                return json.Substring(start, end - start);
            }
            return "";
        }

        private string GetWeatherEmoji(string symbol)
        {
            if (string.IsNullOrEmpty(symbol)) return "🌡️";
            if (symbol.Contains("clearsky_day")) return "☀️";
            if (symbol.Contains("clearsky_night")) return "🌙";
            if (symbol.Contains("cloudy")) return "☁️";
            if (symbol.Contains("rain")) return "🌧️";
            if (symbol.Contains("snow")) return "❄️";
            if (symbol.Contains("fog")) return "🌫️";
            if (symbol.Contains("partlycloudy_day")) return "⛅";
            if (symbol.Contains("partlycloudy_night")) return "🌙☁️";
            if (symbol.Contains("lightrain")) return "🌦️";
            if (symbol.Contains("heavyrain")) return "🌧️";
            if (symbol.Contains("thunder")) return "⛈️";
            return "🌡️";
        }
    }
}