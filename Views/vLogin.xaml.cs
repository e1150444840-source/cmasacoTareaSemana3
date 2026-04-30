namespace cmasacoTS3.Views;

public partial class vLogin : ContentPage
{
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] claves = { "carlos123", "ana123", "jose123" };

    public vLogin()
	{
		InitializeComponent();
        
    }


    private async void btnIniciar_Clicked(object sender, EventArgs e)
    {
        // Validamos que no estén vacíos
        if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
        {
            await DisplayAlert("Atención", "Por favor, completa todos los campos", "OK");
            return;
        }

        // Datos quemados según tu requerimiento
        

        bool acceso = false;
        string nsesion = "";

        for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == txtUsuario.Text && claves[i] == txtContrasena.Text)
                {
                    acceso = true;
                    nsesion = usuarios[i];
                    break;
                }
            }
        if(acceso)
            {

                await Navigation.PushAsync(new Views.vNotas(nsesion));
            }
        else
            {
                await DisplayAlert("Error", "Usuario o Contraseña Incorrectos", "Intentar de nuevo");
            }
        }
}