using MVVM.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Test.Services
{
	public class ServiceDb
	{
		public ServiceDb()
		{
			Init();
		}

		private List<Student> students;

		private void Init()
		{
			students = new List<Student>();
			for(int i = 0; i < 30; i++)
			{
				students.Add(new Student() { 
					Id = i,
					Name = $"Sample{i}"
				});
			}
		}

		public List<Student> GetStudent()
		{
			return students;
		}

		public void AddStudent(Student stu)
		{
			students.Add((Student)stu);
		}

		public void DelStudent(int id)
		{
			var model = students.FirstOrDefault(t => t.Id == id);
			if(model != null)
			{
				students.Remove(model);
			}
		}

		public List<Student> GetStudentsByName(string name)
		{
			return students.Where(q=>q.Name.Contains(name)).ToList();
		}

		public Student GetStudentById(int id)
		{
			var model = students.FirstOrDefault(t => t.Id == id);
			if(model != null)
			{
				return new Student()
				{
					Id = model.Id,
					Name = model.Name
				};
			}
			return null;
		}
	}
}
