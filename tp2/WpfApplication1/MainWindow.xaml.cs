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
        List<Empleado> Empleados;

        public MainWindow()
        {
            InitializeComponent();
            Empleados = new List<Empleado>();
        }

        private void btnAltaCurso_Click(object sender, RoutedEventArgs e)
        {
            ABMCursos FormularioCurso = new ABMCursos(Empleados);
            FormularioCurso.ShowDialog();
            Institucion.AgregarCurso(FormularioCurso.getCurso());
            lbCursos.ItemsSource = Institucion.Cursos;

        }

        private void btnAltaEmpleado_Click(object sender, RoutedEventArgs e)
        {
            ABMEmpleados FormularioEmpleado = new ABMEmpleados();  //genero nueva vista
            FormularioEmpleado.ShowDialog();                
            Empleados.Add(FormularioEmpleado.getEmpleado());        //agrego empleado creado a lista
            lbEmpleados.ItemsSource = Empleados;                    //asigno lista como fuente de datos del listbox 


          //  lbCursos.Items.Add(FormularioEmpleado.getEmpleado());     Para agregar los datos a la lista de a uno
          //  Debo modificar el toString() de la clase del objeto mostrado para que muestre lo que yo quiero 
        }

        private void lbCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbCursos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cursoX = (Curso)lbCursos.SelectedItem;
            ABMCursos FormularioCurso = new ABMCursos(Empleados, cursoX);
            FormularioCurso.ShowDialog();
        }
    }
}
