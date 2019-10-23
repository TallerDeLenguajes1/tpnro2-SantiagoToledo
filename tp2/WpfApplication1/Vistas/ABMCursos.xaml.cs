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
        Curso cursoX;
        List<Alumno> alumnosAux;

        public ABMCursos(List<Empleado> empleados)          //Recibo la lista de empleados como parametro
        {
            InitializeComponent();
            lbDocentes.ItemsSource = empleados;
            alumnosAux = new List<Alumno>();
            lbAlumnos.ItemsSource = alumnosAux;
        }

        public ABMCursos(List<Empleado> empleados,Curso y)          //Recibo la lista de empleados como parametro y el curso que quiero mostrar
        {
            InitializeComponent();
            cursoX = y;
            alumnosAux = y.Alumnos;

            lbDocentes.ItemsSource = empleados;
            lbAlumnos.ItemsSource = alumnosAux;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var emp = lbDocentes.SelectedItem as Empleado;
            DateTime fTurno;
            if (dtpTurno.SelectedDate.HasValue)
            {
                fTurno = dtpTurno.SelectedDate.Value;
            }else
            {
                fTurno = DateTime.Now.Date;
            }

            switch (cbModalidad.Text)
            {
                case "Presencial" :
                    cursoX = new Presencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "SemiPresencial" :
                    cursoX = new SemiPresencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "NoPresencial":
                    cursoX = new NoPresencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
            }

            cursoX.CargarAlumnos(alumnosAux);

            foreach (Alumno al in cursoX.Alumnos)
            {
                al.setCuotas(cursoX.CrearCuotas());
            }

            this.Close();
        }

        public Curso getCurso()
        {
            return cursoX;
        }

        private void btnAltaAlumno_Click(object sender, RoutedEventArgs e)
        {
            ABMAlumnos FormularioAlumnos = new ABMAlumnos();
            FormularioAlumnos.ShowDialog();
            alumnosAux.Add(FormularioAlumnos.getAlumno());
            lbAlumnos.Items.Refresh();
        }

        private void lbDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
