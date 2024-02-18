using System;
using System.Collections.Generic;
using System.Linq;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}


public class Instructor
{
    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
}


public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public Category Category { get; set; }
    public Instructor Instructor { get; set; }
}


public class CourseRepository
{
    private readonly List<Course> courses;

    public CourseRepository()
    {
        courses = new List<Course>();
    }


    public void CreateCourse(Course course)
    {
        courses.Add(course);
    }


    public Course GetCourse(int courseId)
    {
        return courses.FirstOrDefault(c => c.CourseId == courseId);
    }


    public void UpdateCourse(Course updatedCourse)
    {
        Course existingCourse = courses.FirstOrDefault(c => c.CourseId == updatedCourse.CourseId);
        if (existingCourse != null)
        {
            existingCourse.CourseName = updatedCourse.CourseName;
            existingCourse.Category = updatedCourse.Category;
            existingCourse.Instructor = updatedCourse.Instructor;
        }
    }

 
    public void DeleteCourse(int courseId)
    {
        Course courseToDelete = courses.FirstOrDefault(c => c.CourseId == courseId);
        if (courseToDelete != null)
        {
            courses.Remove(courseToDelete);
        }
    }
}

class Program
{
    static void Main()
    {

        Category backendCategory = new Category { CategoryId = 1, CategoryName = "Backend" };
        Category frontendCategory = new Category { CategoryId = 2, CategoryName = "Frontend" };

        Instructor gorkemCeyhan = new Instructor { InstructorId = 1, InstructorName = "Gorkem Ceyhan" };
        Instructor canCeyhan = new Instructor { InstructorId = 2, InstructorName = "Can Ceyhan" };


        CourseRepository repository = new CourseRepository();

        Course cSharpCourse = new Course { CourseId = 1, CourseName = "C#", Category = backendCategory, Instructor = gorkemCeyhan };
        Course javaScriptCourse = new Course { CourseId = 2, CourseName = "JavaScript", Category = frontendCategory, Instructor = canCeyhan };


        repository.CreateCourse(cSharpCourse);
        repository.CreateCourse(javaScriptCourse);

   
        Course updatedCSharpCourse = new Course { CourseId = 1, CourseName= "C# ASP.NET", Category = backendCategory, Instructor = gorkemCeyhan };
        repository.UpdateCourse(updatedCSharpCourse);


        Course retrievedCourse = repository.GetCourse(1);


        repository.DeleteCourse(1);


        Console.ReadKey();
    }
}
