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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_6;
using LibMas;
using Масивы;

namespace _3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        int[,] matr;
		int[] mas;
       

        //Заполнение матрицы
        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {

            //Проверка поля на корректность введенных данных
            if(Int32.TryParse(kolStrok.Text, out int row) && Int32.TryParse(kolStolbcov.Text, out int column))
            {
                Class1.Заполнить(row, column, out matr);

                //Выводим матрицу на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        //Расчет задания для матрицы
        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            if (matr == null || matr.Length == 0)
            {
                MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку Заполнить", "Ошибка");
            }
            else
            {
                Class2.Старт(matr, out mas); //функция расчета
				masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

            }
        }
        //Очищение матрицы
        private void ОчиститьМатрицу_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null && matr.Length != 0)
            {
                Class1.ОчиститьМатрицу(matr);
                //Выводим матрицу на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку \"Заполнить", "Ошибка");
        }
        //Сохранение матрицы
        private void Savematr_Click(object sender, RoutedEventArgs e)
        {
            Class1.Savematr(matr);
        }

        //Открытие матрицы
        private void Openmatr_Click(object sender, RoutedEventArgs e)
        {
            
            Class1.Openmatr( out matr);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    //Выводим матрицу на форму
                    matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                }
            }
        }
        //Вывод информации о программе
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Митрохина Ксения. Практическая работа №3" +
                "\nДана матрица размера M × N. Для каждого столбца матрицы с четным номером (2, 4, …) найти сумму его элементов. Условный оператор не использовать. ");
        }

        //Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
