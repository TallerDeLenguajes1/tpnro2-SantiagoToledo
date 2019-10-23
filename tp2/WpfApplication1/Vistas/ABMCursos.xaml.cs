using AccesoADatos;
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

        public ABMCursos()         
        {
            InitializeComponent();
            lbDocentes.ItemsSource = Institucion.Empleados;
            alumnosAux = new List<Alumno>();
            lbAlumnos.ItemsSource = alumnosAux;
            lbAlumnosInstucion.ItemsSource = Institucion.Alumnos;
        }

        public ABMCursos(Curso cursoRecibido)
        {
            InitializeComponent();
            cursoX = cursoRecibido;
            alumnosAux = cursoRecibido.Alumnos;

            //AlumnoABM.AlumnosByCurso(cursoRecibido.IdCurso);
            lbDocentes.ItemsSource = Institucion.Empleados;
            lbAlumnos.ItemsSource = cursoRecibido.Alumnos;
            lbAlumnosInstucion.ItemsSource = Institucion.Alumnos;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var emp = lbDocentes.SelectedItem as Empleado;
            Turno turno = (Turno)Enum.Parse(typeof(Turno), cbTurno.Text);

            switch (cbModalidad.Text)
            {
                case "Presencial" :
                    cursoX = new Presencial(
                        turno,
                        emp,
                        txbTema.Text,
                        Convert.ToDouble(txbCuota.Text),
                        Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "SemiPresencial" :
                    cursoX = new SemiPresencial(
                        turno,
                        emp,
                        txbTema.Text,
                        Convert.ToDouble(txbCuota.Text),
                        Convert.ToDouble(txbInscripcion.Text));
                    break;
                case "NoPresencial":
                    cursoX = new NoPresencial(turno,
                        emp,
                        txbTema.Text,
                        Convert.ToDouble(txbCuota.Text),
                        Convert.ToDouble(txbInscripcion.Text));
                    break;
            }

            cursoX.CargarAlumnos(alumnosAux);

            foreach (Alumno al in cursoX.Alumnos)
            {
                al.setCuotas(cursoX.CrearCuotas());
            }

            CursoABM.insertCurso(cursoX);


            this.Close();
        }

        public Curso getCurso()
        {
            return cursoX;
        }

        private void btnAltaAlumno_Click(object sender, RoutedEventArgs e)
        {
            Alumno aux;
            if(lbAlumnosInstucion.SelectedItem != null )
            {
                aux = (Alumno)lbAlumnosInstucion.SelectedItem;
                if(!alumnosAux.Contains(aux))
                {
                alumnosAux.Add(aux);
                lbAlumnos.Items.Refresh();
                }
            }
        }
    }
}
