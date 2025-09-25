using Microsoft.AspNetCore.SignalR.Client;

namespace NotifyService.App
{
    public partial class Form1 : Form
    {
        private HubConnection _connection;

        public Form1()
        {
            InitializeComponent();

            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44358/printorder")
                .WithAutomaticReconnect()
                .Build();

            // هندل پیام‌های جدید
            _connection.On<int, string>("NewOrder", (Id, UserId) =>
            {
                this.Invoke((Action)(() =>
                {
                    listBox1.Items.Add($"Order ID:{Id}\t User ID:{UserId}");
                }));
            });
            StartConnection();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void StartConnection()
        {
            try
            {
                await _connection.StartAsync();
                listBox1.Items.Add("✅ متصل شد و در حال گوش دادن به سفارش‌های جدید...");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("❌ خطا در اتصال: " + ex.Message);
            }
        }
    }
}
