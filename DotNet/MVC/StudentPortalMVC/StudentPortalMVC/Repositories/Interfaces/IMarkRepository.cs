using StudentPortalMVC.Models;
using System.Collections.Generic;

namespace StudentPortalMVC.Repositories.Interfaces
{
    public interface IMarkRepository
    {
        List<Mark> GetMarksByStudent(int studentId);
    }
}