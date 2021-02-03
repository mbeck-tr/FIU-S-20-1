using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Wiederholung.Interfaces_Schnittstellen
{
    abstract class GeometrischesObjekt
    {
        public int a;
        public virtual void tuwas()
        {
            Console.WriteLine("Basisklasse");
        }
        public abstract void Ausgabe();
    }

    class Kreis : GeometrischesObjekt, IBildschirmausgabe
    {
        void test()
        {
            a = 10;
            tuwas();
        }
        public override void tuwas()
        {
            Console.WriteLine("Basisklasse überschrieben");
        }
        public override void Ausgabe()
        {
            throw new NotImplementedException();
        }

        public void ausgeben() { Console.WriteLine("Kreis"); }
    }

    class Rechteck : GeometrischesObjekt, IBildschirmausgabe
    {
        void test()
        {
            a = 12;
        }
        new void tuwas()
        {
            Console.WriteLine("Basisklasse ausgeblendet");
        }
        public override void Ausgabe()
        {
            throw new NotImplementedException();
        }

        public void ausgeben()
        {
            Console.WriteLine("Rechteck");
        }
    }

    abstract class Text
    {
        public abstract void Ausgabe();
    }

    class Notiz : Text, IBildschirmausgabe
    {
       
        public override void Ausgabe()
        {
            throw new NotImplementedException();
        }
        public void ausgeben()
        {
            Console.WriteLine("Notiz");
        }

    }

    interface IBildschirmausgabe
    {
        public void ausgeben();
    }
}
