namespace cmasacoTS3.Views;

public partial class vNotas : ContentPage
{
	public vNotas(string usuarios)
	{
		InitializeComponent();

        DisplayAlertAsync("BIENVENIDO", usuarios, "OK");
        lblSesion.Text = "Usuario Conectado: " + usuarios;
    }


    private void btnCalcular_Clicked(object sender, EventArgs e)
    {

        try
        {
            if (pkEstudiantes.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNota1.Text) ||
                string.IsNullOrWhiteSpace(txtExamen1.Text) ||
                string.IsNullOrWhiteSpace(txtNota2.Text) ||
                string.IsNullOrWhiteSpace(txtExamen2.Text))
            {
                DisplayAlert("Atención", "Por favor, Ingrese todos los campos.", "OK");
                return;
            }

            double n1 = double.Parse(txtNota1.Text);
            double e1 = double.Parse(txtExamen1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double e2 = double.Parse(txtExamen2.Text);

            if (n1 < 0 || n1 > 10 || e1 < 0 || e1 > 10 || n2 < 0 || n2 > 10 || e2 < 0 || e2 > 10)
            {
                DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
                return;
            }

            double nota1 = Convert.ToDouble(txtNota1.Text);
            double examen1 = Convert.ToDouble(txtExamen1.Text);
            double np1 = (nota1 * 0.3) + (examen1 * 0.2);
            lblNP1.Text = np1.ToString("N2");

            double nota2 = Convert.ToDouble(txtNota2.Text);
            double examen2 = Convert.ToDouble(txtExamen2.Text);
            double np2 = (nota2 * 0.3) + (examen2 * 0.2);
            lblNP2.Text = np2.ToString("N2");

            double notaFinal = (np1 + np2);
            lblNF.Text = notaFinal.ToString("N2");


            string estado = "";

            if (notaFinal >= 7)
            {
                estado = "APROBADO";
                lblEstado.TextColor = Colors.Green;
            }
            else if (notaFinal >= 5 && notaFinal <= 6.99)
            {
                estado = "COMPLEMENTARIO";
                lblEstado.TextColor = Colors.Orange;
            }
            else
            {
                estado = "REPROBADO";
                lblEstado.TextColor = Colors.Red;
            }

            lblEstado.Text = estado;
        }
        catch
        {
            DisplayAlert("Dato Inválido", "Asegúrese de ingresar solo números (use punto para decimales).", "OK");
        }



    }

    // Metodo para cambiar un punto por coma
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        if (e.NewTextValue.Contains("."))
        {
            entry.Text = e.NewTextValue.Replace(".", ",");
        }
    }

    //botan de limpiar o borrar
    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        pkEstudiantes.SelectedIndex = 0;
        txtNota1.Text = string.Empty;
        txtExamen1.Text = string.Empty;
        txtNota2.Text = string.Empty;
        txtExamen2.Text = string.Empty;
        lblNP1.Text = "0,00";
        lblNP2.Text = "0,00";
        lblNF.Text = "0,00";
        lblEstado.Text = " ";
        dpFechaIngreso.Date = DateTime.Now;

    }

    //boton de guardar o enviar
    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (pkEstudiantes.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNota1.Text) ||
                string.IsNullOrWhiteSpace(txtExamen1.Text) ||
                string.IsNullOrWhiteSpace(txtNota2.Text) ||
                string.IsNullOrWhiteSpace(lblNP1.Text) ||
                string.IsNullOrWhiteSpace(lblNP2.Text) ||
                string.IsNullOrWhiteSpace(lblNF.Text) ||
                string.IsNullOrWhiteSpace(lblEstado.Text))
        {
            DisplayAlert("Atención", "Por favor, Ingrese todos los campos.", "OK");
            return;
        }

        string np1 = lblNP1.Text;
        string np2 = lblNP2.Text;
        string nf = lblNF.Text;
        string estado = lblEstado.Text;
        string fi = $"{dpFechaIngreso.Date:dd/MM/yyy}";
        string estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();

        DisplayAlertAsync("LAS NOTAS SE HAN GUARDADO CORRECTAMENTE", "Nombre: " + estudiante +
                      "\nFecha:  " + fi +
                      "\nNota Parcial 1: " + np1 +
                      "\nNota Parcial 2: " + np2 +
                      "\nNota Final: " + nf +
                      "\nNota Final: " + estado, "Cerrar");
    }
}