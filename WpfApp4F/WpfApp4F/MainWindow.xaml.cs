using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp4F
{
    public class Squadra
    {
        public string Nome { get; set; }
        public List<Calciatore> Calciatori { get; set; }

        public Squadra(string nome)
        {
            Nome = nome;
            Calciatori = new List<Calciatore>();
        }
    }

    public class Calciatore
    {
        public string Nome { get; set; }
        public int Età { get; set; }

        public Calciatore(string nome, int età)
        {
            Nome = nome;
            Età = età;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Squadra squadra1 = new Squadra("Juventus");
            squadra1.Calciatori.Add(new Calciatore("Buffon", 38));
            squadra1.Calciatori.Add(new Calciatore("Chiellini", 28));
            squadra1.Calciatori.Add(new Calciatore("Barzagli", 33));
            squadra1.Calciatori.Add(new Calciatore("Bonucci", 35));
            squadra1.Calciatori.Add(new Calciatore("Pirlo", 33));
            squadra1.Calciatori.Add(new Calciatore("Marchisio", 29));
            squadra1.Calciatori.Add(new Calciatore("Pogba", 24));
            squadra1.Calciatori.Add(new Calciatore("Mandzukic", 31));
            squadra1.Calciatori.Add(new Calciatore("Dybala", 25));
            squadra1.Calciatori.Add(new Calciatore("Higuain", 29));
            squadra1.Calciatori.Add(new Calciatore("Bernardeschi", 27));



            Squadra squadra2 = new Squadra("Inter");
            squadra2.Calciatori.Add(new Calciatore("Handanociv", 22));
            squadra2.Calciatori.Add(new Calciatore("Bastoni", 30));
            squadra2.Calciatori.Add(new Calciatore("Acerbi", 30));
            squadra2.Calciatori.Add(new Calciatore("Skrjniar", 30));
            squadra2.Calciatori.Add(new Calciatore("Di Marco", 30));
            squadra2.Calciatori.Add(new Calciatore("Darmian", 30));
            squadra2.Calciatori.Add(new Calciatore("Brozovic", 30));
            squadra2.Calciatori.Add(new Calciatore("Barella", 30));
            squadra2.Calciatori.Add(new Calciatore("Sensi", 30));
            squadra2.Calciatori.Add(new Calciatore("Dzeko", 30));
            squadra2.Calciatori.Add(new Calciatore("L.Martinez", 30));

            Squadra squadra3 = new Squadra("Milan");
            squadra3.Calciatori.Add(new Calciatore("Maignain", 22));
            squadra3.Calciatori.Add(new Calciatore("Kjer", 30));
            squadra3.Calciatori.Add(new Calciatore("Tomori", 30));
            squadra3.Calciatori.Add(new Calciatore("T.Hernandez", 30));
            squadra3.Calciatori.Add(new Calciatore("Calabria", 30));
            squadra3.Calciatori.Add(new Calciatore("Tonali", 30));
            squadra3.Calciatori.Add(new Calciatore("Krunic", 30));
            squadra3.Calciatori.Add(new Calciatore("Pulisic", 30));
            squadra3.Calciatori.Add(new Calciatore("Leao", 30));
            squadra3.Calciatori.Add(new Calciatore("Giroud", 30));
            squadra3.Calciatori.Add(new Calciatore("Reijnders", 30));




            // Aggiungi le squadre alla ListBox delle squadre
            squadreListBox.Items.Add(squadra1);
            squadreListBox.Items.Add(squadra2);
            squadreListBox.Items.Add(squadra3);
        }
        private void squadreListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Quando una squadra viene selezionata, popola la ListBox dei calciatori con i dati corrispondenti
            calciatoriListBox.Items.Clear();
            Squadra squadraSelezionata = squadreListBox.SelectedItem as Squadra;
            if (squadraSelezionata != null)
            {
                foreach (Calciatore calciatore in squadraSelezionata.Calciatori)
                {
                    calciatoriListBox.Items.Add(calciatore);
                }
            }
        }
    }
 }

