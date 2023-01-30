using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.OleDb;
using System.Collections.ObjectModel;
using System.Data.Common;
using System;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DPOService
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

        public void DBLoad()
        {
            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection = new SqlConnection(connectionString);                   //создаем соеденение


            // Выполянем запрос к БД
            dbConnection.Open();                                            // открываем соеденение
            string query = "SELECT ID, article_number, name, serial_number, date FROM main";                            // строка запроса
            SqlCommand dbCommand = new SqlCommand(query, dbConnection); // команда
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);
            DGrid.ItemsSource = dt.AsDataView();                         // считываем данные

            dbConnection.Close();

        }
        public void DBCount()
        {
            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection = new SqlConnection(connectionString);                   //создаем соеденение


            // Выполянем запрос к БД
            dbConnection.Open();                                            // открываем соеденение
            string query = "SELECT Count(*) FROM main";                            // строка запроса
            SqlCommand dbCommand = new SqlCommand(query, dbConnection); // команда
            int count = (Int32)dbCommand.ExecuteScalar();
            CountUsers.Number = count.ToString();
            dbConnection.Close();

        }

        public void DBLoad1()
        {
            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection = new SqlConnection(connectionString);                   //создаем соеденение


            // Выполянем запрос к БД
            dbConnection.Open();                                            // открываем соеденение
            string query = "SELECT ID, article_number, name, serial_number, date FROM mainn";                            // строка запроса
            SqlCommand dbCommand = new SqlCommand(query, dbConnection); // команда
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);
            DGrid1.ItemsSource = dt.AsDataView();                         // считываем данные

            dbConnection.Close();

        }

        public void DBCount1()
        {
            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection = new SqlConnection(connectionString);                   //создаем соеденение


            // Выполянем запрос к БД
            dbConnection.Open();                                            // открываем соеденение
            string query = "SELECT Count(*) FROM mainn";                            // строка запроса
            SqlCommand dbCommand = new SqlCommand(query, dbConnection); // команда
            int count = (Int32)dbCommand.ExecuteScalar();
            CountUsers.Number = count.ToString();
            dbConnection.Close();

        }

        public void DBDate()
        {

            DateTime dt = DateTime.Now;
            string curDate = dt.ToShortDateString();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ExitButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBLoad();
            DBCount();
            DBDate();
            DBLoad1();
            DBCount1();
        }


        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                System.Windows.MessageBox.Show("Выберете нужную строку для удаления, а затем нажмите на эту кнопку", "Внимание!");
            }
            else
            {
                string index = row.Row.ItemArray[0].ToString();
                if (row != null)
                {
                    if (System.Windows.MessageBox.Show("Вы точно хотите удалить данную строку?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                            SqlConnection dbConnection = new SqlConnection(connectionString);

                            dbConnection.Open();
                            string query = $"DELETE FROM main WHERE ID LIKE {index}";
                            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                            dbCommand.ExecuteNonQuery();
                            dbConnection.Close();

                            DBCount();
                            DBLoad(); 

                            System.Windows.MessageBox.Show("Данные удалены");

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message.ToString());
                        }
                        
                    }
                }
                else
                {
                    
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            {
                addPage.Visibility = Visibility.Visible;
                MainPage.Visibility = Visibility.Hidden;

            }

        }

        public void DBSearchQuery(string SearchKey)
        {
            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT ID, article_number, name, serial_number, date FROM main WHERE article_number LIKE '{search.Text}%' OR name LIKE '{search.Text}%' OR serial_number LIKE '{search.Text}%'";                            // строка запроса
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);
            DGrid.ItemsSource = dt.AsDataView();
            dbConnection.Close();

        }

        public void DBSearchQuery1(string SearchKey)
        {
            string connectionString1 = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";  //строка соеденения
            SqlConnection dbConnection1 = new SqlConnection(connectionString1);

            dbConnection1.Open();
            string query = $"SELECT ID, article_number, name, serial_number, date FROM mainn WHERE article_number LIKE '{search1.Text}%' OR name LIKE '{search1.Text}%' OR serial_number LIKE '{search1.Text}%'";                            // строка запроса
            SqlCommand dbCommand1 = new SqlCommand(query, dbConnection1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(dbCommand1);
            adapter1.Fill(dt1);
            DGrid1.ItemsSource = dt1.AsDataView();
            dbConnection1.Close();

        }

        private void Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DBSearchQuery(search.Text);
            }
        }

           private void SpravkaButton_Click(object sender, RoutedEventArgs e)
        {
            SpravkaPage.Visibility = Visibility.Visible;
            MainPage.Visibility = Visibility.Hidden;
            MainnPage.Visibility = Visibility.Hidden;
            StatisticPage.Visibility = Visibility.Hidden;
        }
        private void AddButtonBack_Click(object sender, RoutedEventArgs e)
        {
            addPage.Visibility = Visibility.Hidden;
            MainPage.Visibility = Visibility.Visible;

            addarticle_numberTextBox.Text = "";
            addnameTextBox.Text = "";
            addserial_numberTextBox.Text = "";
            adddateTextBox.Text = "";
           
        }

        private void AddButtonConf_Click(object sender, RoutedEventArgs e)
        {
            string Clientarticle_number = addarticle_numberTextBox.Text;
            string Clientname = addnameTextBox.Text;
            string Clientserial_number = addserial_numberTextBox.Text;
            string Clientdate = adddateTextBox.Text;



            if (Clientarticle_number.Length < 1)
            {
                addarticle_numberTextBox.ToolTip = "Поле обязательно для заполнения";
                addarticle_numberTextBox.Background = Brushes.DarkRed;
            }
            else if (Clientarticle_number.Length > 0 && Clientname.Length < 1)
            {
                addarticle_numberTextBox.ToolTip = "";
                addarticle_numberTextBox.Background = Brushes.Transparent;
                addnameTextBox.ToolTip = "Поле обязательно для заполнения";
                addnameTextBox.Background = Brushes.DarkRed;
            }
            else if (Clientname.Length > 0 && Clientserial_number.Length < 1)
            {
                addnameTextBox.ToolTip = "";
                addnameTextBox.Background = Brushes.Transparent;
                addserial_numberTextBox.ToolTip = "Поле обязательно для заполнения";
                addserial_numberTextBox.Background = Brushes.DarkRed;
            }
            else if (Clientserial_number.Length > 0 && Clientdate.Length < 1)
            {
                addserial_numberTextBox.ToolTip = "";
                addserial_numberTextBox.Background = Brushes.Transparent;
                adddateTextBox.ToolTip = "Поле обязательно для заполнения";
                adddateTextBox.Background = Brushes.DarkRed;
            }


            else if (Clientdate.Length > 0)
            {
                adddateTextBox.ToolTip = "";
                adddateTextBox.Background = Brushes.Transparent;
                System.Windows.MessageBox.Show("Данные успешно добавлены!");





                string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                SqlConnection dbConnection = new SqlConnection(connectionString);

                dbConnection.Open();
                string query = $"INSERT INTO main (article_number, name, serial_number, date) VALUES ('{Clientarticle_number}','{Clientname}','{Clientserial_number}','{Clientdate}')";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                dbCommand.ExecuteNonQuery();


                addarticle_numberTextBox.Text = "";
                addnameTextBox.Text = "";
                addserial_numberTextBox.Text = "";
                adddateTextBox.Text = "";


                dbConnection.Close();
                DBLoad();
            }
        }

        private void AddPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            DataRowView row = DGrid.SelectedItem as DataRowView;
            
            if (row == null)
            {
                System.Windows.MessageBox.Show("Выберете нужную строку для изменения, а затем нажмите на эту кнопку", "Внимание!");
            }
            else
            {
                string index = row.Row.ItemArray[0].ToString();
                string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);

          
                dbConnection.Open();
                string query = $"SELECT article_number, name, serial_number, date FROM main WHERE ID LIKE {index}";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                dbCommand.ExecuteNonQuery();

                DataTable querrytabel = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
                adapter.Fill(querrytabel);

                dbConnection.Close();

                string Clientarticle_number = querrytabel.Rows[0][0].ToString();
                string Clientname = querrytabel.Rows[0][1].ToString();
                string Clientserial_number = querrytabel.Rows[0][2].ToString();
                string Clientdate = querrytabel.Rows[0][3].ToString();


                editarticle_numberTextBox.Text = Clientarticle_number;
                editnameTextBox.Text = Clientname;
                editserial_numberTextBox.Text = Clientserial_number;
                editdateTextBox.Text = Clientdate;

                editPage.Visibility = Visibility.Visible;
                MainPage.Visibility = Visibility.Hidden;
            }
        }

        private void EditButtonConf_Click(object sender, RoutedEventArgs e)
        {
            string Clientarticle_number = editarticle_numberTextBox.Text;
            string Clientname = editnameTextBox.Text;
            string Clientserial_number = editserial_numberTextBox.Text;
            string Clientdate = editdateTextBox.Text;

            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);

            DataRowView row = DGrid.SelectedItem as DataRowView;
            string index = row.Row.ItemArray[0].ToString();

            dbConnection.Open();
            string query = $"UPDATE main SET article_number = '{Clientarticle_number}', name = '{Clientname}', serial_number = '{Clientserial_number}', date = '{Clientdate}' WHERE ID LIKE '{index}'";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();
            System.Windows.MessageBox.Show("Данные успешно сохранены!");
            dbConnection.Close();
            DBLoad();
        
        }

        private void EditButtonBack_Click(object sender, RoutedEventArgs e)
        {
            editPage.Visibility = Visibility.Hidden;
            MainPage.Visibility = Visibility.Visible;

            editarticle_numberTextBox.Text = "";
            editnameTextBox.Text = "";
            editserial_numberTextBox.Text = "";
            editdateTextBox.Text = "";
        }

        private void OborudButton_Click(object sender, RoutedEventArgs e)
        {
          
            MainPage.Visibility = Visibility.Visible;
            SpravkaPage.Visibility = Visibility.Hidden;
            MainnPage.Visibility = Visibility.Hidden;
            StatisticPage.Visibility = Visibility.Hidden;
        }

       

        private void MainRTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog p = new System.Windows.Controls.PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(DGrid, "Печать");
            }
        }

        private void PerenosButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                System.Windows.MessageBox.Show("Выберете нужную строку для переноса, а затем нажмите на эту кнопку", "Внимание!");
            }
            else
            {
                string index = row.Row.ItemArray[0].ToString();
                if (row != null)
                {
                    if (System.Windows.MessageBox.Show("Вы точно хотите перенести данную строку в таблицу Списанное?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {


                            //добавление в таблицу Списанное


                         

                            string connectionString1 = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                            SqlConnection dbConnection1 = new SqlConnection(connectionString1);
                          
                            
                            DataRowView row1 = DGrid.SelectedItem as DataRowView;
                            string index1 = row1.Row.ItemArray[0].ToString();

                            dbConnection1.Open();
                            string query1 = $"INSERT INTO mainn (article_number, name, serial_number, date) select main.article_number, main.name, main.serial_number, main.date from main LEFT JOIN mainn ON main.article_number = mainn.article_number, main.name = mainn.name, main.serial_number = mainn.serial_number, main.date = mainn.date WHERE ID LIKE '{index1}'";
                            SqlCommand dbCommand1 = new SqlCommand(query1, dbConnection1);
                            dbCommand1.ExecuteNonQuery();
                            
                            System.Windows.MessageBox.Show("Данные успешно сохранены!");
                            dbConnection1.Close();
                            DBLoad1();


                            //удаление из таблицы Оборудование
                            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                            SqlConnection dbConnection = new SqlConnection(connectionString);

                            dbConnection.Open();
                            string query = $"DELETE FROM main WHERE ID LIKE {index}";
                            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                            dbCommand.ExecuteNonQuery();
                            dbConnection.Close();

                            DBCount();
                            DBLoad();

                            System.Windows.MessageBox.Show("Данные перенесены!");
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message.ToString());
                        }

                    }
                }
                else
                {

                }
            }
        }

        private void SpisanButton_Click(object sender, RoutedEventArgs e)
        {
            MainnPage.Visibility = Visibility.Visible;
            MainPage.Visibility = Visibility.Hidden;
            SpravkaPage.Visibility = Visibility.Hidden;
            StatisticPage.Visibility = Visibility.Hidden;
        }

        private void PrintButton1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog q = new System.Windows.Controls.PrintDialog();
            if (q.ShowDialog() == true)
            {
                q.PrintVisual(DGrid1, "Печать");
            }
        }

        private void AddButton1_Click(object sender, RoutedEventArgs e)
        {
            addPage1.Visibility = Visibility.Visible;
            MainnPage.Visibility = Visibility.Hidden;

            addarticle_numberTextBox1.Text = "";
            addnameTextBox1.Text = "";
            addserial_numberTextBox1.Text = "";
            adddateTextBox1.Text = "";
        }

        private void EditButton1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DGrid1.SelectedItem as DataRowView;

            if (row == null)
            {
                System.Windows.MessageBox.Show("Выберете нужную строку для изменения, а затем нажмите на эту кнопку", "Внимание!");
            }
            else
            {
                string index = row.Row.ItemArray[0].ToString();
                string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                SqlConnection dbConnection = new SqlConnection(connectionString);


                dbConnection.Open();
                string query = $"SELECT article_number, name, serial_number, date FROM mainn WHERE ID LIKE {index}";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                dbCommand.ExecuteNonQuery();

                DataTable querrytabel = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
                adapter.Fill(querrytabel);

                dbConnection.Close();

                string Clientarticle_number = querrytabel.Rows[0][0].ToString();
                string Clientname = querrytabel.Rows[0][1].ToString();
                string Clientserial_number = querrytabel.Rows[0][2].ToString();
                string Clientdate = querrytabel.Rows[0][3].ToString();


                editarticle_numberTextBox1.Text = Clientarticle_number;
                editnameTextBox1.Text = Clientname;
                editserial_numberTextBox1.Text = Clientserial_number;
                editdateTextBox1.Text = Clientdate;

                editPage1.Visibility = Visibility.Visible;
                MainnPage.Visibility = Visibility.Hidden;
            }
        }

        private void DelButton1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DGrid1.SelectedItem as DataRowView;
            if (row == null)
            {
                System.Windows.MessageBox.Show("Выберете нужную строку для удаления, а затем нажмите на эту кнопку", "Внимание!");
            }
            else
            {
                string index = row.Row.ItemArray[0].ToString();
                if (row != null)
                {
                    if (System.Windows.MessageBox.Show("Вы точно хотите удалить данную строку?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                            SqlConnection dbConnection = new SqlConnection(connectionString);

                            dbConnection.Open();
                            string query = $"DELETE FROM mainn WHERE ID LIKE {index}";
                            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                            dbCommand.ExecuteNonQuery();
                            dbConnection.Close();

                            DBCount1();
                            DBLoad1();

                            System.Windows.MessageBox.Show("Данные удалены");

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message.ToString());
                        }

                    }
                }
                else
                {

                }
            }
        }

        private void OborudButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddButtonConf1_Click(object sender, RoutedEventArgs e)
        {
            string Clientarticle_number = addarticle_numberTextBox1.Text;
            string Clientname = addnameTextBox1.Text;
            string Clientserial_number = addserial_numberTextBox1.Text;
            string Clientdate = adddateTextBox1.Text;



            if (Clientarticle_number.Length < 1)
            {
                addarticle_numberTextBox1.ToolTip = "Поле обязательно для заполнения";
                addarticle_numberTextBox1.Background = Brushes.DarkRed;
            }
            else if (Clientarticle_number.Length > 0 && Clientname.Length < 1)
            {
                addarticle_numberTextBox1.ToolTip = "";
                addarticle_numberTextBox1.Background = Brushes.Transparent;
                addnameTextBox1.ToolTip = "Поле обязательно для заполнения";
                addnameTextBox1.Background = Brushes.DarkRed;
            }
            else if (Clientname.Length > 0 && Clientserial_number.Length < 1)
            {
                addnameTextBox1.ToolTip = "";
                addnameTextBox1.Background = Brushes.Transparent;
                addserial_numberTextBox1.ToolTip = "Поле обязательно для заполнения";
                addserial_numberTextBox1.Background = Brushes.DarkRed;
            }
            else if (Clientserial_number.Length > 0 && Clientdate.Length < 1)
            {
                addserial_numberTextBox1.ToolTip = "";
                addserial_numberTextBox1.Background = Brushes.Transparent;
                adddateTextBox1.ToolTip = "Поле обязательно для заполнения";
                adddateTextBox1.Background = Brushes.DarkRed;
            }


            else if (Clientdate.Length > 0)
            {
                adddateTextBox1.ToolTip = "";
                adddateTextBox1.Background = Brushes.Transparent;
                System.Windows.MessageBox.Show("Данные успешно добавлены!");





                string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
                SqlConnection dbConnection = new SqlConnection(connectionString);

                dbConnection.Open();
                string query = $"INSERT INTO mainn (article_number, name, serial_number, date) VALUES ('{Clientarticle_number}','{Clientname}','{Clientserial_number}','{Clientdate}')";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                dbCommand.ExecuteNonQuery();


                addarticle_numberTextBox1.Text = "";
                addnameTextBox1.Text = "";
                addserial_numberTextBox1.Text = "";
                adddateTextBox1.Text = "";


                dbConnection.Close();
                DBLoad1();
            }
        }

        private void AddButtonBack1_Click(object sender, RoutedEventArgs e)
        {
            addPage1.Visibility = Visibility.Hidden;
            MainnPage.Visibility = Visibility.Visible;

            addarticle_numberTextBox1.Text = "";
            addnameTextBox1.Text = "";
            addserial_numberTextBox1.Text = "";
            adddateTextBox1.Text = "";
        }

        private void EditButtonConf1_Click(object sender, RoutedEventArgs e)
        {
            string Clientarticle_number = editarticle_numberTextBox1.Text;
            string Clientname = editnameTextBox1.Text;
            string Clientserial_number = editserial_numberTextBox1.Text;
            string Clientdate = editdateTextBox1.Text;

            string connectionString = @"Data Source=DESKTOP-TU03NCN\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);

            DataRowView row = DGrid1.SelectedItem as DataRowView;
            string index = row.Row.ItemArray[0].ToString();

            dbConnection.Open();
            string query = $"UPDATE mainn SET article_number = '{Clientarticle_number}', name = '{Clientname}', serial_number = '{Clientserial_number}', date = '{Clientdate}' WHERE ID LIKE '{index}'";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();
            System.Windows.MessageBox.Show("Данные успешно сохранены!");
            dbConnection.Close();
            DBLoad1();
        }

        private void EditButtonBack1_Click(object sender, RoutedEventArgs e)
        {
            editPage1.Visibility = Visibility.Hidden;
            MainnPage.Visibility = Visibility.Visible;

            editarticle_numberTextBox1.Text = "";
            editnameTextBox1.Text = "";
            editserial_numberTextBox1.Text = "";
            editdateTextBox1.Text = "";
        }

        private void PerenosButton1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DBSearchQuery1(search1.Text);
            }
        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticPage.Visibility = Visibility.Visible;
            MainPage.Visibility = Visibility.Hidden;
            MainnPage.Visibility = Visibility.Hidden;
            SpravkaPage.Visibility = Visibility.Hidden;
        }
    }
}
