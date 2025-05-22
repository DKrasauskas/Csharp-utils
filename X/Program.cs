// See https://aka.ms/new-console-template for more information
static string[] Read()
{
    int size = 0;
    using (StreamReader sr = new StreamReader("Tekstas4.txt"))
    {
        do
        {
            size++;
        } while (sr.ReadLine() != null);

    }
    string[] output = new string[size];
    int count = 0;
    using (StreamReader sr = new StreamReader("Tekstas4.txt"))
    {
        string item;
        do
        {
            item = sr.ReadLine();
            output[count] = item;
            count++;
        } while (item != null);

    }
    return output;
}
static bool tinka(string word)
{
    string nouns = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
    int count = 0;
    if (nouns.Contains(word[word.Length - 1]))
    {
        return true;
    }
    else return false;
}
static bool tinka2(string word)
{
    string nouns = "123456789";
    int count = 0;
    if (nouns.Contains(word[word.Length - 1]))
    {
        return true;
    }
    else return false;
}
static string[] Modify(string[] lines)
{

    string[] outputas = new string[lines.Length];
    int indexs = 0;
    foreach (var s in lines)
    {
        string param = ",.;";
        if (s == null)
        {
            outputas[indexs] = " ";
            indexs++;
            continue;
        }
        string[] l = s.Split(param.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int nth = 1;
        string zodis = "";
        int index1 = -1;

        for (int i = l.Length - 1; i >= 0; i--)
        {
            if (l[i] != null)
            {
                if (tinka(l[i]))
                {
                    if (zodis.Length <= l[i].Length && zodis != "")
                    {
                        zodis = l[i];
                        index1 = i;

                    }
                    else
                    {
                        zodis = l[i];
                        index1 = i;
                    }
                }
            }
        }
        string zodis2 = "";
        int index2 = -1;
        for (int i = 0; i < l.Length; i++)
        {
            if (tinka2(l[i]))
            {
                if (zodis2 != "" && l[i].Length <= zodis2.Length)
                {
                    zodis2 = l[i];
                    index2 = i;
                }
                else
                {
                    if (zodis2 == "")
                    {
                        zodis2 = l[i];
                        index2 = i;
                    }
                }
            }
        }
        int x = 0;
        int index = 0;
        string output = "";
        string rep1 = "";
        string[] suskyrikliais = new string[l.Length];
        while (x < s.Length)
        {
            if (param.Contains(s[x]) == false)
            {
                while (x < s.Length && param.Contains(s[x]) == false)
                {
                    rep1 += s[x];
                    x++;
                }
                while (x < s.Length && param.Contains(s[x]) == true)
                {
                    rep1 += s[x];
                    x++;
                }
                suskyrikliais[index] = rep1;
                rep1 = "";
                index++;

            }
            else
            {
                x++;
            }
        }

        if (index1 != -1 && index2 != -1)
        {
            string a = suskyrikliais[index2];
            string b = suskyrikliais[index1];
            suskyrikliais[index2] = b;
            suskyrikliais[index1] = a;

        }
        index = 0;
        x = 0;
        while (x < s.Length)
        {
            if (param.Contains(s[x]) == false)
            {
                while (x < s.Length && param.Contains(s[x]) == false)
                {
                    x++;
                }
                while (x < s.Length && param.Contains(s[x]) == true)
                {

                    x++;
                }
                output += suskyrikliais[index];
                index++;
            }
            else
            {
                output += s[x];
                x++;
            }
        }
        outputas[indexs] = output;
        indexs++;
    }

    return outputas;
}
static void Write(string[] s)
{
    using (StreamWriter sr = new StreamWriter("RedTekstas.txt"))
    {
        int x = 0;
        do
        {
            sr.WriteLine(s[x]);
            x++;
        } while (x < s.Length);
    }
}

Write(Modify(Read()));
