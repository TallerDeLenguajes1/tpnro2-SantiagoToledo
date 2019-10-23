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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Vistas;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Institucion.Alumnos = AlumnoABM.listaAlumnos();
            Institucion.Cursos = CursoABM.listaCursos();
            Institucion.Empleados = EmpleadoABM.listaEmpleados();
            // Institucion.Empleados = EmpleadoABM.listaEmpleados();

            lbAlumnos.ItemsSource = Institucion.Alumnos;
            lbEmpleados.ItemsSource = Institucion.Empleados;           
            lbCursos.ItemsSource = Institucion.Cursos;
        }

        private void btnAltaCurso_Click(object sender, RoutedEventArgs e)
        {
            ABMCursos FormularioCurso = new ABMCursos();
            FormularioCurso.ShowDialog();
            Institucion.Cursos.Add(FormularioCurso.getCurso());
            lbCursos.Items.Refresh();
        }

        private void btnAltaEmpleado_Click(object sender, RoutedEventArgs e)
        {
            ABMEmpleados FormularioEmpleado = new ABMEmpleados(); 
            FormularioEmpleado.ShowDialog();                
            Institucion.Empleados.Add(FormularioEmpleado.getEmpleado());        
            lbEmpleados.Items.Refresh();
        }


        private void btnAltaAlumno_Click(object sender, RoutedEventArgs e)
        {
            ABMAlumnos FormularioAlumnos = new ABMAlumnos();
            FormularioAlumnos.ShowDialog();
            Institucion.Alumnos.Add(FormularioAlumnos.getAlumno());
            lbAlumnos.Items.Refresh();
        }


        private void lbCursos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cursoX = (Curso)lbCursos.SelectedItem;
            ABMCursos FormularioCurso = new ABMCursos(cursoX);
            FormularioCurso.ShowDialog();
            lbCursos.Items.Refresh();

        }

        private void btnBajaCurso_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Esta seguro que desea eliminar curso?", "Elminar curso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
               // CursoABM.bajaCurso()
            }
        }

        private void btnBajaEmpleado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBajaAlumno_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
