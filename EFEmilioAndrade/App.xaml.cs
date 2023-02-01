using EFEmilioAndrade.JEAIData;

namespace EFEmilioAndrade;

public partial class App : Application
{
    //  public static JEAISateliteDataBase SateliteRepo { get; set; }

    public App(/* JEAISateliteDataBase repo*/)
	{
		InitializeComponent();

		MainPage = new AppShell();

        //SateliteRepo = repo;

    }
}
