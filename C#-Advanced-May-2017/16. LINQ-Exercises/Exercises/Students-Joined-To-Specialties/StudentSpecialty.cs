public class StudentSpecialty
{
    public StudentSpecialty(string facultyNumber, string specialtyName)
    {
        this.FacultyNumber = facultyNumber;
        this.SpecialtyName = specialtyName;
    }

    public string FacultyNumber { get; set; }

    public string SpecialtyName { get; set; }
}