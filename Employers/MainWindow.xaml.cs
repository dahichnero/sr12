using Employers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace Employers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyWorkersContext context = new MyWorkersContext();
        public ObservableCollection<Employer> Employ { get; set; }
        public MainWindow()
        {
            Employ = new ObservableCollection<Employer>(Session.Instance.Context.Employers.Include(r=>r.JobNavigation));
            InitializeComponent();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Employ.Clear();
            IQueryable<Employer> query = Session.Instance.Context.Employers.AsQueryable();
            query = query.Where(q => q.LastName.Contains(search.Text) ||
        q.Name.Contains(search.Text));

            foreach (Employer emplo in query)
            {
                Employ.Add(emplo);
            }
        }

        private void sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch (sort.SelectedIndex)
            {
                case 0:
                    Employ.Clear();
                    IQueryable<Employer> query = Session.Instance.Context.Employers.AsQueryable();
                    query = query.OrderBy(r => r.Name);

                    foreach (Employer emplo in query)
                    {
                        Employ.Add(emplo);
                    }
                    break;
                    case 1:
                    Employ.Clear();
                    IQueryable<Employer> queryy = Session.Instance.Context.Employers.AsQueryable();
                    queryy = queryy.OrderByDescending(r => r.LastName);

                    foreach (Employer emplo in queryy)
                    {
                        Employ.Add(emplo);
                    }
                    break;
            }
        }
    }
}
