using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_MiNegocio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPrincipal());
        }

        public static byte[] imagenToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);

            return ms.ToArray();
        }

        //convertir binario a imágen
        public static Image arrayByteToImagen(Byte[] binario)
        {
            try
            {
                //si hay imagen
                if (binario != null)
                {
                    //caturar array con memorystream hacia Bin
                    //Dim Bin As New MemoryStream(Imagen)
                    var bin = new MemoryStream(binario);
                    //con el método FroStream de Image obtenemos imagen
                    //Dim Resultado As Image = Image.FromStream(Bin)
                    var resultado = Image.FromStream(bin);
                    //y la retornamos
                    return resultado;
                 }

                else
                {
                    return null;
                }
            }

            catch (Exception)
            {
                return null;
            }             
       }
    }
}
