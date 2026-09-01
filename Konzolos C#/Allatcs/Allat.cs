namespace Vedett
{
    public class Allat
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Ertek { get; set; }
        public int Ev { get; set; }
        public string Kategoria { get; set; }

        public Allat(int id, string nev, int ertek, int ev, string kategoria)
        {
            Id = id;
            Nev = nev;
            Ertek = ertek;
            Ev = ev;
            Kategoria = kategoria;
        }

        public bool Kulonleges()
        {
            return Kategoria.ToLower() == "emlősök" && Ev == 1901;
        }
    }
}