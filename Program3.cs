using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Cvičení: najděte první palindrom(slovo, které se čte pozpátku stejně, např.krk) v řetězci délky 10
//znaků, pak řetězec zobrazte tak, aby nalezený palindrom byl velkými písmeny. Předpokládají se vždy
//celá slova. Hledejte palindromy s minimální délkou 3 písmena.

//nemam to v retezci 10 znaku, ale v obecnem retezci, kde sou slova oddelena mezerama
//a zobrazuju vsechny palindromy, nejen prvni
//kdyby bylo 10 znaku bez mer a mel bych hledat prvni palindrom vetsi nez tri znaky ktery muze byt i nesmyslne slovo
//tak bych asi sel prvni 3 znakovy palindrom bych hledal a o znak bych se posouval takze 7x
//pak bych hledal 4 znakovy takze 6 x bych se posunul
// pak 5 znakovy 5x bych se posunul atd ... mozna to nekdy predelam, ted uz se mi nechce ..
namespace Palindrom
{
    class Program3
    {
        static void Main(string[] args)
        {
            string ret;
            ret = "petra boli krk uz dlouho radar mu nepomuze a nepomuze mu ani ABBA";
            Console.WriteLine(ret);

            //splitak vety na slova
            string[] slovaPole = ret.Split();
            int pocetSlov = slovaPole.Length;

            //pole ktere je velke jak pocet slov ve vete pozdeji kazde bunce nastavim true (slovo je palindrom)
            //a pak testuju a kdyz narazim na nesoulad tak menim na false
            bool[] palindromy = new bool[pocetSlov];

            //for na i te slovo
            for (int i = 0; i < pocetSlov; i++)
            {

                //splitak2 slova na znaky
                char[] znakyPole = slovaPole[i].ToCharArray();

                int pocetPismen = znakyPole.Length;
                int zbytek = znakyPole.Length % 2;
                int pocetKontrol = (znakyPole.Length - zbytek) / 2;
                bool[] vysledekKontroly = new bool[pocetKontrol];
                //inicializace na false
                for (int i2 = 0; i2 < vysledekKontroly.Length; i2++) { vysledekKontroly[i2] = false; }
                //testovani prvniho a posledniho pismena a dale ke stredu slova
                //jestlize se nekde do pole vysledek kontroly ulozi false, tak to slovo neni palindrom
                for (int i3 = 0; i3 < pocetKontrol; i3++)
                {
                    if (znakyPole[i3] == znakyPole[znakyPole.Length - (i3 + 1)])
                    {
                        vysledekKontroly[i3] = true;
                    }
                }
                // nastavim ze slovo je palindrom a jestlize nize zjistim ze nektera kontrola nesedi tak ho prenastavim na false
                palindromy[i] = true;
                for (int i4 = 0; i4 < pocetKontrol; i4++)
                {

                    if (vysledekKontroly[i4] == false)
                    {
                        palindromy[i] = false;
                    }
                }
                //slovo musi mit min 3 znaky
                if (pocetPismen<3)
                {
                    palindromy[i] = false;
                }
                //vypis palindromy velkym
                if (palindromy[i]==true)
                {
                  slovaPole[i]=  slovaPole[i].ToUpper();
                }

            }
           


            for (int i = 0; i < palindromy.Length; i++)
            {
                Console.WriteLine((i + 1) + ". slovo je palindrom? " + palindromy[i]);
            }

            for (int i = 0; i < pocetSlov; i++)
            {
                Console.Write(slovaPole[i]+" ");
            }


            Console.ReadLine();
        }
    }
}