using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMemento
{
    // Memento Design Pattern Tutorial

    public class Originator
    {

        private String article;

        // Sets the value for the article

        public void set(String newArticle)
        {
            Console.WriteLine("----");
            Console.WriteLine("From Originator: Current Version of Article\n" + newArticle + "\n");
            this.article = newArticle;
        }

        // Creates a new Memento with a new article

        public Memento storeInMemento()
        {
            Console.WriteLine("From Originator: Saving to Memento");
            return new Memento(article);
        }

        // Gets the article currently stored in memento

        public String restoreFromMemento(Memento memento)
        {

            article = memento.getSavedArticle();

            Console.WriteLine("From Originator: Previous Article Saved in Memento\n" + article + "\n");

            return article;

        }
    }
}
