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
        Curso CursoX;
        List<Alumno> AlumnosAux;

        public ABMCursos(List<Empleado> empleados)          //Recibo la lista de empleados como parametro
        {
            InitializeComponent();
            lbDocentes.ItemsSource = empleados;
            AlumnosAux = new List<Alumno>();
        }

        public ABMCursos(List<Empleado> empleados,Curso y)          //Recibo la lista de empleados como parametro y el curso que quiero mostrar
        {
            InitializeComponent();
            lbDocentes.ItemsSource = empleados;
            AlumnosAux = new List<Alumno>();
            CursoX = y;

            txbTema.Text = CursoX.Tema;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var emp = lbDocentes.SelectedItem as Empleado;
            var fTurno = dtpTurno.SelectedDate.Value;


            switch (cbModalidad.Text)
            {
                case "Presencial" :
                    CursoX = new Presencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "SemiPresencial" :
                    CursoX = new SemiPresencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "NoPresencial":
                    CursoX = new NoPresencial(fTurno, emp, txbTema.Text, Convert.ToDouble(txbCuota.Text), Convert.ToDouble(txbInscripcion.Text));
                    break;
            }

            CursoX.CargarAlumnos(AlumnosAux);

            foreach (Alumno al in CursoX.Alumnos)
            {
                al.setCuotas(CursoX.CrearCuotas());
            }

            this.Close();
        }

        public Curso getCurso()
        {
            return CursoX;
        }

        private void btnAltaAlumno_Click(object sender, RoutedEventArgs e)
        {

            ABMAlumnos FormularioAlumnos = new ABMAlumnos();
            FormularioAlumnos.ShowDialog();
            AlumnosAux.Add(FormularioAlumnos.getAlumno());
            lbAlumnos.ItemsSource = AlumnosAux;
        }

        private void lbDocentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
