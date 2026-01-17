using learningwithos.Models;

namespace learningwithos.Repo
{
    public static class StudentListR
    {
        private static List<StudentList> student = new List<StudentList>()
        {
            new StudentList { Id = 0, Name = "jubair" },
            new StudentList { Id = 3, Name = "kamal" },
            new StudentList { Id = 5, Name = "rahima" },
        };

        public static List<StudentList> GetAllStudents()
        {
            return student;
        }

        public static StudentList GetById(int id)
        {
            return student.FirstOrDefault(x => x.Id == id);
        }

        public static void AddStudent(StudentList s)
        {
            s.Id = student.Count > 0 ? student.Max(st => st.Id) + 1 : 1;
            student.Add(s);
        }

        // ✅ UPDATE
        public static void UpdateStudent(StudentList s)
        {
            var existing = student.FirstOrDefault(x => x.Id == s.Id);
            if (existing == null) return;

            existing.Name = s.Name;
        }
    }
}


