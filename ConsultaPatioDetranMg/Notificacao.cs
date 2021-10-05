using System.Windows.Forms;

namespace ConsultaPatioDetranMg
{
    public static class Notificacao
    {
        public static void Aviso(string msg)
        {
            MessageBox.Show(text: msg, caption: "Aviso", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation, defaultButton: MessageBoxDefaultButton.Button1);
        }

        public static void Informacao(string msg)
        {
            MessageBox.Show(text: msg, caption: "Informação", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information, defaultButton: MessageBoxDefaultButton.Button1);
        }
    }
}
