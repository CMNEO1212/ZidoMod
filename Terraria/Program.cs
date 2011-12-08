namespace Terraria
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Terraria.Main main = new Terraria.Main();
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if ((args[i].ToLower() == "-port") || (args[i].ToLower() == "-p"))
                    {
                        i++;
                        try
                        {
                            Netplay.serverPort = Convert.ToInt32(args[i]);
                        }
                        catch
                        {
                        }
                    }
                    if ((args[i].ToLower() == "-join") || (args[i].ToLower() == "-j"))
                    {
                        i++;
                        try
                        {
                            main.AutoJoin(args[i]);
                        }
                        catch
                        {
                        }
                    }
                    if ((args[i].ToLower() == "-pass") || (args[i].ToLower() == "-password"))
                    {
                        i++;
                        Netplay.password = args[i];
                        main.AutoPass();
                    }
                    if (args[i].ToLower() == "-host")
                    {
                        main.AutoHost();
                    }
                    if (args[i].ToLower() == "-loadlib")
                    {
                        i++;
                        string path = args[i];
                        main.loadLib(path);
                    }
                }
                main.Run();
            }
            catch (Exception exception)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("client-crashlog.txt", true))
                    {
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine(exception);
                        writer.WriteLine("");
                    }
                    MessageBox.Show(exception.ToString(), "Terraria: Error");
                }
                catch
                {
                }
            }
            finally
            {
                if (main != null)
                {
                    main.Dispose();
                }
            }
        }
    }
}

