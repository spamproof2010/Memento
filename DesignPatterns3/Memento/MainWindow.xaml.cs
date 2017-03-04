using DemoMemento;
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
using static System.Diagnostics.Debug;

namespace Memento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ---------------------------------------------

        // Create a caretaker that contains the ArrayList 
        // with all the articles in it. It can add and
        // retrieve articles from the ArrayList

        Caretaker caretaker = new Caretaker();

        // The originator sets the value for the article,
        // creates a new memento with a new article, and 
        // gets the article stored in the current memento

        Originator originator = new Originator();

        int saveFiles = 0, currentArticle = -1;

        // ---------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Get text in JTextArea
            string textInTextArea = theArticle.Text;

            // Set the value for the current memento
            originator.set(textInTextArea);

            // Add new article to the ArrayList
            caretaker.addMemento(originator.storeInMemento());

            // saveFiles monitors how many articles are saved
            // Number of mementos I have
            saveFiles++;
            currentArticle++;
            
            WriteLine("Saved Files " + saveFiles + "\n");

            btnUndo.IsEnabled = true;
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (currentArticle >= 1)
            {
                currentArticle--;

                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentArticle));

                theArticle.Text = textBoxString;

                btnRedo.IsEnabled = true;
            }
            else {
                btnUndo.IsEnabled = false;
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            if ((saveFiles - 1)> currentArticle) 
            {
                currentArticle++;

                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentArticle));

                theArticle.Text = textBoxString;

                btnUndo.IsEnabled = false;
            }
            else
            {
                btnRedo.IsEnabled = false;
            }

            btnUndo.IsEnabled = true;
        }
    }
}
