using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using MVVM.Test.Services;
using MVVM.Test.Models;
using GalaSoft.MvvmLight.Command;
using MVVM.Test.Views;
using System.Linq;
using System.Windows;

namespace MVVM.Test.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            servicedb = new ServiceDb();

            QueryCommand = new RelayCommand(Query);

            ResetCommand = new RelayCommand(() => { 
                Search = string.Empty;
                this.Query();
            });

            AddCommand = new RelayCommand(Add);

            EditCommand = new RelayCommand<int>(t => Edit(t));
            DelCommand = new RelayCommand<int>(t => Del(t));
            // Query();
        }

        ServiceDb servicedb;
        private string search = string.Empty;
        public string Search 
        { 
            get { return search; } 
            set 
            { 
                search = value; 
                RaisePropertyChanged();
            } 
        }

        private ObservableCollection<Student> gridModelList;
		//private object userView;

		public ObservableCollection<Student> GridModelList
		{
            get { return gridModelList; }
            set 
            { 
                gridModelList = value;
                RaisePropertyChanged();
            }
		}

		//添加查找命令
		#region Command

        public RelayCommand QueryCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DelCommand { get; set; }

        #endregion

        public void Query()
		{
            var models = servicedb.GetStudentsByName(Search);
            GridModelList = new ObservableCollection<Student>();
            if(models != null)
			{
                models.ForEach(arg => { 
                    gridModelList.Add(arg);
                });
			}
		}

        public void Add()
		{
            Student student = new Student();
			UserView view = new UserView(student);
			var result = view.ShowDialog();
			if (result.Value)
			{
                student.Id = GridModelList.Max(x => x.Id) + 1;
                servicedb.AddStudent(student);
                this.Query();
			}
		}

        public void Edit(int id)
		{
            var model = servicedb.GetStudentById(id);
            if(model != null)
			{
                UserView view = new UserView(model);
               var result = view.ShowDialog();
                if(result.Value)
				{
                    var newModel = GridModelList.FirstOrDefault(t => t.Id == model.Id);
                    if(newModel != null)
					{
                        newModel.Name = model.Name;
					}
				}
            }
		}

        public void Del(int id)
		{
			var model = servicedb.GetStudentById(id);
            if (model != null)
            {
                var result = MessageBox.Show($"确认删除当前用户:{model.Name}", "操作提示", MessageBoxButton.OK, MessageBoxImage.Question);
                if(result == MessageBoxResult.OK)
				{
                    servicedb.DelStudent(model.Id);
				}
                this.Query();
            }
		}
    }
}