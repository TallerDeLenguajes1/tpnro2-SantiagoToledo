using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1.Vistas
{
    /// <summary>
    /// Lógica de interacción para ABMAlumnos.xaml
    /// </summary>
    public partial class ABMAlumnos : Window
    {
        Alumno AlumnoX;

        public ABMAlumnos()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AlumnoX = new Alumno();
            AlumnoX.Nombre = txbNombre.Text;
            AlumnoX.Apellido = txbNombre.Text;
            if(dtpFdeNacimiento.SelectedDate.HasValue)
            {
                AlumnoX.Fnacimiento = dtpFdeNacimiento.SelectedDate.Value;
            }
            this.Close();




        }

        public Alumno getAlumno()
        {
            return AlumnoX;
        }



    }
}
