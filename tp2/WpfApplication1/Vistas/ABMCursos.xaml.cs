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
    /// Lógica de interacción para ABMCursos.xaml
    /// </summary>
    public partial class ABMCursos : Window
    {
        Curso x;

        public ABMCursos(List<Empleado> empleados)          //Recibo la lista de empleados como parametro
        {
            InitializeComponent();
            lbDocentes.ItemsSource = empleados;
        }

        public ABMCursos(List<Empleado> empleados,Curso y)          //Recibo la lista de empleados como parametro
        {
            InitializeComponent();
            lbDocentes.ItemsSource = empleados;
            x = y;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = lbDocentes.SelectedItem as Empleado;
            switch (cbModalidad.Text)
            {
                case "Presencial" :
                    x = new Presencial(dtpTurno.SelectedDate.Value, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "SemiPresencial" :
                    x = new SemiPresencial(dtpTurno.SelectedDate.Value, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "NoPresencial":
                    x = new NoPresencial(dtpTurno.SelectedDate.Value, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
            }
           

            this.Close();
        }

        public Curso getCurso()
        {
            return x;
        }

        private void btnAltaAlumno_Click(object sender, RoutedEventArgs e)
        {
            ABMAlumnos FormularioAlumnos = new ABMAlumnos();
            FormularioAlumnos.ShowDialog();
            x.CargarAlumno(FormularioAlumnos.getAlumno());
            lbAlumnos.ItemsSource = x.Alumnos;
        }

    }
}
