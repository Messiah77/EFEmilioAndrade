using EFEmilioAndrade.JEAIModels;

namespace EFEmilioAndrade;

public partial class SatelitePage : ContentPage
{
    Satelite Item = new Satelite();

    public SatelitePage()
	{
		InitializeComponent();
        LoadSatelite();


    }

    public void LoadSatelite(int value = -1)
    {
        if (value > -1)
        {
            Item = App.SateliteRepo.GetSatelite(value);
            SaveButton.Text = "Editar";
        }

        BindingContext = Item;

    }

    private void OnSavedClicked(object sender, EventArgs e)
    {
        Item.name = NameB.Text;
       
        if (SaveButton.Text == "Editar")
        {
            App.SateliteRepo.UpadateSatelite(Item);
        }
       
        Shell.Current.GoToAsync("..");

      
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


}