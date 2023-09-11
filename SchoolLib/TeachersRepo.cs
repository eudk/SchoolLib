using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class TeachersRepo
    {
        private int nextId = 1;
        private List<Teacher> teachers = new ();
        private List<string> Classes = new ();

        public TeachersRepo()
        {
            teachers.Add(new Teacher(nextId++,"John Doe", "Math", "Math teacher"));
            teachers.Add(new Teacher(nextId++, "Jane Doe", "English", "English teacher"));
            teachers.Add(new Teacher(nextId++, "Jack Doe", "Science", "Science teacher"));
        }

        public List<Teacher> Get()
        {
            return new List<Teacher>(teachers); // return a copy of the list 
        }



        public Teacher Add(Teacher teacher) // add a new teacher to the list
        {
            teacher.ValidateName(teacher.Name);
            teacher.Id= nextId++;
            teachers.Add(teacher);
            return teacher;
        }


        public Teacher? GetById(int id) // get a teacher by id
        {
            return teachers.FirstOrDefault(t => t.Id == id);
        }



        public void Remove(int id) // remove a teacher from the list
        {
            var teacher = GetById(id);
            if (teacher == null)
            {
                throw new ArgumentException("Teacher not found");
            }
            teachers.Remove(teacher);
        }




        public void Update(int id, Teacher teacher) // update a teacher in the list
        {
            var existingTeacher = GetById(id);
            if (existingTeacher == null)
            {
                throw new ArgumentException("Teacher not found");
            }
            existingTeacher.Name = teacher.Name;
            existingTeacher.Subject = teacher.Subject;
            existingTeacher.Description = teacher.Description;
        }
    }
}
