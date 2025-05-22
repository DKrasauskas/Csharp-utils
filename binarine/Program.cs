// See https://aka.ms/new-console-template for more information



static krepsininkas[] Read(string path)
{
    int count = 0;
    using (StreamReader sr = new StreamReader(path))
    {
        while(sr.ReadLine() != null)
        {
            count++;
        }
    }
    krepsininkas[] krepsininkai = new krepsininkas[count];
    count = 0;
    using (StreamReader sr = new StreamReader(path))
    {
        string line;
        while((line = sr.ReadLine()) != null)
        { 
            string charst = "; ";       
            string[] s = line.Split(charst.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);        
            krepsininkai[count] = new krepsininkas(s[0], s[1], int.Parse(s[2]), int.Parse(s[3]), int.Parse(s[4]));
            count++;
        } 
    }
    return krepsininkai;
}


komanda komanda1 = new komanda(Read("Komanda.txt"));
komanda naujas = new komanda(Read("Komandan.txt"));
komanda1.rikiuok();
komanda1.print();
komanda1.ismesk(naujas.Gauk());
komanda1.print();
komanda1.Write();
//komanda Naujas = new komanda(Read("Komandan_6.txt"));

class krepsininkas
{
    string vardas, pavarde;
    int metai, ugis, taskai;
    public krepsininkas(string vardas, string pavarde, int metai, int ugis, int taskai)
    {
        this.vardas = vardas;
        this.taskai = taskai;
        this.ugis = ugis;
        this.metai = metai;
        this.pavarde = pavarde;
    }
    public static bool operator >=(krepsininkas a, krepsininkas b)
    {
        if (a.Taskai() > b.Taskai())
        {
            return true;
        }

        else
        {
            if (a.Taskai() == b.Taskai() && a.Vardas().CompareTo(b.Vardas()) < 0)
            {
                return true;
            }
            else
            {
                if (a.Taskai() == b.Taskai() && a.Vardas().CompareTo(b.Vardas()) == 0 && a.Pvardas().CompareTo(b.Pvardas()) < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public static bool operator <=(krepsininkas a, krepsininkas b)
    {
        if (a.Taskai() < b.Taskai())
        {
            return true;
        }
        else
        {
            if (a.Taskai() == b.Taskai() && a.Vardas().CompareTo(b.Vardas()) > 0)
            {
                return true;
            }
            else
            {
                if (a.Taskai() == b.Taskai() && a.Vardas().CompareTo(b.Vardas()) == 0 && a.Pvardas().CompareTo(b.Pvardas()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public static bool operator ==(krepsininkas a, krepsininkas b)
    {
        if (a.Taskai() == b.Taskai()  && a.Pvardas() == b.Pvardas()  && a.Vardas() == b.Vardas()) return true;
        else return false;
    }
    public static bool operator !=(krepsininkas a, krepsininkas b)
    {
        if (a.Taskai() != b.Taskai()  || a.Pvardas() != b.Pvardas() || a.Vardas() != b.Vardas()) return true;
        else return false;
    }
    public string Vardas()
    {
        return vardas;
    }
    public string Pvardas()
    {
        return pavarde;
    }
    public int Taskai()
    {
        return taskai;
    }
    public int Metai()
    {
        return metai;
    }
    public int Ugis()
    {
        return ugis;
    }
}

class komanda
{
    krepsininkas[] krepsin;
    public komanda(krepsininkas[] kreps)
    {
        this.krepsin = kreps;
    }
    public krepsininkas[] Gauk()
    {
        return krepsin;
    }
    public void ismesk(krepsininkas[] krep)
    {
        
        foreach(var a in krep)
        {          
            int index = binary_search(a, krepsin);          
            if (index == -1)
            {
                
                continue;
            }
            else
            {              
                krepsininkas[] reformed = new krepsininkas[krepsin.Length - 1];
                int k = 0;          
                for (int i = 0; i < krepsin.Length; i++)
                {                   
                    if (i != index)
                    {
                        reformed[k] = krepsin[i];                      
                        k++;
                    }
                    else
                    {

                        continue;
                    }
                }                           
                krepsin = reformed;           
            }
        }
    }
    public void rikiuok()
    {
        krepsininkas[] nariai = new krepsininkas[krepsin.Length];
        for(int i = 0; i < krepsin.Length; i++)
        {
            for (int j = 0; j < krepsin.Length; j++)
            {
                if (krepsin[i] >= krepsin[j])
                {
                    krepsininkas a = krepsin[i];
                    krepsininkas b = krepsin[j];
                    krepsin[i] = b;
                    krepsin[j] = a;
                }
            }
        }
    }
    public int binary_search(krepsininkas a, krepsininkas[] kreps)
    {     
        int position = -1;
        int count = 0;
        if (kreps.Length % 2 == 0)
        {
            int index = kreps.Length / 2;
            while (kreps[index] != a && count < kreps.Length )
            {

                if (kreps[index] <= a)
                {
                    index = index / 2;

                }

                else
                {
                    if (kreps[index] >= a)
                    {
                        if (index == 1)
                        {
                            index += 1;
                        }
                        else
                        {
                            index += index / 2;
                        }
                        if (index >= kreps.Length)
                        {
                            index = kreps.Length - 1;
                        }

                    }

                }
                //Console.WriteLine(index);

                count++;
            }
            position = index;         
        }
        else
        {
            int index = kreps.Length / 2;
            while (kreps[index] != a && count < kreps.Length)
            {

                if (kreps[index] <= a)
                {
                    index = index / 2;

                }

                else
                {
                    if (kreps[index] >= a)
                    {
                        if (index == 1)
                        {
                            index += 1;
                        }
                        else
                        {
                            index += index / 2;
                        }
                        if (index >= kreps.Length)
                        {
                            index = kreps.Length - 1;
                        }
                    }
                }            
                count++;

            }
            position = index;
        }
        if (count == kreps.Length) return -1;
        else return position;
      
     }
    public void print()
    {
        foreach(var h in krepsin)
        {
            Console.WriteLine("{0, 1},{1, 1},{2, 1},{3, 1},{4, 1} ", h.Vardas(), h.Pvardas(), h.Metai(), h.Ugis(), h.Taskai());
        }     
    }
    public void Write()
    {
        
            using( StreamWriter sr = new StreamWriter("Rezultatai.txt"))
            {
               foreach (var h in krepsin)
               {
                sr.WriteLine("{0, 1} {1, 1} {2, 1} {3, 1} {4, 1} ", h.Vardas(), h.Pvardas(), h.Metai(), h.Ugis(), h.Taskai());
               }
            }               
    }
}


