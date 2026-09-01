using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;

namespace VedettGUI
{
    public partial class MainWindow : Window
    {
        private List<Allat> allatLista = new List<Allat>();
        private string connectionString = "Server=localhost;Database=vedett;Uid=root;Pw=;";

        public MainWindow()
        {
            InitializeComponent();
            AdatokBetoltese();
        }

        private void AdatokBetoltese()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT a.id, a.nev, a.ev, e.forint FROM allat a JOIN ertek e ON a.ertekid = e.id ORDER BY a.id;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allatLista.Add(new Allat
                            {
                                Id = reader.GetInt32("id"),
                                Nev = reader.GetString("nev"),
                                Ev = reader.IsDBNull(reader.GetOrdinal("ev")) ? 0 : reader.GetInt32("ev"),
                                Ertek = reader.GetInt32("forint")
                            });
                        }
                    }
                }
            }

            dgAllatok.ItemsSource = allatLista;
            if (allatLista.Count > 0)
            {
                dgAllatok.SelectedIndex = 0;
            }
        }

        private void btnEszmeiErtek_Click(object sender, RoutedEventArgs e)
        {
            if (dgAllatok.SelectedItem is Allat kivalasztott)
            {
                lblEszmeiErtek.Text = $"{kivalasztott.Ertek} Ft";
            }
        }

        private void btnLegalabb400_Click(object sender, RoutedEventArgs e)
        {
            int db = allatLista.Count(a => a.Ertek >= 400000);
            lblLegalabb400.Text = db.ToString();
        }
    }
}