

string path = "C:\\Users\\matti\\source\\repos\\JobAssignement\\JobAssignement\\test.csv";

StreamReader reader = null;
StreamReader reader2 = null;

if (File.Exists(path))
    {

        Console.WriteLine("The file exists");
        reader = new StreamReader(File.OpenRead(path));
        int i = 0;
        double totMagg = 0;
        int qntyMax = 0;
        double maxDisc = 0;
        string lines = reader.ReadLine(); ;
        string[] values = new string[lines.Length];
        int[] id = new int[lines.Length];
        string[] articleName = new string[lines.Length];
        int[] quantity = new int[lines.Length];
        double[] unitPrice = new double[lines.Length];
        int[] percentageDiscount = new int[lines.Length];
        string[] buyer = new string[lines.Length];
        double[] totDisc = new double[lines.Length];
        double[] totNoDisc = new double[lines.Length];
        double[] massDisc = new double[lines.Length];

        reader2 = new StreamReader(File.OpenRead(path));
    while (!reader2.EndOfStream)
        {
        var line = reader2.ReadLine();

        values = line.Split(',');
        id[i] = int.Parse(values[0]);
        articleName[i] = values[1];
        quantity[i] = int.Parse(values[2]);
        unitPrice[i] = double.Parse(values[3]);
        percentageDiscount[i] = int.Parse(values[4]);
        buyer[i] = values[5];
        totNoDisc[i] = quantity[i] * unitPrice[i];
        if (percentageDiscount[i] > 0) {
            totDisc[i]= (quantity[i] * unitPrice[i])-((quantity[i] * unitPrice[i]) * percentageDiscount[i]/100);
        }
        else {
            totDisc[i] = quantity[i] * unitPrice[i]; 
             }

        massDisc[i] = totNoDisc[i] - totDisc[i];

        i++; 
        
    }
   
    /*for (int j = 0; j < 5; j++) {
        
        for (int k = j+1; k < 6; k++)
        {
            
            if (buyer[j].Equals(buyer[k]))
            {
                

                quantity[j] += quantity[k];               
                totDisc[j] += totDisc[k];
                totNoDisc[j] += totNoDisc[k];
                massDisc[j] += massDisc[k];
            }
            else
            {
                
            }
        }
    }*/
    

    totMagg = totNoDisc.Max();
    qntyMax = quantity.Max();
    maxDisc = massDisc.Max();

    for (int j = 0; j < totNoDisc.Length; j++)
    {
        if (totNoDisc[j]==totMagg)
        {
            Console.WriteLine("Il record con l'importo totale piu alto e' l'ordine di " + buyer[j] + " con un importo di "+totMagg);
        }
        if (quantity[j]==qntyMax)
        {
            Console.WriteLine("Il record con la quantita totale piu alta e' l'ordine di " + buyer[j] + " con " + qntyMax +" pezzi");
        }
        if (massDisc[j]==maxDisc)
        {
            Console.WriteLine("Il record con lo sconto piu alto e' " + buyer[j] + " con uno sconto di " + maxDisc);

        }

    }
    reader.Close();
    reader2.Close();
    }
    else
    {

        Console.WriteLine("The file doesn't exist");

    }
