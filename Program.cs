using EFCoreTut.Migrations.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTut.Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using(var context = new AppDbContext())
            //{
            //    foreach(var item in context.Sections.Include(e => e.Course))
            //    {
            //        Console.WriteLine($"Section Name: {item.SectionName} => Course Name: {item.Course.CourseName}");
            //    }
            //}

            // SOLVE: The Big Table in Github Repo Eng/ Essam
            // And Then, Make a repo and load this project into it

            using(var context = new AppDbContext())
            {
                // Here EF-CORE automatically made JOINs between These Entities 
                var sectionData = context.Sections
                                         .Include(e => e.Course)
                                         .Include(e => e.Instructor)
                                         .Include(e => e.Schedules)
                                         .Include(e => e.SectionSchedules);

                Console.WriteLine("|-----|----------------|--------------|-----------------|------------------|--------------|--------------|-------|-------|-------|-------|-------|-------|-------|");
                Console.WriteLine("| Id  |   Course Name  | Section Name | Instructor Name |  Schedule Title  |  Start Time  |   End Time   |  SUN  |  MON  |  TUE  |  WED  |  THU  |  FRI  |  SAT  |");
                Console.WriteLine("|-----|----------------|--------------|-----------------|------------------|--------------|--------------|-------|-------|-------|-------|-------|-------|-------|");

                foreach (var data in sectionData)
                {
                    var SUN = data.Schedules.Any(d => d.SUN) ? "X" : " ";
                    var MON = data.Schedules.Any(d => d.MON) ? "X" : " ";
                    var TUE = data.Schedules.Any(d => d.TUE) ? "X" : " ";
                    var WED = data.Schedules.Any(d => d.WED) ? "X" : " ";
                    var THU = data.Schedules.Any(d => d.THU) ? "X" : " ";
                    var FRI = data.Schedules.Any(d => d.FRI) ? "X" : " ";
                    var SAT = data.Schedules.Any(d => d.SAT) ? "X" : " ";

                    Console.WriteLine($"| {data.Id.ToString().PadLeft(3, '0')} | {data.Course.CourseName,-14} | {data.SectionName,-12} | {data.Instructor!.FName + " " + data.Instructor.LName,-15} | {data.Schedules.FirstOrDefault()!.Title,-16} | {data.SectionSchedules.FirstOrDefault()!.StartTime,-12} | {data.SectionSchedules.FirstOrDefault()!.EndTime,-12} | {SUN,-5} | {MON,-5} | {TUE,-5} | {WED,-5} | {THU,-5} | {FRI,-5} | {SAT,-5} |");
                    Console.WriteLine("|-----|----------------|--------------|-----------------|------------------|--------------|--------------|-------|-------|-------|-------|-------|-------|-------|");
                }
            }

            Console.ReadKey();
        }
    }
}