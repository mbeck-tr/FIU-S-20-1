using System;
using System.Collections.Generic;
using Wiederholung.Interfaces_Schnittstellen;

namespace Wiederholung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<GeometrischesObjekt> geoListe = new List<GeometrischesObjekt>();
            List<Text> textListe = new List<Text>();

            // Elemente in den Listen speichern

            // Ausgabe der Elemente auf dem Bildschirm
            foreach (var item in geoListe)
            {
                item.Ausgabe();
            }
            foreach (var item in textListe)
            {
                item.Ausgabe();
            }

            List<IBildschirmausgabe> bildschirmausgabeListe = new List<IBildschirmausgabe>();
            bildschirmausgabeListe.Add(new Kreis());
            bildschirmausgabeListe.Add(new Rechteck());
            bildschirmausgabeListe.Add(new Notiz());

            foreach (var item in bildschirmausgabeListe)
            {
                item.ausgeben();
            }

            Notiz notiz = new Notiz();
            //foreach (var item in notiz)
            //{

            //}
        }
    }
}
