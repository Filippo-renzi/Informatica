using Microsoft.Windows.Themes;
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

namespace Verifica_Filippo_Renzi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Scuole
        {
            public string Nome_Scuola { get; set; }
            public List<Classi> ListClassi { get; set; }

            public Scuole(string nome_scuola)
            {
                Nome_Scuola = nome_scuola;
               
                ListClassi = new List<Classi>();
            }

        }
        class Classi
        {           
            public string Nome_Sezione { get; set; }
            public int Numero_Alunni { get; set; }
            public List<Alunni> ListAlunni { get; set; }

            public Classi (string nome_sezione, int nAlunni)
            {
                Nome_Sezione = nome_sezione;
                Numero_Alunni = nAlunni;
                ListAlunni = new List<Alunni>();
            }
        }

        class Alunni
        {
            public string Nome { get; set; }
            public double Media { get; set; }

            public Alunni (string nome, double mediaVori)
            {
                Nome = nome;
                Media = mediaVori;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            //Creo le scuoe che conterranno le classi
            Scuole Scuola1 = new Scuole("ITT Pascal");
            Scuole Scuola2 = new Scuole("Marie Curie");

            //Prima Scuola
            Classi Classe1 = new Classi("4H", 10);
            Classe1.ListAlunni.Add(new Alunni("Filippo", 7.5));
            Classe1.ListAlunni.Add(new Alunni("Metteo", 6.7));
            Classe1.ListAlunni.Add(new Alunni("Gianluca", 5.5));
            Classe1.ListAlunni.Add(new Alunni("Ada", 9.3));
            Classe1.ListAlunni.Add(new Alunni("Marco", 8.4));
            Classe1.ListAlunni.Add(new Alunni("Veronica", 7.7));
            Classe1.ListAlunni.Add(new Alunni("Calogero", 4.8));
            Classe1.ListAlunni.Add(new Alunni("Martina", 6.2));
            Classe1.ListAlunni.Add(new Alunni("Samanta", 6.7));
            Classe1.ListAlunni.Add(new Alunni("Andrea", 8.3));

            
            Classi Classe2 = new Classi("5H", 10);
            Classe2.ListAlunni.Add(new Alunni("Ambrogio", 6.6));
            Classe2.ListAlunni.Add(new Alunni("Stefanetti", 7.7));
            Classe2.ListAlunni.Add(new Alunni("Alessia", 9.4));
            Classe2.ListAlunni.Add(new Alunni("Antonio", 5.7));
            Classe2.ListAlunni.Add(new Alunni("Sofia", 6.4));
            Classe2.ListAlunni.Add(new Alunni("Elisa", 8.8));
            Classe2.ListAlunni.Add(new Alunni("Ares", 3.8));
            Classe2.ListAlunni.Add(new Alunni("Federico", 6.7));
            Classe2.ListAlunni.Add(new Alunni("Samanta", 7.2));
            Classe2.ListAlunni.Add(new Alunni("Cristiano", 5.3));

            
            // Seconda Scuola
            Classi Classe3 = new Classi("3B", 10);
            Classe3.ListAlunni.Add(new Alunni("Antonietta", 8.6));
            Classe3.ListAlunni.Add(new Alunni("Stefania", 9.7));
            Classe3.ListAlunni.Add(new Alunni("Maria", 9.4));
            Classe3.ListAlunni.Add(new Alunni("Giacomo", 3.5));
            Classe3.ListAlunni.Add(new Alunni("Alberto", 6.4));
            Classe3.ListAlunni.Add(new Alunni("Sandra", 4.8));
            Classe3.ListAlunni.Add(new Alunni("Fiona", 4.2));
            Classe3.ListAlunni.Add(new Alunni("Denis", 6.7));
            Classe3.ListAlunni.Add(new Alunni("Leonardo", 7.2));
            Classe3.ListAlunni.Add(new Alunni("Jacopo", 6.3));

            //Prima scuola
            Scuola1.ListClassi.Add(Classe1);
            Scuola1.ListClassi.Add(Classe2);
            //Seconda scuola
            Scuola2.ListClassi.Add(Classe3);

            //Visualizzo scuole
            ListBoxScuola.Items.Add(Scuola1);
            ListBoxScuola.Items.Add(Scuola2);

            // rendo la media non cliccabile per ora
            ButtonMag.IsEnabled = false;
            ButtonMin.IsEnabled = false;


        }
        private void SelezioneScuola(object sender, SelectionChangedEventArgs e)
        {
            ListBoxClassi.Items.Clear();
            Scuole ScuolaSelezionata = ListBoxScuola.SelectedItem as Scuole;
            if (ScuolaSelezionata != null)
            {
                foreach (Classi classe in ScuolaSelezionata.ListClassi)
                    ListBoxClassi.Items.Add(classe);
            }

            // quando seleziono la Scuola non mi e possibile vedere chi ha la media maggiore
            ButtonMag.IsEnabled = false;
            ButtonMin.IsEnabled = false;


            // se prima ho visto una media poi ho cambiao scuola
            // allora pulisco i modo che sia più bello da vedere
            ListaMostraAlunno.Items.Clear();

        }

        private void SelezioneClasse(object sender, SelectionChangedEventArgs e)
        {
            ListBoxAlunni.Items.Clear();
            Classi ClasseSelezionata = ListBoxClassi.SelectedItem as Classi;
            if(ClasseSelezionata != null)
            {
                foreach (Alunni alunno in ClasseSelezionata.ListAlunni)
                    ListBoxAlunni.Items.Add(alunno);
            }

            // da adesso mi è permesso vedere le medie maggiori e minori
            ButtonMag.IsEnabled = true;
            ButtonMin.IsEnabled = true;
        }

        private void MediaMaggiore(object sender, RoutedEventArgs e)
        {
            ListaMostraAlunno.Items.Clear();
            Classi ClasseSelezionata = ListBoxClassi.SelectedItem as Classi;
            // creao un alunno temporaneo, con una media facile da superare,
            // ogni volta controlo quale dei due alunni ha la media maggiore e
            // aggiorno l'alunno che poi verà stampato come alunno finale
            Alunni alunno_Prova = new Alunni("tmp", 0.0); 
            if(ClasseSelezionata != null)
            {
               
                foreach (Alunni alunno_ in ClasseSelezionata.ListAlunni )
                    if(alunno_.Media > alunno_Prova.Media)
                    {
                        alunno_Prova.Media = alunno_.Media;
                        alunno_Prova.Nome = alunno_.Nome;
                    }
                ListaMostraAlunno.Items.Add(alunno_Prova);

            }
        }

        private void MediaMinore(object sender, RoutedEventArgs e)
        {
            ListaMostraAlunno.Items.Clear();
            Classi ClasseSelezionata = ListBoxClassi.SelectedItem as Classi;
            // creao un alunno temporaneo, con una media facile impossibile in 
            // modo che  tutte le medie successive siano per forza inferiori
            // ogni volta controlo quale dei due alunni ha la media maggiore e
            // aggiorno l'alunno che poi verà stampato come alunno finale
            Alunni alunno_Prova = new Alunni("tmp", 11.0);
            if (ClasseSelezionata != null)
            {

                foreach (Alunni alunno_ in ClasseSelezionata.ListAlunni)
                    if (alunno_.Media < alunno_Prova.Media)
                    {
                        alunno_Prova.Media = alunno_.Media;
                        alunno_Prova.Nome = alunno_.Nome;
                    }
                ListaMostraAlunno.Items.Add(alunno_Prova);

            }
        }

       
    }
}
